import { BaseApi } from "./baseApi.js";
import { API } from "../../constants/api.js";
import axios from "axios";
class EmployeeApi extends BaseApi {
    constructor() {
        super(API.EMPLOYEE);
    }
    /**
     * Lấy mã nhân viên mới
     * @returns Mã nhân viên mới
     */
    async newCode() {
        let newCode = null;
        await axios.get(this.base_url + "/MaxEmployeeCode").then((response) => {
            newCode = response.data.Data;
        });
        let path = newCode.split("-");
        if (path.length == 2) {
            path[1] = parseInt(path[1]) + 1;
            newCode = path[0] + "-" + path[1];
        } else {
            let first = path.slice(0, 2);
            let last = parseInt(path.slice(2)) + 1;
            newCode = first + "-" + last;
        }
        return newCode;
    }
    /**
     * Lọc phân trang danh sách nhân viên theo các tiêu chí
     * @param {object} param0
     * @returns Dữ liệu chứa totalPage, totalRecord và Data
     */
    async getEmployeeFilter({ pageSize, pageIndex, employeeFilter } = {}) {
        let response = {};
        let filterPath = "";
        if (pageSize) filterPath += "pageSize=" + pageSize;
        if (pageIndex) filterPath += "&pageIndex=" + pageIndex;
        if (employeeFilter) filterPath += "&employeeFilter=" + employeeFilter;
        try {
            response = await axios.get(
                this.base_url + "/EmployeeFilter?" + filterPath
            );
        } catch (error) {
            console.log(error);
        }
        return response.data.Data;
    }
    /**
     * Kiểm tra trùng lặp mã nhân viên
     * @param {Mã nhân viên} employeeCode
     * @returns true-nếu mã nhân viên đã tồn tại, false-nếu không
     */
    async checkDuplicateCode(employeeCode) {
        let response;
        try {
            response = await axios.get(
                this.base_url + "/Duplicate/" + employeeCode
            );
        } catch (error) {
            console.log(error);
        }
        return response.data.Data;
    }
}
export const employeeApi = new EmployeeApi();
