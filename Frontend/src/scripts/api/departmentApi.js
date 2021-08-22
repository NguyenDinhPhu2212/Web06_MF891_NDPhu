import { BaseApi } from "./baseApi.js";
import { API } from "../../constants/api.js";
class DepartmentApi extends BaseApi {
    constructor() {
        super(API.DEPARTMENT);
        this.data = [];
    }
    /**
     * Lấy ra danh sách các phòng ban
     * @returns Danh sách các phòng ban
     */
    async getDepartment() {
        let response = await this.get();
        for (let item of response.Data) {
            let tmp = {
                id: item.DepartmentId,
                name: item.DepartmentName,
            };
            this.data.push(tmp);
        }
        return this.data;
    }
}
export const departmentApi = new DepartmentApi();
