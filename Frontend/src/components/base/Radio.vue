<template>
    <div class="center" @click="choosedRadio" :data="data">
        <label class="container">
            <input type="radio" :name="name" />
            <span :class="['checkmark', { 'green-border': display }]">
                <span class="checked-container">
                    <span class="checked-icon" v-if="display"></span>
                </span>
            </span>
            <span
                ><div style="margin-left: 25px">{{ label }}</div></span
            >
        </label>
    </div>
</template>

<script>
export default {
    name: "CustomRadio",
    props: {
        label: { type: String, default: "" },
        name: { type: String },
        choosed: { type: Boolean, default: false },
        data: String,
    },
    data() {
        return {
            display: false,
        };
    },
    watch: {
        choosed: function () {
            this.display = this.choosed;
        },
    },
    methods: {
        // Emit event khi nhân vào Radio
        choosedRadio: function (event) {
            this.$emit("choosedRadio", event);
        },
    },
};
</script>
<style lang="css" scoped>
@import url("../../css/common/font.css");
.center {
    display: flex;
    justify-content: center;
    align-items: center;
    margin: auto !important;
    height: 32px;
}
/* The container */
.container {
    display: flex;
    justify-content: center;
    align-items: center;
    cursor: pointer;
    font-size: 13px;
    font-family: "notosans-regular", sans-serif !important;
    position: relative;
}

/* Hide the browser's default checkbox */
.container input {
    position: absolute;
    opacity: 0;
    cursor: pointer;
    height: 0;
    width: 0;
}

/* Create a custom checkbox */
.checkmark {
    position: absolute;
    top: 0;
    left: 0;
    height: 16px;
    width: 16px;
    background-color: #fff;
    border: 1px solid #bbb;
    border-radius: 50%;
}
.green-border {
    border-color: #2ca01c !important;
}
.checkmark .checked-container {
    height: 16px;
    width: 16px;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50%;
}
.checked-icon {
    height: 12px;
    width: 12px;
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 50%;
    background: #2ca01c;
}
</style> 