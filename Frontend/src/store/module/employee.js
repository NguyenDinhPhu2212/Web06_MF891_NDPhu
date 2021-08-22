import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);
import * as utils from "../../scripts/utils";
import { toast } from "./toast.js";
import { loader } from "./loader";
import { employeeApi } from "../../scripts/api/employeeApi";
import { TOAST } from "../../constants/toast";
export const employee = {
    modules: { toast, loader },
    state: {
        employeeList: [],
        executeData: {},
        filter: {
            pageSize: 10,
            pageNumber: 0,
            employeeFilter: "NV",
            departmentId: "",
            positionId: "",
        },
        totalPage: 0,
        totalRecord: 0,
        serviceResult: {},
        newCode: false,
    },
    getters: {
        /**
         * Lấy ra danh sách các nhân viên đang được hiển thị
         * @param {*} state
         * @returns Danh sách các nhân viên đang được hiển thị
         */
        getEmployee: (state) => {
            return state.employeeList;
        },
        /**
         * Lấy ra thông tin nhân viên đang được thực thi (xóa, thêm, cập nhật)
         * @param {*} state
         * @returns Thông tin nhân viên đang được thực thi (xóa, thêm, cập nhật)
         */
        getExecuteData: (state) => {
            return state.executeData;
        },
        /**
         * Lấy ra thông tin bộ lọc
         * @param {*} state
         * @returns Thông tin bộ lọc
         */
        getFilter: (state) => {
            return state.filter;
        },
        /**
         * Lấy ra tổng số trang
         * @param {*} state
         * @returns Tổng số trang
         */
        getTotalPage: (state) => {
            return state.totalPage;
        },
        /**
         * Lấy ra tổng số bản ghi
         * @param {*} state
         * @returns Tổng số bản ghi
         */
        getTotalRecord: (state) => {
            return state.totalRecord;
        },
        /**
         * Lấy ra kết quả result
         */
        getServiceResult: (state) => {
            return state.serviceResult;
        },
        getNewCode:(state)=>{
            return state.newCode;
        }
    },
    mutations: {
        /**
         * Cài đặt danh sách các nhân viên được hiển thị
         * @param {*} state
         * @param {Array} array Danh sách các nhân viên được hiển thị
         */
        setEmployee: (state, array) => {
            state.employeeList = [...array];
        },
        /**
         * Set thông tin được thực thi (thêm, sửa, xóa)
         * @param {*} state
         * @param {Object} obj Thông tin nhân viên được thực thi
         */
        setExecuteData: (state, obj) => {
            state.executeData = { ...obj };
        },
        /**
         * Đặt lại thông tin bộ lọc
         * @param {*} state
         * @param {Object} obj Thông tin bộ lọc
         */
        setFilter: (state, obj) => {
            state.filter = { ...obj };
        },
        /**
         * Cài đặt lại tổng số trang
         * @param {*} state
         * @param {*} num Số trang
         */
        setTotalPage: (state, num) => {
            state.totalPage = num;
        },
        /**
         * Đặt lại tổng số bản ghi
         * @param {*} state
         * @param {*} num Số bản ghi
         */
        setTotalRecord: (state, num) => {
            state.totalRecord = num;
        },
        /**
         * Thay đổi một thuộc tính của employee
         * @param {*} state
         * @param {string} attr Thuộc tính cần thay đổi
         * @param {*} value Giá trị mới
         */
        changeAttribute: (state, attr, value) => {
            state.executeData[attr] = value;
        },
        /**
         * Set lại kết quả result
         */
        setServiceResult: (state, serviceRs) => {
            state.serviceResult = { ...serviceRs };
        },
        setNewCode: (state, bool)=>{
            state.newCode = bool;
        }
    },
    actions: {
        /**
         * Lọc nhân viên theo trang
         * @param {Object} param0 Thông tin bộ lọc
         */
        employeeFilter: async ({ getters, commit }) => {
            // hiển thị loader
            commit("setLoading", true);
            // tiến hành lọc
            let filter = { ...getters.getFilter };
            let response = await employeeApi.getEmployeeFilter(filter);
            // training dữ liệu
            for (let i in response.Data) {
                utils.trainingData(response.Data[i]);
            }
            // Cập nhật lại số trang
            commit("setTotalPage", response.TotalPage);
            // Cập nhật lại số bản ghi
            commit("setTotalRecord", response.TotalRecord);
            // cập nhật danh sách nhân viên hiển thị
            commit("setEmployee", response.Data);
            // ẩn loader
            commit("setLoading", false);
        },
        /**
         * Lấy ra tất cả nhân viên
         * @param {*} param0
         */
        get: async ({ commit }) => {
            // hiển thị loader
            commit("setLoading", true);
            let response = await employeeApi.get();
            // training dữ liệu
            for (let i in response.Data) {
                utils.trainingData(response.Data[i]);
            }
            // cập nhật danh sách nhân viên hiển thị
            commit("setEmployee", response.Data);
            commit("setLoading", false);
        },
        /**
         * Cập nhật thông tin người dùng
         * @param {*} param0
         */
        update: async ({ commit, state, dispatch }) => {
            try {
                let response = await employeeApi.update(state.executeData);
                commit("setServiceResult", response)
                if (response.Success) {
                    commit("addToast", TOAST.SUCCESS_UPDATE);
                    dispatch("employeeFilter");
                }
            } catch (error) {
                commit("addToast", TOAST.DENY);
            }
        },
        /**
         * Xóa thông tin nhân viên
         * @param {*} param0
         */
        delete: async ({ commit, state, dispatch }) => {
            try {
                await employeeApi.delete(state.executeData.EmployeeId);
                commit("setDialog", false);
                commit("addToast", TOAST.SUCCESS_DELETE);
                dispatch("employeeFilter");
            } catch (error) {
                console.log(error.message);
                commit("addToast", TOAST.DENY);
            }
        },
        /**
         * Thêm mới thông tin nhân viên
         * @param {*} param0
         */
        post: async ({ commit, state, dispatch }) => {
            try {
                let response = await employeeApi.post(state.executeData);
                commit("setServiceResult", response)
                if (response.Success) {
                    commit("addToast", TOAST.SUCCESS_CREATE);
                    dispatch("employeeFilter");
                }
            } catch (error) {
                commit("addToast", TOAST.DENY);
            }
        },
    },
};
