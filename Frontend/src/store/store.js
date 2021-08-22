import Vue from "vue";
import Vuex from "vuex";
import { employee } from "./module/employee";
import {action} from "./module/action"
Vue.use(Vuex);
export const store = new Vuex.Store({
    strict: true,
    modules: {
        employee,action
    },
    state: {
        dialog: false,
        contextMenu: {
            display: false,
            top: 0,
            left: 0,
        },
        popup: {
            display: false,
            type: {},
        },
        currentRow: -1,
        allChecked: false,
        action: "post",
    },
    getters: {
        /**
         * Lấy ra trạng thái của context menu
         * @param {*} state
         * @returns Trạng thái của context menu
         */
        getContextMenu: (state) => {
            return state.contextMenu;
        },
        /**
         * Lấy ra trạng thái của Popup
         * @param {*} state
         * @returns Trạng thái của popup
         */
        getPopup: (state) => {
            return state.popup;
        },
        /**
         * Lấy ra trạng thái của dialog
         * @param {*} state
         * @returns Trạng thái của dialog
         */
        getDialog: (state) => {
            return state.dialog;
        },
        /**
         * Lấy ra thứ tự của hàng đang được nhấn contextmenu
         * @param {*} state 
         * @returns Thứ tự của hàng
         */
        getCurrentRow: (state) => {
            return state.currentRow;
        },
        /**
         * Lấy ra giá trị xem có checked tất cả các checkbox trong bảng
         * @param {*} state 
         * @returns 
         */
        getAllChecked: (state) => {
            return state.allChecked;
        },
    },
    mutations: {
        /**
         * Cài đặt trạng thái của context menu
         * @param {*} state
         * @param {*} obj Trạng thái của context menu gồm display, left, top
         */
        setContextMenu: (state, obj) => {
            state.contextMenu = { ...obj };
        },
        /**
         * Cài đặt trạng thái cho popup
         * @param {*} state
         * @param {*} obj Trạng thái của popup gồm boolean display, object type
         */
        setPopup: (state, obj) => {
            state.popup = { ...obj };
        },
        /**
         * Cài đặt lại trạng thái hiển thị của dialog
         * @param {*} state
         * @param {Boolean} bool true/false
         */
        setDialog: (state, bool) => {
            state.dialog = bool;
        },
        /**
         * Đặt lại thứ tự hàng đang được nhấn contextmenu
         * @param {*} state 
         * @param {*} num Thứ tự của hàng
         */
        setCurrentRow: (state, num) => {
            state.currentRow = num;
        },
        /**
         * Đặt lại xem có checked tất cả checkbox trong table hay không
         * @param {*} state 
         * @param {Boolean} bool 
         */
        setAllChecked: (state, bool) => {
            state.allChecked = bool;
        },
    },
});
