import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);
export const loader = {
    state: {
        loading: false,
    },
    getters: {
        /**
         * Lấy ra trạng thái hiển thị của loader
         * @param {*} state 
         * @returns Boolean (Trạng thái hiển thị của loader)
         */
        getLoading: (state) => {
            return state.loading;
        },
    },
    mutations: {
        /**
         * Cài đặt trạng thái hiển thị của loader
         * @param {*} state 
         * @param {Boolean} bool Trạng thái hiển thị của loader
         */
        setLoading: (state, bool) => {
            state.loading = bool;
        },
    },
};