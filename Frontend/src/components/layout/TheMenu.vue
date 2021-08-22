<template>
    <div class="navbar">
        <div class="logo-box flex-align-center">
            <div class="home-icon"></div>
            <div class="logo"></div>
        </div>
        <div class="navbar-items" style="padding-top: 14px">
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 0 }"
                >
                    <div class="navbar-item-icon general-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Tổng quan
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/employee"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 1 }"
                >
                    <div class="navbar-item-icon cash-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Tiền mặt
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 2 }"
                >
                    <div class="navbar-item-icon credit-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Tiền gửi
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 3 }"
                >
                    <div class="navbar-item-icon buy-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Mua hàng
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 4 }"
                >
                    <div class="navbar-item-icon sell-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Bán hàng
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 5 }"
                >
                    <div class="navbar-item-icon bill-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Quản lý hóa đơn
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 6 }"
                >
                    <div class="navbar-item-icon warehouse-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Kho
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 7 }"
                >
                    <div class="navbar-item-icon tools-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Công cụ dụng cụ
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 8 }"
                >
                    <div class="navbar-item-icon assets-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Tài sản cố định
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 9 }"
                >
                    <div class="navbar-item-icon tax-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Thuế
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 10 }"
                >
                    <div class="navbar-item-icon price-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Giá thành
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 11 }"
                >
                    <div class="navbar-item-icon synthetic-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Tổng hợp
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 12 }"
                >
                    <div class="navbar-item-icon budget-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Ngân sách
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 13 }"
                >
                    <div class="navbar-item-icon report-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Báo cáo
                    </div></router-link
                >
            </div>
            <div class="navbar-item-container">
                <router-link
                    to="/other"
                    class="navbar-item flex-align-center"
                    @click.native="clickItem"
                    :class="{ clickItem: current == 14 }"
                >
                    <div class="navbar-item-icon analyst-icon"></div>
                    <div class="navbar-item-text" v-show="showMenuText">
                        Phân tích tài chính
                    </div></router-link
                >
            </div>
        </div>
    </div>
</template>
<script>
import $ from "jquery";
export default {
    name: "TheMenu",
    props: {
        showMenuText: {
            type: Boolean,
            default: true,
        },
    },
    created() {
        this.$router.push("/employee").catch(() => {});
    },
    data() {
        return {
            current: 1,
        };
    },
    methods: {
        clickItem: function (event) {
            let currentTarget = event.currentTarget;
            this.current = $(currentTarget.parentNode.parentNode)
                .children()
                .index(currentTarget.parentNode);
        },
    },
};
</script>
<style scoped>
@import url("../../css/layout/navbar.css");
@import url("../../css/common/flex.css");
@import url("../../css/common/font.css");
@import url("../../css/common/icon.css");
* {
    font-size: 13px !important;
    font-family: "notosans-regular", sans-serif !important;
}

::-webkit-scrollbar-thumb {
    background: #b8bcc3;
}
::-webkit-scrollbar {
    width: 6px;
    height: 6px;
}
::-webkit-scrollbar-track {
    background: #f1f1f1;
}
::-webkit-scrollbar-track-piece {
    background-color: #f1f1f1;
    width: 6px;
}
</style>