<template>
    <div>
        <div class="page">
            <TheHeader />
            <div class="page-body">
                <div class="body-header">
                    <div
                        class="flex-justify-space-between"
                        style="
                            padding: 24px 16px;
                            line-height: 36px;
                            background: #f4f5f8;
                        "
                    >
                        <div
                            style="
                                font-size: 24px;
                                font-family: 'notosans-bold', sans-serif !important;
                            "
                        >
                            Nhân viên
                        </div>
                        <BaseButton
                            v-on:clicked="clickAddBtn"
                            btnContent="Thêm mới nhân viên"
                            :showIcon="false"
                        />
                    </div>
                </div>
                <div class="filter-bar flex-end">
                    <div class="flex-align-center">
                        <div class="filter-form" style="margin-right: 10px">
                            <BaseInput
                                class="input-text"
                                placeholder="Tìm kiếm theo Mã, Tên nhân viên"
                                v-model="keyWord"
                            />
                            <div class="search-icon"></div>
                        </div>
                        <div
                            id="refresh"
                            class="refresh-btn"
                            @click="clickRefreshBtn"
                        >
                            <div class="refresh-icon"></div>
                        </div>
                    </div>
                </div>
                <div class="body-content">
                    <TheTable @NoContent="(show) => noContent(show)" />
                </div>
                <Pagination
                    ref="pagination"
                    @currentPage="(index) => changeCurrent(index)"
                ></Pagination>
            </div>
            <NoContent :showNoContent="showNoContent" />
            <ContextMenu ref="contextMenu" />
            <Loading></Loading>
        </div>
        <TheEmployeeDetail
            :data="getExecuteData"
            :dataDepartment="dataDepartment"
            @checkDuplicate="(valid) => getValid(valid)"
        />
        <Popup @clickConfirm="clickConfirm"></Popup>
        <ToastGroup></ToastGroup>
    </div>
</template>

<script>
import { tableColumn } from "../../constants/table.js";
import { departmentApi } from "../../scripts/api/departmentApi";
import { mapGetters, mapMutations, mapActions } from "vuex";
import BaseButton from "../base/Button.vue";
import ContextMenu from "../base/ContextMenu.vue";
import TheTable from "./table/TheTable.vue";
import TheEmployeeDetail from "./TheEmployeeDetail.vue";
import TheHeader from "../layout/TheHeader.vue";
import Pagination from "../base/Pagination.vue";
import { ACTION } from "../../constants/action";
import { employeeApi } from "../../scripts/api/employeeApi";
import { POPUP } from "../../constants/popup";
export default {
    name: "ThePage",
    components: {
        BaseButton,
        TheHeader,
        TheEmployeeDetail,
        TheTable,
        Pagination,
        ContextMenu,
    },
    data() {
        return {
            dataDepartment: [],
            current: 1,
            keyWord: "",
            tableColumn: tableColumn,
            showNoContent: false,
            errors: [],
            valid: false,
            currentEmployeeCode: {},
        };
    },
    /**
     * Lấy dữ liệu từ api department và position
     */
    async created() {
        this.dataDepartment = [...(await departmentApi.getDepartment())];
        this.$refs.pagination.currentPage = 1;
        await this.getData(1);
    },
    computed: {
        ...mapGetters({
            employeeList: "getEmployee",
            getPopup: "getPopup",
            getFilter: "getFilter",
            getExecuteData: "getExecuteData",
            getContextMenuPosition: "getContextMenu",
            getTotalPage: "getTotalPage",
            action: "getAction",
            getServiceResult: "getServiceResult",
        }),
    },
    watch: {
        /**
         * Cập nhật lại bộ lọc nếu keyword thay đổi
         */
        keyWord: async function () {
            setTimeout(async () => {
                let filter = { ...this.getFilter };
                if (this.keyWord == "") {
                    filter.employeeFilter = "NV";
                } else filter.employeeFilter = this.keyWord;
                this.setFilter(filter);
                this.$refs.pagination.currentPage = 1;
                await this.getData(1);
            }, 500);
        },
    },
    methods: {
        ...mapMutations({
            setEmployee: "setEmployee",
            executeData: "setExecuteData",
            dialog: "setDialog",
            contextMenuPosition: "setContextMenu",
            setPopup: "setPopup",
            setFilter: "setFilter",
            setLoading: "setLoading",
            setNewCode: "setNewCode",
        }),
        ...mapActions({
            update: "update",
            delete: "delete",
            post: "post",
            employeeFilter: "employeeFilter",
            get: "get",
            executePost: "executePost",
        }),
        /**
         * Thực hiện chức năng khi nhấn nút xác nhận của popup
         */
        clickConfirm: async function () {
            let type = this.getPopup.type;
            // Thực hiện chức năng
            await this.execute(type);
            //ẩn contextmenu
            this.contextMenuPosition({
                display: false,
            });
            // Nếu không phải sự kiện thoát thì cập nhật lại dữ liệu
            if (type == "delete" || type == "store") {
                await this.getData(this.current);
            }
        },
        /**
         * sự kiện khi nhấn nút thêm nhân viên
         */
        clickAddBtn: function () {
            //hiển thị dialog
            this.executePost();
            this.setNewCode(true);
            this.executeData({ Gender: 0 });
            this.dialog(true);
        },
        /**
         * sự kiện khi nhấn nút refresh
         */
        clickRefreshBtn: async function () {
            this.setLoading(true);
            if (this.$refs.pagination.currentPage == 1) await this.getData(1);
            else this.$refs.pagination.currentPage = 1;
            this.setLoading(false);
        },
        /**
         * Cập nhật lại bộ lọc và tiến hành lọc
         */
        async getData(index) {
            let filter = { ...this.getFilter };
            filter.pageIndex = (index - 1) * 10;
            this.setFilter(filter);
            await this.employeeFilter();
        },
        /**
         * Cập nhật số trang
         */
        changeCurrent(index) {
            this.current = index;
        },
        /**
         * Thực hiện thêm, sửa, xóa
         */
        async execute(type) {
            if (type == "validate") {
                this.setPopup({ display: false });
            } else if (type == "delete") {
                await this.delete();
                this.setPopup({ display: false });
            } else if (type == "store") {
                let tmp = true;
                if (!this.valid) {
                    let response = await employeeApi.checkDuplicateCode(
                        this.currentEmployeeCode
                    );
                    if (response) {
                        console.log(2);
                        this.setPopup(POPUP.DUPLICATE_POPUP);
                        tmp = false;
                    }
                }
                if (tmp) {
                    if (this.action == ACTION.POST) await this.post();
                    else if (this.action == ACTION.UPDATE) await this.update();
                    let serviceResult = this.getServiceResult;
                    if (serviceResult.Success) {
                        this.dialog(false);
                        this.executeData({ Gender: 0 });
                        this.setPopup({ display: false });
                    } else {
                        let popup = POPUP.VALIDATE_POPUP;
                        popup.popupContent = serviceResult.UserMsg;
                        this.setPopup(popup);
                    }
                }
            } else if (type == "duplicate") {
                this.setPopup({ display: false });
            }
        },
        /**
         * Hiển thị màn hình thông báo không có dữ liệu khi hết dữ liệu
         */
        noContent: function (show) {
            if (show) {
                if (this.getTotalPage > 1) {
                    this.$refs.pagination.currentPage = this.current - 1;
                } else this.showNoContent = show;
            } else this.showNoContent = show;
        },
        getValid: function (valid) {
            this.valid = valid.valid;
            this.currentEmployeeCode = valid.data;
        },
    },
};
</script>
<style scoped>
@import url("../../css/common/font.css");
@import url("../../css/common/tooltip.css");
@import url("../../css/common/icon.css");
@import url("../../css/layout/page.css");
.green-border {
    border: 1px solid #0075c0;
    width: 18px !important;
    height: 18px !important;
}
.page-body::-webkit-scrollbar-thumb {
    background: #b8bcc3;
}
.page-body::-webkit-scrollbar {
    width: 6px;
    height: 6px;
}
.page-body::-webkit-scrollbar-track {
    background: #f1f1f1;
}
.page-body::-webkit-scrollbar-track-piece {
    background-color: #f1f1f1;
    width: 6px;
}
</style>