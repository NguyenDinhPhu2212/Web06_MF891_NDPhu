import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);

export const toast = {
    state: {
        toastGroup: [],
    },
    getters: {
        /**
         * Lấy ra mảng các toast message
         * @param {*} state 
         * @returns Mảng các toast message
         */
        getToast: (state) => {
            return state.toastGroup;
        },
    },
    mutations: {
        /**
         * Thêm mới toast message vào mảng
         * @param {*} state 
         * @param {object} obj Toast message mới
         */
        addToast: (state, obj) => {
            state.toastGroup.push(obj);
        },
        /**
         * Xóa toast message tại vị trí index
         * @param {*} state 
         * @param {int} index vị trí muốn xóa
         */
        deleteToast(state, index) {
            state.toastGroup.splice(index, 1);
            state.toastGroup = [...state.toastGroup];
        },
    },
};