<template>
    <div
        class="combobox"
        :id="comboboxId"
        :data="data"
        ref="combobox"
        :style="{ width: width + 'px' }"
    >
        <div
            class="select-trigger flex-align-center combobox-border"
            :style="{ border: border }"
            :class="{ 'border-focus': isTrue, 'notice-border': error }"
            :title="msg"
        >
            <input
                type="text"
                :placeholder="placeholder"
                :style="{ border: border }"
                :class="{ 'notosans-semibold': bold }"
                :required="required"
                :tabindex="tabindex"
                @keydown.enter.prevent="enter"
                @keydown.down.prevent="down"
                @keydown.up.prevent="up"
                @focus="clickInput"
                @input="input"
                @click="clickInput"
                autocomplete="off"
                ref="BaseInput"
                v-model="search"
            />
            <div class="point-down-icon" @click="clickIcon">
                <div class="arrow-down"></div>
            </div>
        </div>
        <div
            class="select-options combobox-border"
            ref="optionsBox"
            v-show="showOption"
        >
            <div
                class="option"
                v-for="(value, i) in options"
                :key="i"
                @click="choosedOption(value)"
                ref="option"
                :class="{
                    choosed: result && result.name == value.name,
                    'autocomplete-active':
                        currentFocus == i && result.name != value.name,
                    choosedFocus:
                        currentFocus == i && result.name == value.name,
                }"
            >
                {{ value.name }}
            </div>
        </div>
    </div>
</template>

<script>
import { MESSAGE } from "../../constants/message";
export default {
    name: "BaseCombobox",
    $emit: ["result"],
    props: {
        comboboxId: { type: String },
        inputId: { type: String },
        data: { type: Array, required: false, default: () => [] },
        border: {
            type: String,
            default: "block",
        },
        choosed: { type: Object, default: () => {} },
        required: { type: Boolean, default: false },
        tabindex: Number,
        placeholder: String,
        width: { type: Number, default: 200 },
        bold: { type: Boolean, default: false },
        fieldName: String,
    },
    data() {
        return {
            currentFocus: -1,
            showOption: false,
            isTrue: false,
            error: false,
            options: [],
            search: this.choosed?.name || this.data[0]?.name,
            result: this.choosed || this.data[0],
            clicked: false,
            msg: "",
        };
    },
    watch: {
        result() {
            this.$emit("result", this.result);
            return this.result;
        },
        choosed() {
            this.$emit("update:choosed", this.choosed);
            this.search = this.choosed?.name;
            this.result = { ...this.choosed };
        },
        error() {
            if (this.error) {
                if (this.fieldName == "Department")
                    this.msg = MESSAGE.VALIDATE_ERROR_DEPARTMENT;
            } else this.msg = "";
        },
    },
    created() {
        let vm = this;
        window.addEventListener("click", (event) => {
            if (!this.$el.contains(event.target)) {
                vm.showOption = false;
                vm.isTrue = false;
                if (this.required && this.clicked) {
                    if (this.search == "" || !this.search) {
                        this.error = true;
                    } else this.error = false;
                } else {
                    this.error = false;
                    this.isTrue = false;
                }
            }
        });
        this.options = [...this.data];
    },
    methods: {
        /**
         * Lọc các option thoả mãn key word
         */
        filterRS() {
            let keyWord = this.search;
            if (!keyWord) keyWord = "";
            this.options = this.data.filter((item) => {
                return item.name
                    ?.toLowerCase()
                    .includes(keyWord?.toLowerCase());
            });
        },
        /**
         * Sự kiện khi click vào combobox
         */
        clickInput: function () {
            this.clicked = true;
            //hiển thị viền xanh cho combobox
            this.isTrue = true;
            //hiển thị options box
            this.showOption = true;
            //focus cho input
            this.$refs.BaseInput.focus();
            this.filterRS();
        },
        clickIcon: function () {
            //hiển thị viền xanh cho combobox
            this.isTrue = true;
            //hiển thị options box
            this.showOption = !this.showOption;
            if (this.showOption) {
                //focus cho input
                this.$refs.BaseInput.focus();
                this.filterRS();
            }
        },
        /**
         * Sự kiện khi nhấn chọn 1 option
         */
        choosedOption: function (option) {
            //hiển thị nội dung của option được chọn lên combobox
            this.search = option?.name;
            this.result = { ...option };
            //ẩn options box
            this.showOption = false;
            this.isTrue = false;
            this.error = false;
        },
        /**
         * Sự kiện khi nhấn nút enter
         */
        enter: function () {
            //kiểm tra xem option hiện tại đang được focus có nằm trong khoảng thoả mãn
            if (this.currentFocus > -1 && this.options.length) {
                this.$refs.option[this.currentFocus].click();
                this.currentFocus = 0;
            }
        },
        down: function () {
            //nếu nhấn xuống
            this.currentFocus++;
            //kiểm tra currentfocus có nằm trong khoảng cho phép không
            //nếu không thì đặt lại
            //và hiển thị nền cho option hiện tại
            if (this.options.length) {
                //nếu currentFocus lớn hơn số lượng các option thoả mãn
                //thì đặt lại bằng 0
                if (this.currentFocus >= this.options.length)
                    this.currentFocus = 0;
                //nếu currentFocus < 0
                //thì đặt lại bằng số lượng các option thoả mãn -1
                if (this.currentFocus < 0)
                    this.currentFocus = this.options.length - 1;
            }
        },
        /**
         * Sự kiện khi nhấn lên
         */
        up: function () {
            //nếu nhấn lên
            this.currentFocus--;
            if (this.options.length) {
                if (this.currentFocus >= this.options.length)
                    this.currentFocus = 0;
                if (this.currentFocus < 0)
                    this.currentFocus = this.options.length - 1;
            }
        },
        input: function () {
            //ẩn những option không chứa keyword và hiển thị những option thoả mãn
            this.filterRS();
            this.result = {};
            if (!this.search) {
                if (this.required) this.error = true;
                else this.error = false;
            } else {
                //nếu option box rỗng
                if (this.options.length == 0) {
                    //ẩn option box
                    this.showOption = false;
                    if (this.required) this.error = true;
                } else {
                    //nếu có hiện viền xanh
                    this.showOption = true;
                    this.error = false;
                    this.isTrue = true;
                }
            }
        },
    },
};
</script>
<style lang="css" scoped>
@import url("../../css/base/combobox.css");
@import url("../../css/common/flex.css");
.border-focus {
    border: 1px solid #2ca01c;
    border-radius: 2px;
}
.notice-border {
    border: 1px solid red;
    border-radius: 2px;
}
</style>