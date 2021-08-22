<template>
    <div class="gender-radio notosans-regular">
        <label class="notosans-bold">Giới tính</label>
        <div class="radio-group">
            <CustomRadio
                v-for="(gender, index) in data"
                :key="index"
                name="gender"
                :label="gender.name"
                :choosed="choosed == gender.id ? true : false"
                @choosedRadio="(e) => choosedRadio(e)"
                :data="gender.id.toString()"
                class="m-r-10"
            ></CustomRadio>
        </div>
    </div>
</template>

<script>
import { GENDER } from "../../constants/gender.js";
export default {
    name: "GenderRadio",
    props: {
        gender: Number,
    },
    data() {
        return {
            choosed: -1,
            data: GENDER,
        };
    },
    watch: {
        // Emit kết quả
        choosed: function () {
            this.$emit("result", this.choosed);
        },
        gender: function () {
            this.choosed = this.gender;
        },
    },
    methods: {
        // Cập lại lựa chọn khi click vào radio
        choosedRadio: function (e) {
            this.choosed = parseInt(e.currentTarget.getAttribute("data"));
        },
    },
};
</script>
<style lang="css" scoped>
@import url("../../css/common/font.css");
label {
    margin-bottom: 5px;
    margin-left: 15px;
}
.gender-radio {
    width: 100%;
}
.gender-radio .radio-group {
    display: flex;
    align-items: center;
}
.m-r-10 {
    margin-right: 10px;
}
</style> 