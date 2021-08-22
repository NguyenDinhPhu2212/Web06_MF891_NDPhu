<template>
    <div class="popup-container notosans-regular" v-show="getPopup.display">
        <div class="popup">
            <div>
                <div class="popup-content">
                    <div class="warning-icon">
                        <div
                            :class="{
                                validate: getPopup.type == 'validate',
                                store: getPopup.type == 'store',
                                delete: getPopup.type == 'delete',
                                duplicate: getPopup.type == 'duplicate',
                            }"
                        ></div>
                    </div>
                    <div class="popup-content-text">
                        <div>{{ getPopup.popupContent }}</div>
                    </div>
                </div>
                <div class="popup-footer notosans-semibold">
                    <div
                        class="button close-popup-btn"
                        v-show="getPopup.showCloseBtn"
                        v-html="getPopup.closeBtn"
                        @click="closePopup"
                    ></div>
                    <div
                        :class="[
                            'confirm',
                            { 'm-auto': getPopup.type == 'validate' || getPopup.type == 'duplicate' },
                        ]"
                    >
                        <div
                            class="button deny-btn"
                            v-show="getPopup.showDenyBtn"
                            v-html="getPopup.denyBtn"
                            @click="denyEvent"
                        ></div>
                        <div
                            class="button confirm-btn"
                            v-html="getPopup.confirmBtn"
                            @click="clickConfirm"
                            :style="{
                                'background-color': getPopup.confirmColor,
                            }"
                        ></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
@import url("../../css/base/popup.css");
@import url("../../css/common/icon.css");
@import url("../../css/common/font.css");
</style>
<script>
import { mapGetters, mapMutations } from "vuex";
export default {
    name: "Popup",
    data() {
        return {};
    },
    computed: {
        ...mapGetters({
            getPopup: "getPopup",
        }),
    },
    methods: {
        ...mapMutations({
            setPopup: "setPopup",
            contextMenuPosition: "setContextMenu",
            setDialog: "setDialog",
            executeData:"setExecuteData"
        }),
        //sự kiện khi nhấn tắt popup
        closePopup: function () {
            this.setPopup({ display: false });
        },
        // sự kiện cho nút từ chối
        denyEvent: function () {
            this.setPopup({ display: false });
            this.setDialog(false);
            this.executeData({ Gender: 0 });
        },
        //sự kiện khi nhấn confirm popup
        clickConfirm: function () {
            this.$emit("clickConfirm");
        },
    },
};
</script>