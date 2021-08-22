<template>
    <div class="toast-group">
        <transition-group name="list" tag="div">
            <ToastMessage
                v-for="(toast, index) in toastGroup"
                :key="index"
                :toast="{ data: toast, index: index }"
                class="list-item"
            ></ToastMessage>
        </transition-group>
    </div>
</template>

<script>
import ToastMessage from "./ToastMessage.vue";
export default {
    name: "ToastGroup",
    components: { ToastMessage },
    computed: {
        toastGroup: function () {
            return this.$store.getters.getToast;
        },
    },
};
</script>
<style scoped>
.toast-group {
    position: absolute;
    top: 10px;
    left: calc(50% - 150px);
    z-index: 1000;
}
.list-item {
    margin: 5px auto;
    transition: all 0.5s;
}
.list-enter-active,
.list-leave-active {
    transition: all 0.5s ease;
}
.list-leave-active {
    position: absolute;
}
.list-enter,
.list-leave-to {
    opacity: 0;
    transform: translateY(-50px);
}
</style>