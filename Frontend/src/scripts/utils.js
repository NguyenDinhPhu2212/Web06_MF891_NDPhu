import { departmentApi } from "./api/departmentApi";
import { GENDER } from "../constants/gender";
/**
 * Định dạng ngày thành chuỗi dạng "dd/mm/yyyy"
 * @param {any} date : chuỗi ngày cần định dạng
 * @returns chuổi string date đã được định dạng
 */
export function formatDate(date) {
    let formatedDate = "";
    let response = new Date(date);
    if (!date) {
        return "";
    }
    if (response.getDate() < 10) formatedDate += "0";
    formatedDate += response.getDate();
    if (response.getMonth() < 9) formatedDate += "/0";
    else formatedDate += "/";
    formatedDate += response.getMonth() + 1;
    formatedDate += "/" + response.getFullYear();
    return formatedDate;
}

/**
 * Tranning dữ liệu nhận được từ api
 * @param {aby} object : object cần training
 * @returns object đã được train
 */
export function trainingData(object) {
    // training dữ liệu theo từng trường
    for (let attribute in object) {
        // Training nếu thuộc các trường đặc biệt sau
        switch (attribute) {
            case "JoinDate":
                object.JoinDate = formatDate(object.JoinDate);
                break;
            case "DateOfBirth":
                if (object.DateOfBirth)
                    object.DateOfBirth = formatDate(object.DateOfBirth);
                break;
            case "Gender":
                if (parseInt(object.Gender) >= 2) object.Gender = 2;
                if (
                    parseInt(object.Gender) >= 0 &&
                    parseInt(object.Gender) <= 2
                )
                    object.GenderName = GENDER[parseInt(object.Gender)].name;
                break;
            case "DepartmentId":
                object.DepartmentName = departmentApi.data.find((value) => {
                    return value.id == object.DepartmentId;
                }).name;
                break;
            case "IdentityDate":
                object.IdentityDate = formatDate(object.IdentityDate);
                break;
        }
    }
    return object;
}
