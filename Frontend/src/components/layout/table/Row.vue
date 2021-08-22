<template>
    <tr :data="data" :index="index" @dblclick="dbclickRow">
        <td></td>
        <td>
            <div><CustomCheckBox :all="allChecked"></CustomCheckBox></div>
        </td>
        <td>
            {{ employee.EmployeeCode }}
        </td>
        <td>
            {{ employee.EmployeeName }}
        </td>
        <td>
            {{ employee.GenderName }}
        </td>
        <td>
            {{ employee.DateOfBirth }}
        </td>
        <td>
            {{ employee.IdentityNumber }}
        </td>
        <td>
            {{ employee.EmployeePosition }}
        </td>
        <td>
            {{ employee.DepartmentName }}
        </td>
        <td>
            {{ employee.BankAccountNumber }}
        </td>
        <td>
            {{ employee.BankName }}
        </td>
        <td>
            {{ employee.BankBranchName }}
        </td>
        <td>
            <div class="flex-center">
                <div style="color: #0075c0; cursor: pointer" @click="clickEdit">
                    <b>Sửa</b>
                </div>
                <div
                    style="
                        width: 20px;
                        height: 20px;
                        margin-left: 10px;
                        cursor: pointer;
                    "
                    :class="[
                        'flex-center',
                        'contextMenu',
                        {
                            'green-border': current == index,
                        },
                    ]"
                    :index="index"
                    @click="contextMenu"
                >
                    <div>
                        <div class="down-icon"></div>
                    </div>
                </div>
            </div>
        </td>
        <td></td>
    </tr>
</template>

<script>
import { mapGetters, mapMutations, mapActions } from "vuex";

export default {
    name: "Row",
    props: {
        data: { type: Object, default: () => {}, required: true },
        index: Number,
    },
    data() {
        return {
            employee: this.data,
        };
    },
    created() {
        //sự kiện khi nhấn ra ngoiaf context menu
        window.addEventListener("click", (event) => {
            if (this.$store.getters.getContextMenu.display) {
                let classList = Array.from(event.target.classList);
                // Kiểm tra xem vị trí có phải là icon hiển thị contxt menu ko
                if (
                    classList.indexOf("down-icon") < 0 &&
                    classList.indexOf("contextMenu") < 0
                ) {
                    // Nếu không, ẩn contextmenu
                    this.setCurrent(-1);
                    if (!this.$el.contains(event.target)) {
                        this.$store.commit("setContextMenu", {
                            display: false,
                        });
                    }
                }
            }
        });
    },
    computed: {
        ...mapGetters({
            getContextMenuPosition: "getContextMenu",
            current: "getCurrentRow",
            allChecked: "getAllChecked",
            getNewCode: "getNewCode",
        }),
    },
    watch: {
        data: function () {
            this.employee = { ...this.data };
        },
    },
    methods: {
        ...mapMutations({
            contextMenuPosition: "setContextMenu",
            setCurrent: "setCurrentRow",
            dialog: "setDialog",
            executeData: "setExecuteData",
            setNewCode: "setNewCode",
        }),
        ...mapActions({
            executeUpdate: "executeUpdate",
        }),
        /**
         * Sự kiện hiển thị context menu
         */
        contextMenu: function (event) {
            this.executeData(this.employee);
            if (this.getContextMenuPosition.display) {
                if (this.current == event.currentTarget.getAttribute("index")) {
                    this.setCurrent(-1);
                    this.contextMenuPosition({
                        display: false,
                    });
                    return;
                }
            }
            // Lấy ra vị trí để hiển thị context meny theo vị trí phần tử
            let top = event.currentTarget.getBoundingClientRect().top;
            let left = event.currentTarget.getBoundingClientRect().left;
            this.setCurrent(event.currentTarget.getAttribute("index"));
            // Hiển thị context menu
            this.contextMenuPosition({
                display: true,
                top: top + 25,
                left: left - 245,
            });
        },
        /**
         * Sự kiện khi nhấn đúp vào 1 hàng
         */
        dbclickRow: function () {
            this.setNewCode(false);
            this.executeUpdate();
            this.executeData(this.employee);
            this.dialog(true);
        },
        /**
         * Sự kiện khi nhấn sửa
         */
        clickEdit: function () {
            this.setNewCode(false);
            this.executeUpdate();
            this.executeData(this.employee);
            this.dialog(true);
        },
    },
};
</script>
<style scoped>
@import url("../../../css/common/font.css");
@import url("../../../css/common/tooltip.css");
@import url("../../../css/common/icon.css");
@import url("../../../css/layout/table.css");
.green-border {
    border: 1px solid #0075c0;
    width: 18px !important;
    height: 18px !important;
}
</style>