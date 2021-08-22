<template>
    <div class="employee-list">
        <table class="table" id="employee-table" cellspacing="0">
            <colgroup>
                <col style="width: 32px" />
                <col style="width: 40px" />
                <col style="width: 150px" />
                <col style="width: 250px" />
                <col style="width: 150px" />
                <col style="width: 150px" />
                <col style="width: 200px" />
                <col style="width: 250px" />
                <col style="width: 200px" />
                <col style="width: 200px" />
                <col style="width: 250px" />
                <col style="width: 300px" />
                <col style="width: 150px" />
                <col style="width: 32px" />
            </colgroup>
            <thead>
                <tr>
                    <th></th>
                    <th fieldname="AllCheckBox">
                        <div>
                            <CustomCheckBox
                                header
                                :all="allChecked"
                            ></CustomCheckBox>
                        </div>
                    </th>
                    <th
                        v-for="(column, index) in tableColumn"
                        :key="index"
                        :fieldname="column.fieldName"
                    >
                        {{ column.name }}
                    </th>
                    <th fieldname="Function">CHỨC NĂNG</th>
                    <th></th>
                </tr>
            </thead>
            <tbody ref="tbody">
                <Row
                    v-for="(employee, index) in employeeList"
                    :key="index"
                    :data="employee"
                    :index="index"
                />
            </tbody>
        </table>
    </div>
</template>

<script>
import { tableColumn } from "../../../constants/table.js";
import Row from "./Row.vue";
import { mapGetters, mapMutations, mapActions } from "vuex";

export default {
    name: "TheTable",
    components: {
        Row,
    },
    data() {
        return {
            tableColumn: tableColumn,
        };
    },
    computed: {
        ...mapGetters({
            employeeList: "getEmployee",
            getContextMenuPosition: "getContextMenu",
            allChecked: "getAllChecked",
        }),
    },
    watch: {
        /**
         * Nếu hết dữ liệu emit true/false để hiển thị màn hình NoContent
         */
        employeeList: function () {
            if (this.employeeList.length == 0) {
                this.$emit("NoContent", true);
            }else this.$emit("NoContent", false);
        },
    },
    methods: {
        ...mapMutations({
            setEmployee: "setEmployee",
            contextMenuPosition: "setContextMenu",
        }),
        ...mapActions({
            update: "update",
            delete: "delete",
            post: "post",
            employeeFilter: "employeeFilter",
            get: "get",
        }),
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