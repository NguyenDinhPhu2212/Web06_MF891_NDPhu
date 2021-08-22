<template>
    <div
        class="
            paging-bar
            flex-align-center flex-justify-space-between
            notosans-regular
        "
    >
        <div class="counter">
            Tổng số:
            <span class="total-person notosans-bold">{{ totalRecord }}</span>
            nhân viên
        </div>
        <div class="flex-align-center">
            <CustomDropdown
                :reverse="true"
                :data="pagingOptions"
                @result="(result) => paging(result)"
                ref="pagingCbb"
            />
            <div class="pagination">
                <div
                    :class="[
                        'prev-page-button',
                        { disableText: currentPage == 1 },
                    ]"
                    @click="prev"
                >
                    Trước
                </div>
                <div class="index-bar" :style="{ width: 20 * number + 'px' }">
                    <div class="page-list-container">
                        <ul
                            class="page-list flex-align-center"
                            :style="{ 'margin-left': margin + 'px' }"
                        >
                            <li class="begin" @click="firstPage">
                                <div class="flex">
                                    <div class="flex-center page-container">
                                        <div
                                            :class="[
                                                {
                                                    'current-page':
                                                        1 == currentPage,
                                                },
                                                'cursor',
                                                'pageIndex',
                                            ]"
                                        >
                                            {{ 1 }}
                                        </div>
                                    </div>
                                    <div
                                        v-show="first"
                                        class="first flex-center page-container"
                                    >
                                        <div class="pageIndex">...</div>
                                    </div>
                                </div>
                            </li>
                            <li
                                v-for="index in totalPage"
                                :key="index"
                                @click="currentPage = index"
                            >
                                <div class="page-container">
                                    <div
                                        :class="[
                                            {
                                                'current-page':
                                                    index == currentPage,
                                            },
                                            'cursor',
                                            'pageIndex',
                                        ]"
                                    >
                                        {{ index }}
                                    </div>
                                </div>
                            </li>
                            <li @click="lastPage">
                                <div class="flex page-container">
                                    <div
                                        v-show="last"
                                        class="last-r-20 flex-center"
                                    >
                                        <div class="pageIndex">...</div>
                                    </div>
                                    <div class="flex-center last">
                                        <div
                                            :class="[
                                                {
                                                    'current-page':
                                                        totalPage ==
                                                        currentPage,
                                                },
                                                'cursor',
                                                'pageIndex',
                                            ]"
                                        >
                                            {{ totalPage }}
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
                <div
                    :class="[
                        'next-page-button',
                        { disableText: currentPage == totalPage },
                    ]"
                    @click="next"
                >
                    Sau
                </div>
            </div>
        </div>
    </div>
</template>
<style scoped>
@import url("../../css/common/flex.css");
@import url("../../css/base/pagination.css");
@import url("../../css/common/font.css");
.disableText {
    cursor: default !important;
    color: #9e9e9e;
}
.prev-page-button,
.next-page-button {
    cursor: pointer;
}
</style>
<script>
import { PAGING } from "../../constants/paging";
import { mapGetters, mapMutations, mapActions } from "vuex";
export default {
    name: "Pagination",
    data() {
        return {
            currentPage: 0,
            filter: {
                pageSize: 10,
                pageIndex: 0,
                employeeFilter: "NV",
                departmentId: "",
                positionId: "",
            },
            pagingOptions: PAGING,
            first: false,
            last: true,
            number: 5,
            margin: 0,
        };
    },
    computed: {
        ...mapGetters({
            getEmployee: "getEmployee",
            getFilter: "getFilter",
            totalPage: "getTotalPage",
            totalRecord: "getTotalRecord",
        }),
    },
    watch: {
        /**
         * Tiến hành lọc theo sự thay đổi của số trang
         */
        currentPage: async function () {
            this.$emit("currentPage", this.currentPage);
            // Cập nhật lại phân trang
            this.updatePaging();
            // Tiến hành lọc dữ liệu
            this.filter = { ...this.getFilter };
            this.filter.pageIndex = (this.currentPage - 1) * 10;
            this.setFilter(this.filter);
            await this.employeeFilter();
        },
        totalPage: function () {
            if (this.totalPage <= 4) {
                this.first = false;
                this.last = false;
                this.number = this.totalPage;
            } else {
                this.first=false;
                this.last=true;
                this.number = 5;
            }
        },
    },
    methods: {
        ...mapMutations({
            setFilter: "setFilter",
            setLoading: "setLoading",
            setEmployee: "setEmployee",
        }),
        ...mapActions({
            employeeFilter: "employeeFilter",
            get: "get",
        }),
        /**
         * Sự kiện khi nhấn vào trang 1
         */
        firstPage: function () {
            this.currentPage = 1;
        },
        /**
         * Cập nhật lại vị trí trang khi nhấn nút prev
         */
        prev: function () {
            if (this.currentPage <= 1) {
                this.currentPage = 1;
            } else this.currentPage -= 1;
        },
        /**
         * Sự kiện khi nhấn vào trang cuối cùng
         */
        lastPage: function () {
            this.currentPage = this.totalPage;
        },
        /**
         * Cập nhật lại vị trí trang khi nhấn nút next
         */
        next: function () {
            if (this.currentPage >= this.totalPage) {
                this.currentPage = this.totalPage;
            } else this.currentPage += 1;
        },
        /**
         * Phân trang lại khi thay đổi lựa chọn
         */
        async paging(result) {
            this.filter = { ...this.getFilter };
            this.filter.pageSize = result.id;
            this.filter.pageIndex = 0;
            this.setFilter(this.filter);
            if (this.currentPage != 1) this.currentPage = 1;
            else this.employeeFilter();
        },
        /**
         * Cập nhật lại các trang
         */
        updatePaging: function () {
            if (this.number >= 5 && this.totalPage >= 5) {
                if (this.currentPage <= 3) {
                    this.number = 5;
                    this.first = false;
                    this.last = true;
                    this.margin = 0;
                    return;
                } else if (
                    this.currentPage >= 4 &&
                    this.currentPage <= this.totalPage - 3
                ) {
                    this.number = 6;
                    this.first = true;
                    this.last = true;
                    let vm = this;
                    for (let i = 4; i <= this.totalPage - 3; i++) {
                        if (
                            i % 2 == 0 &&
                            (this.currentPage == i || this.currentPage == i + 1)
                        ) {
                            vm.margin = (i - 3) * -20;
                            return;
                        }
                    }
                } else if (this.currentPage >= this.totalPage - 2) {
                    this.number = 5;
                    this.first = true;
                    this.last = false;
                    this.margin = (this.totalPage - this.number) * -20;
                }
            }
        },
    },
};
</script>