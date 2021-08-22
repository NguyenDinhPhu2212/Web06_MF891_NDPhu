<template>
    <div id="employee" class="notosans-regular">
        <div style="display: flex; height: 100%; width: 100vw">
            <TheMenu />
            <router-view></router-view>
        </div>
    </div>
</template>
 <style lang="css" scoped>
@import url("../../css/common/flex.css");
@import url("../../css/common/font.css");
#employee {
    height: 100vh;
    width: 100vw;
    position: relative;
    font-family: "notosans-regular", sans-serif !important;
    color: #111;
    -moz-user-select: none;
    -ms-user-select: none;
    -khtml-user-select: none;
    -webkit-user-select: none;
    -webkit-touch-callout: none;
}
</style>
 <script>
import TheMenu from "../../components/layout/TheMenu.vue";
export default {
    name: "Employee",
    components: {
        TheMenu,
    },
    props: {},
    data() {
        return {
        };
    },

    methods: {
    },
};
</script>