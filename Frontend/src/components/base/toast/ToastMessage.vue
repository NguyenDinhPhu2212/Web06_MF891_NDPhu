<template>
    <div
        class="toast-message"
        :style="{ 'background-color': toast.data.color }"
    >
        <div
            class="message-content"
            v-html="toast.data.content"
            style="color: white"
        ></div>
        <div class="x-btn exit-icon" @click="clicked"></div>
    </div>
</template>
<style scoped>
@import url("../../../css/base/message.css");
.exit-icon {
    background: url("../../../assets/resource/img/Sprites.64af8f61.svg")
        no-repeat -931px -147px;
    width: 18px;
    height: 18px;
}
</style>
<script>
import { TIME } from "../../../constants/time";
export default {
    name: "ToastMessage",
    props: {
        toast: { type: Object, default: () => {} },
    },
    data() {
        return {};
    },
    //tự động xoá toast khỏi mảng sau 3s
    mounted() {
        let vm = this;
        setTimeout(function () {
            vm.$store.commit("deleteToast", vm.toast.index);
        }, TIME.TOAST_DURATION);
    },
    methods: {
        //sự kiện khi nhấn tắt toast message
        clicked: function () {
            this.$store.commit("deleteToast", this.toast.index);
        },
    },
};
</script>