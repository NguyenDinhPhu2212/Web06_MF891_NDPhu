<template>
    <div
        class="context-menu"
        v-show="contextMenu.display"
        :style="{
            top: contextMenu.top + 'px',
            left: contextMenu.left + 'px',
        }"
    >
        <div class="context-menu-item" @click="clickCopy">Nhân bản</div>
        <div class="context-menu-item" @click="clickDelete">Xóa</div>
        <div class="context-menu-item">Ngừng sử dụng</div>
    </div>
</template>

<script>
import { POPUP } from "../../constants/popup";
import { employeeApi } from "../../scripts/api/employeeApi";
import { mapMutations, mapActions } from "vuex";
export default {
    name: "ContextMenu",
    computed: {
        contextMenu: function () {
            return this.$store.getters.getContextMenu;
        },
    },
    methods: {
        ...mapMutations({
            setExecuteData: "setExecuteData",
            setDialog: "setDialog",
            setPopup: "setPopup",
            changeAttribute: "changeAttribute",
            setNewCode: "setNewCode",
        }),
        ...mapActions({
            executePost: "executePost",
            executeDelete: "executeDelete",
        }),
        clickCopy: async function () {
            this.executePost();
            this.setNewCode(true);
            let newCode = await employeeApi.newCode();
            this.changeAttribute("EmployeeCode", newCode);
            this.setDialog(true);
        },
        clickDelete: function () {
            let popup = POPUP.DELETE_POPUP;
            let data = this.$store.getters.getExecuteData;
            popup.popupContent = `Bạn có thực sự muốn xóa Nhân viên <${data.EmployeeCode}> không?`;
            this.setPopup(popup);
        },
    },
};
</script>
<style scoped>
.context-menu {
    display: flex;
    flex-direction: column;
    position: absolute;
    font-size: 13px;
    width: 120px;
    border-radius: 6px;
    z-index: 12;
}
.context-menu > div {
    text-align: center;
    cursor: pointer;
    display: flex;
    justify-content: center;
    align-items: center;
    border: 1px solid #bbb;
}
.context-menu-item {
    background: #fff;
    height: 28px;
}
.context-menu-item:nth-child(1) {
    border-top-left-radius: 4px;
    border-top-right-radius: 4px;
}
.context-menu-item:nth-child(3) {
    border-bottom-left-radius: 4px;
    border-bottom-right-radius: 4px;
}
.context-menu-item:nth-child(2) {
    border-bottom: none;
    border-top: none;
}
.context-menu-item:hover {
    color: #019160;
}
</style>