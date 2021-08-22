import axios from "axios";
export class BaseApi {
    constructor(base_url) {
        this.base_url = base_url;
    }
    /**
     * Lấy tất cả các bản ghi trong api
     * @returns Tất cả các bản ghi trong api
     */
    async get() {
        let data = {};
        await axios.get(this.base_url).then((response) => {
            data = { ...response };
        });
        return data.data;
    }
    /**
     * Cập nhật thông tin dựa vào id định danh
     * @param {string} id Định danh của thông tin
     * @param {object} entity Thông tin sau khi được sửa đổi
     * @returns Trả về response của api
     */
    async update(entity) {
        let response = {};
        try {
            response = await axios.put(this.base_url, entity);
        } catch (error) {
            response = error;
        }
        return response.data;
    }
    /**
     * Thêm mới thông tin vào database
     * @param {object} entity
     * @returns response
     */
    async post(entity) {
        let response = {};
        try {
            response = await axios.post(this.base_url, entity);
        } catch (error) {
            response = error;
        }
        return response.data;
    }
    /**
     * Xóa bản ghi theo định danh id
     * @param {string} id
     * @returns response
     */
    async delete(id) {
        let response = {};
        try {
            response = await axios.delete(this.base_url + "/" + id);
        } catch (error) {
            response = error;
        }
        return response.data;
    }
}
