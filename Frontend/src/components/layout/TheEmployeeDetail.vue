<template>
    <div
        class="employee-information-form"
        v-show="this.$store.getters.getDialog"
    >
        <div class="employee-detail">
            <div class="form-header flex-space-between">
                <div class="flex">
                    <div class="form-header-title notosans-bold p-r-6">
                        Thông tin nhân viên
                    </div>
                    <div class="flex">
                        <CustomCheckBox
                            label="Là khách hàng"
                            style="padding-right: 32px"
                        ></CustomCheckBox>
                        <CustomCheckBox
                            label="Là nhà cung cấp"
                        ></CustomCheckBox>
                    </div>
                </div>
                <div class="flex">
                    <div class="flex" style="padding: 12px">
                        <div class="help-button p-r-6">
                            <div class="help-icon"></div>
                        </div>
                        <div class="exit-button" @click="clickExitBtn">
                            <div class="exit-icon"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="employee-detail-content">
                <div class="employee-information">
                    <div class="flex-align-center mb-16">
                        <div class="column p-r-26">
                            <div class="flex-justify-space-between mb-16">
                                <div class="width-40 p-r-6">
                                    <BaseInput
                                        label="Mã"
                                        :required="true"
                                        :tabindex="1"
                                        fieldName="Code"
                                        v-model="currentEmployee.EmployeeCode"
                                        ref="Code"
                                    />
                                </div>
                                <div class="width-60">
                                    <BaseInput
                                        label="Tên"
                                        :required="true"
                                        :tabindex="2"
                                        fieldName="Name"
                                        v-model="currentEmployee.EmployeeName"
                                        ref="Name"
                                    />
                                </div>
                            </div>
                            <div class="flex-column mb-16">
                                <label for="department"
                                    >Đơn vị
                                    <span style="color: red">*</span></label
                                >
                                <BaseCombobox
                                    class="width-100"
                                    fieldName="Department"
                                    :required="true"
                                    :data="dataDepartment"
                                    :tabindex="3"
                                    :choosed="{
                                        ...{
                                            id: currentEmployee.DepartmentId,
                                            name: currentEmployee.DepartmentName,
                                        },
                                    }"
                                    @result="
                                        (result) =>
                                            getData(result, 'department')
                                    "
                                    ref="Department"
                                />
                            </div>
                            <div class="width-100 mb-16">
                                <BaseInput
                                    label="Chức danh"
                                    :tabindex="4"
                                    v-model="currentEmployee.EmployeePosition"
                                    ref="Position"
                                />
                            </div>
                        </div>
                        <div class="column">
                            <div class="flex-justify-space-between mb-16">
                                <div class="width-40 p-r-6">
                                    <BaseInput
                                        label="Ngày sinh"
                                        :tabindex="5"
                                        type="date"
                                        v-model="currentEmployee.DateOfBirth"
                                        ref="DateOfBirth"
                                    />
                                </div>
                                <div class="width-60 flex-column">
                                    <GenderRadio
                                        :gender="currentEmployee.Gender"
                                        @result="
                                            (result) =>
                                                getData(result, 'gender')
                                        "
                                    />
                                </div>
                            </div>
                            <div class="flex-justify-space-between mb-16">
                                <div class="width-60 p-r-6">
                                    <BaseInput
                                        label="Số CMND"
                                        :tabindex="7"
                                        v-model="currentEmployee.IdentityNumber"
                                        fieldName="Identity"
                                        ref="Identity"
                                    />
                                </div>
                                <div class="width-40">
                                    <BaseInput
                                        type="date"
                                        label="Ngày cấp"
                                        :tabindex="8"
                                        v-model="currentEmployee.IdentityDate"
                                        ref="IdentityDate"
                                    />
                                </div>
                            </div>
                            <div class="width-100 mb-16">
                                <BaseInput
                                    label="Nơi cấp"
                                    :tabindex="9"
                                    v-model="currentEmployee.IdentityPlace"
                                    ref="IdentityPlace"
                                />
                            </div>
                        </div>
                    </div>
                    <div class="flex-column">
                        <div class="width-100 mb-16">
                            <BaseInput
                                label="Địa chỉ"
                                :tabindex="10"
                                v-model="currentEmployee.Address"
                                ref="Address"
                            />
                        </div>
                        <div class="flex-align-center mb-16">
                            <div class="width-25 p-r-6">
                                <BaseInput
                                    label="ĐT di động"
                                    :tabindex="11"
                                    v-model="currentEmployee.PhoneNumber"
                                    fieldName="PhoneNumber"
                                    ref="PhoneNumber"
                                />
                            </div>
                            <div class="width-25 p-r-6">
                                <BaseInput
                                    label="ĐT cố định"
                                    :tabindex="12"
                                    v-model="currentEmployee.TelephoneNumber"
                                    ref="TelephoneNumber"
                                />
                            </div>
                            <div class="width-25">
                                <BaseInput
                                    label="Email"
                                    :tabindex="13"
                                    v-model="currentEmployee.Email"
                                    fieldName="Email"
                                    ref="Email"
                                />
                            </div>
                        </div>
                        <div class="flex-align-center mb-16">
                            <div class="width-25 p-r-6">
                                <BaseInput
                                    label="Tài khoản ngân hàng"
                                    :tabindex="14"
                                    v-model="currentEmployee.BankAccountNumber"
                                    ref="BankAccountNumber"
                                />
                            </div>
                            <div class="width-25 p-r-6">
                                <BaseInput
                                    label="Tên ngân hàng"
                                    :tabindex="15"
                                    v-model="currentEmployee.BankName"
                                    ref="BankName"
                                />
                            </div>
                            <div class="width-25">
                                <BaseInput
                                    label="Chi nhánh"
                                    :tabindex="16"
                                    v-model="currentEmployee.BankBranchName"
                                    ref="BankBranchName"
                                />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="margin: 32px">
                <hr />
                <div class="footer flex-justify-space-between">
                    <div class="destroy-button btn" @click="destroyEvent">
                        Hủy
                    </div>
                    <div class="flex-align-center">
                        <div
                            class="btn"
                            style="margin-right: 10px"
                            @click="storeEvent"
                        >
                            Cất
                        </div>

                        <div class="button save-button" @click="clickSaveBtn">
                            Cất và thêm
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
@import url("../../css/common/font.css");
@import url("../../css/common/flex.css");
@import url("../../css/layout/detail.css");
@import url("../../css/common/icon.css");
@import url("../../css/common/width.css");
.employee-information-form {
    font-family: "notosans-regular", sans-serif;
    font-size: 13px;
    font-weight: 400;
}
.employee-information-form div > label:first-child {
    font-family: "notosans-bold", sans-serif !important;
}
.mb-16 {
    margin-bottom: 16px;
}
.p-r-6 {
    padding-right: 6px;
}
.p-r-26 {
    padding-right: 26px;
}
</style>

<script>
import { mapMutations, mapActions, mapGetters } from "vuex";
// import { MESSAGE } from "../../constants/message";
import { POPUP } from "../../constants/popup";
import { ACTION } from "../../constants/action";
import { employeeApi } from "../../scripts/api/employeeApi";
import GenderRadio from "./GenderRadio.vue";
export default {
    name: "TheEmployeeDetail",
    components: {
        GenderRadio,
    },
    props: {
        data: Object,
        dataDepartment: Array,
    },
    data() {
        return {
            newEmployeeCode: "",
            initEmployeeCode: this.data.EmployeeCode,
            gender: 0,
            departmentId: "",
            departmentName: "",
        };
    },
    async updated() {
        if (this.$store.getters.getNewCode) {
            await this.getNewCode();
        }
        this.$refs["Code"].$refs.BaseInput.focus();
    },
    computed: {
        //format lại dateString
        currentEmployee: function () {
            return {
                ...this.data,
                DateOfBirth: this.formatDate(this.data?.DateOfBirth),
                IdentityDate: this.formatDate(this.data?.IdentityDate),
                JoinDate: this.formatDate(this.data?.JoinDate),
            };
        },
        ...mapGetters({
            action: "getAction",
            getServiceResult: "getServiceResult",
            getExecuteData: "getExecuteData",
        }),
    },
    methods: {
        ...mapMutations({
            setPopup: "setPopup",
            setExecuteData: "setExecuteData",
            addToast: "addToast",
            setDialog: "setDialog",
            setAction: "setAction",
            setNewCode: "setNewCode",
        }),
        ...mapActions({
            update: "update",
            post: "post",
            executePost: "executePost",
        }),
        /**
         * Sự kiện khi nhấn nút exit của form
         */
        clickExitBtn: function () {
            this.setNewCode(false);
            let exeData = this.getExecuteData;
            this.getDataFromForm();
            let valid = true;
            if (
                exeData.EmployeeCode != this.currentEmployee.EmployeeCode ||
                this.action == ACTION.POST
            ) {
                valid = false;
            }
            this.$emit("checkDuplicate", {
                valid: valid,
                data: this.currentEmployee.EmployeeCode,
            });
            if (!this.checkChangeData()) this.setPopup(POPUP.STORE_POPUP);
            else this.setDialog(false);
            Object.entries(this.$refs).forEach((component) => {
                component[1].error = false;
                component[1].clicked = false;
            });
        },
        /**
         * Sự kiện khi nhấn nút hủy
         */
        destroyEvent: function () {
            this.setNewCode(false);
            this.setDialog(false);
            this.refreshForm();
        },
        /**
         * Sự kiện khi nhấn nút cất
         */
        storeEvent: async function () {
            let serviceRs = await this.execute();
            if (serviceRs != null) {
                this.setNewCode(false);
                this.setDialog(false);
                this.refreshForm();
            }
        },
        /**
         * Sự kiện khi nhấn lưu form
         */
        clickSaveBtn: async function () {
            this.setNewCode(false);
            let serviceRs = await this.execute();
            if (serviceRs != null) {
                this.executePost();
                this.setNewCode(true);
                this.refreshForm();
                await this.getNewCode();
            }
        },
        /**
         * format dateString theo định dạng yyyy-mm-dd
         */
        formatDate: function (dateString) {
            if (dateString) {
                return dateString?.split("/").reverse().join("-");
            }
        },
        /**
         * cập nhật data theo kết quả của combobox
         */
        getData(result, type) {
            switch (type) {
                case "gender":
                    this.currentEmployee.Gender = result;
                    break;
                case "department":
                    this.currentEmployee.DepartmentId = result.id;
                    this.currentEmployee.DepartmentName = result.name;
                    break;
            }
        },
        /**
         * Kiểm tra sự thay đổi của dữ liệu
         */
        checkChangeData() {
            let initData = {
                ...this.data,
                DateOfBirth: this.formatDate(this.data?.DateOfBirth),
                IdentityDate: this.formatDate(this.data?.IdentityDate),
                JoinDate: this.formatDate(this.data?.JoinDate),
            };
            let currentEmployee = this.currentEmployee;
            let check = true;
            for (let attr in currentEmployee) {
                if (!currentEmployee[attr]) currentEmployee[attr] = "";
                if (!initData[attr]) initData[attr] = "";
                if (this.action == ACTION.POST && attr == "EmployeeCode") {
                    if (this.newEmployeeCode != currentEmployee.EmployeeCode) {
                        check = false;
                        return check;
                    }
                    continue;
                } else if (currentEmployee[attr] != initData[attr]) {
                    check = false;
                    return check;
                }
            }
            return check;
        },
        /**
         * Lấy mã nhân viên mới và set up
         */
        getNewCode: async function () {
            let value = await employeeApi.newCode();
            this.$refs["Code"].inputValue = value;
            this.currentEmployee.EmployeeCode = value;
            this.newEmployeeCode = value;
        },
        /**
         * Lấy dữ liệu từ form và set up lên vuex
         */
        getDataFromForm: function () {
            let currentEmployee = this.currentEmployee;
            //cập nhật lên vuex
            this.setExecuteData(currentEmployee);
            return currentEmployee;
        },
        /**
         * Thực hiện hành động post hoặc update
         */
        execute: async function () {
            Object.entries(this.$refs).forEach((component) => {
                component[1].$refs?.BaseInput?.focus();
                component[1].$refs?.BaseInput?.blur();
            });
            let exeData = this.getExecuteData;
            this.getDataFromForm();
            let valid = true;
            if (
                exeData.EmployeeCode != this.currentEmployee.EmployeeCode ||
                this.action == ACTION.POST
            ) {
                let response = await employeeApi.checkDuplicateCode(
                    this.currentEmployee.EmployeeCode
                );
                if (response) {
                    this.setPopup(POPUP.DUPLICATE_POPUP);
                    valid = false;
                } else valid = true;
            }
            if (valid) {
                if (this.action == ACTION.POST) await this.post();
                else if (this.action == ACTION.UPDATE) await this.update();
                let serviceResult = this.getServiceResult;
                if (serviceResult.Success) {
                    return serviceResult;
                } else {
                    let popup = POPUP.VALIDATE_POPUP;
                    popup.popupContent = serviceResult.UserMsg;
                    this.setPopup(popup);
                }
            }
            return null;
        },
        /**
         * Refresh lại form
         */
        refreshForm: function () {
            Object.entries(this.$refs).forEach((component) => {
                component[1].error = false;
                component[1].clicked = false;
            });
            this.setExecuteData({ Gender: 0 });
        },
    },
};
</script>