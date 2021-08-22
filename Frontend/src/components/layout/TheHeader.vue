<template>
    <div class="employee-list-header flex-align-center">
        <div
            class="flex-justify-space-between"
            style="width: 100%; margin: auto; padding: 0 24px;"
        >
            <div class="right-header flex-align-center">
                <div class="toggle-icon"></div>
                <BaseCombobox
                    class="mf-10px"
                    dropdownId="companyDropdown"
                    inputId="company"
                    :data="[{ id: 0, name: 'CÔNG TY CỔ PHẦN MISA' }]"
                    border="none"
                    :width="230"
                    :bold="true"
                />
            </div>

            <div class="user-box flex-align-center">
                <div class="notification-icon" style="margin-right: 20px"></div>
                <div
                    class="default-avater-icon"
                    style="margin-right: 20px"
                ></div>
                <div class="user flex-align-center">
                    <div class="username">Nguyễn Văn A</div>
                    <div
                        class="arrow-down-icon"
                    ></div>
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
@import url("../../css/layout/header.css");
@import url("../../css/common/flex.css");
@import url("../../css/common/icon.css");
</style>
<script>
export default {
    name: "TheHeader",
    methods: {},
};
</script>