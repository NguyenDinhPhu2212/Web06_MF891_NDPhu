<template>
    <div class="input-container">
        <label v-if="label" class="notosans-bold"
            >{{ label }}{{ " "
            }}<span v-if="required"
                ><span style="color: red">*</span></span
            ></label
        >
        <div
            :class="[
                { 'notice-border': error, 'border-focus': correct },
                'input-box',
            ]"
            @click="clickInput"
            :title="msg"
        >
            <input
                v-bind="$attrs"
                :required="required"
                :type="type"
                :class="{
                    'right-lign': format == 'currency',
                }"
                :tabindex="tabindex"
                :value="inputValue"
                :fieldName="fieldName"
                :placeholder="placeholder"
                @input="updateValue($event.target.value)"
                @keypress="keyPress"
                @blur="onBlur"
                autocomplete="off"
                ref="BaseInput"
            />
        </div>
    </div>
</template>

<script>
import { MESSAGE } from "../../constants/message";
export default {
    inheritAttrs: false,
    name: "BaseInput",
    props: {
        type: { type: String, default: "text" },
        required: { type: Boolean, default: false },
        label: String,
        value: { type: String, default: "" },
        tabindex: Number,
        format: { type: String, default: "text" },
        fieldName: String,
        placeholder: String,
    },
    data() {
        return {
            error: false,
            correct: false,
            msg: "",
            inputValue: "",
            initValue: "",
        };
    },
    watch: {
        value: function () {
            this.inputValue = this.value;
            this.initValue = this.value;
        },
    },
    methods: {
        clickInput: function () {
            this.correct = true;
            this.msg = "";
            this.$refs.BaseInput.focus();
        },
        /**
         * Cập nhật lại gía trị của input
         */
        updateValue(value) {
            this.$emit("input", value);
            this.inputValue = value;
        },
        /**
         * Sự kiện khi blur input
         */
        async onBlur(event) {
            let value = event.target.value;
            let type = this.fieldName;
            // Tiến hành validate
            if (this.required && value == "") {
                if (type == "Code") this.msg = MESSAGE.VALIDATE_ERROR_CODE;
                else if (type == "Name") this.msg = MESSAGE.VALIDATE_ERROR_NAME;
                this.error = true;
                return;
            }
            this.msg = "";
            this.correct = false;
            this.error = false;
        },
        // Sự kiện khi gõ input nếu là currency
        keyPress(e) {
            if (this.format === "currency" || this.format === "number") {
                if (e.key < "0" || e.key > "9") {
                    e.preventDefault();
                }
            }
        },
    },
};
</script>
<style scoped>
@import url("../../css/common/tooltip.css");

.input-container {
    width: 100%;
    position: relative;
}
label {
    margin-bottom: 5px;
}
.border-focus {
    border: 1px solid #2ca01c !important;
    border-radius: 2px;
}
.notice-border {
    border: 1px solid red !important;
    border-radius: 2px;
}
.input-box {
    height: 32px;
    border: 1px solid #bbbbbb;
    width: 100%;
    display: flex;
    align-items: center;
    border-radius: 2px;
}
input {
    border: none;
    outline: none;
    box-shadow: none;
    width: calc(100% - 8px);
    height: 30px !important;
    margin-left: 8px;
    border-radius: 2px;
}
input::placeholder {
    font-family: "notosans-italic", sans-serif;
    font-size: 12px;
}
.right-lign {
    padding-right: 50px;
    text-align: right;
    width: calc(100% - 65px);
}
.currency {
    font-size: 13px;
    position: absolute;
    top: 38px;
    right: 5px;
    font-style: italic !important;
    color: grey;
}
</style>