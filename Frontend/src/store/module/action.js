import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);
import {ACTION} from "../../constants/action"
export const action = {
    state: {
        action: "",
    },
    getters: {
        /**
         * Lấy ra hành động đang thực hiện
         * @param {*} state
         * @returns hành động
         */
        getAction: (state) => {
            return state.action;
        },
    },
    mutations: {
        /**
         * Set lại hành động
         * @param {*} state
         * @param {string} action
         */
        setAction: (state, action) => {
            state.action = action;
        },
    },
    actions: {
        executePost: ({ commit }) => {
            commit("setAction", ACTION.POST);
        },
        executeUpdate: ({ commit }) => {
            commit("setAction", ACTION.UPDATE);
        },
        executeDelete: ({ commit }) => {
            commit("setAction", ACTION.DELETE);
        },
    },
};
