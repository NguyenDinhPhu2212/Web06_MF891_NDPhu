<template>
    <div class="customBtn" @click="clicked">
        <div class="button-icon" v-if="show"></div>
        <div class="btnContent">{{ btnContent }}</div>
    </div>
</template>
<style lang="css" scoped>
@import url("../../css/base/button.css");
</style> 
<script>
export default {
    name: "BaseButton",
    props: {
        btnContent: { required: true, type: String },
        showIcon: { default: true, type: Boolean },
    },
    data() {
        return {
            show: this.showIcon,
        };
    },
    methods: {
        // Chuyển sự kiện lên cha
        //created by Phú
        clicked: function () {
            this.$emit("clicked");
        },
    },
};
</script>
