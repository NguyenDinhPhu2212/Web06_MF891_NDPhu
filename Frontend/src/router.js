import Vue from "vue";
import VueRouter from "vue-router";

import ThePage from "./components/layout/ThePage.vue";
Vue.use(VueRouter);

const router = new VueRouter({
    mode: "history",
    routes: [
        {
            path: "/employee",
            name: "Report",
            component: ThePage,
        },
        {
            path: "/other",
            name: "Other",
            component: {
                render(h) {
                    return h("div", "Chức năng chưa được hoàn thiện.");
                },
            },
        },
    ],
});
export default router;
