<template>
    <div :class="['combobox', { 'flex-column-reverse': reverse }]" :data="data">
        <div
            class="select-trigger flex-align-center combobox-border"
            :class="{ 'border-focus': isTrue }"
        >
            <input
                type="text"
                @keydown.enter.prevent="enter"
                @keydown.down.prevent="down"
                @keydown.up.prevent="up"
                :value="inputValue"
                readonly
                autocomplete="off"
                ref="BaseInput"
            />
            <div class="dropdown-icon" @click="clickIcon">
                <div :class="['arrow', { rotate: rotate }]"></div>
            </div>
        </div>
        <div
            class="select-options combobox-border"
            ref="optionsBox"
            v-show="showOption"
        >
            <div
                class="option"
                v-for="(value, i) in options"
                :key="i"
                @click="choosedOption(value)"
                ref="option"
                :class="{
                    choosed: result && result.name == value.name,
                    'autocomplete-active':
                        currentFocus == i && result.name != value.name,
                    choosedFocus:
                        currentFocus == i && result.name == value.name,
                }"
            >
                {{ value.name }}
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "CustomDropdown",
    $emit: ["result"],
    props: {
        data: { type: Array, required: false, default: () => [] },
        reverse: { type: Boolean, default: false },
    },
    data() {
        return {
            currentFocus: -1,
            showOption: false,
            isTrue: false,
            options: [],
            result: this.data[0],
            inputValue: this.data[0].name,
            rotate: false,
        };
    },
    watch: {
        result() {
            this.$emit("result", this.result);
            return this.result;
        },
    },
    created() {
        let vm = this;
        window.addEventListener("click", (event) => {
            if (!this.$el.contains(event.target)) {
                vm.showOption = false;
                vm.isTrue = false;
            }
        });
        this.options = [...this.data];
    },
    methods: {
        /**
         * Sự kiện khi click vào combobox
         */
        clickInput: function () {
            //hiển thị viền xanh cho combobox
            this.isTrue = true;
            //hiển thị options box
            this.showOption = true;
            //focus cho input
            this.$refs.BaseInput.focus();
        },
        clickIcon: function () {
            //hiển thị viền xanh cho combobox
            this.isTrue = true;
            this.rotate = !this.rotate;
            //hiển thị options box
            this.showOption = !this.showOption;
            if (this.showOption) {
                //focus cho input
                this.$refs.BaseInput.focus();
            }
        },
        /**
         * Sự kiện khi nhấn chọn 1 option
         */
        choosedOption: function (option) {
            this.rotate = false;
            //hiển thị nội dung của option được chọn lên combobox
            this.result = { ...option };
            this.inputValue = option?.name;
            //ẩn options box
            this.showOption = false;
            this.isTrue = false;
        },
        /**
         * Sự kiện khi nhấn nút enter
         */
        enter: function () {
            //kiểm tra xem option hiện tại đang được focus có nằm trong khoảng thoả mãn
            if (this.currentFocus > -1 && this.options.length) {
                this.$refs.option[this.currentFocus].click();
                this.currentFocus = 0;
            }
        },
        down: function () {
            //nếu nhấn xuống
            this.currentFocus++;
            //kiểm tra currentfocus có nằm trong khoảng cho phép không
            //nếu không thì đặt lại
            //và hiển thị nền cho option hiện tại
            if (this.options.length) {
                //nếu currentFocus lớn hơn số lượng các option thoả mãn
                //thì đặt lại bằng 0
                if (this.currentFocus >= this.options.length)
                    this.currentFocus = 0;
                //nếu currentFocus < 0
                //thì đặt lại bằng số lượng các option thoả mãn -1
                if (this.currentFocus < 0)
                    this.currentFocus = this.options.length - 1;
            }
        },
        /**
         * Sự kiện khi nhấn lên
         */
        up: function () {
            //nếu nhấn lên
            this.currentFocus--;
            if (this.options.length) {
                if (this.currentFocus >= this.options.length)
                    this.currentFocus = 0;
                if (this.currentFocus < 0)
                    this.currentFocus = this.options.length - 1;
            }
        },
    },
};
</script>
<style lang="css" scoped>
@import url("../../css/base/combobox.css");
@import url("../../css/common/flex.css");
.border-focus {
    border: 1px solid #248b15;
    border-radius: 2px;
}
.notice-border {
    border: 1px solid red;
    border-radius: 2px;
}
.arrow {
    background: url("../../assets/resource/img/Sprites.64af8f61.svg") no-repeat -564px -365px;
    width: 8px;
    height: 5px;
}
.arrow.rotate {
    transform: rotate(180deg);
}
.rotate {
    transition: all 0.2s linear;
}
.dropdown-icon {
    width: 40px;
    height: 32px;
    cursor: pointer;
    display: flex;
    justify-content: center;
    align-items: center;
}
.dropdown-icon:hover {
    background: #e0e0e0;
}
.flex-column-reverse {
    display: flex;
    flex-direction: column-reverse;
    align-content: space-between;
}
.flex-column-reverse input {
    font-size: 13px !important;
    font-family: "notosans-regular", sans-serif !important;
    font-weight: 400;
}
.flex-column-reverse .select-options {
    margin-bottom: 40px;
}
</style>