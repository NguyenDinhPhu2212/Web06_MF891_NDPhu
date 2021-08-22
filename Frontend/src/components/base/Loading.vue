<template>
    <div class="loading" v-show="loading">
        <div class="loader">
            <object :data="loaderUrl"></object>
        </div>
    </div>
</template>

<script>
export default {
    name: "Loading",
    computed: {
        loading: function () {
            return this.$store.getters.getLoading;
        },
    },
    data() {
        return {
            loaderUrl: require("../../assets/resource/loading.svg"),
        };
    },
};
</script>
<style scoped>
.loading {
    width: 100%;
    height: 100%;
    position: absolute;
    top: 0;
    z-index: 10000;
    background-color: rgba(186, 186, 186, 0.3);
    display: flex;
    justify-content: center;
    align-items: center;
}
.loader {
    /* background: url("../../assets/resource/loading.svg") no-repeat; */
    width: 40px;
    height: 40px;
}
</style>