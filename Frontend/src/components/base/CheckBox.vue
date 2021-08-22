<template>
    <div class="center">
        <label class="container">
            <input type="checkbox" />
            <span
                :class="['checkmark', { 'green-border': display }]"
                @click="checked"
            >
                <span class="checked-container">
                    <span class="checked-icon" v-if="display"></span>
                </span>
            </span>
            <span
                ><div style="margin-left: 25px">{{ label }}</div></span
            >
        </label>
    </div>
</template>

<script>
import { mapGetters, mapMutations } from "vuex";
export default {
    name: "CustomCheckBox",
    props: {
        label: { type: String, default: "" },
        header: { type: Boolean, default: false },
        all: { type: Boolean, default: false },
    },
    data() {
        return {
            display: false,
        };
    },
    computed: {
        ...mapGetters({
            allChecked: "getAllChecked",
        }),
    },
    watch: {
        all: function () {
            this.display = this.allChecked;
        },
    },
    methods: {
        ...mapMutations({
            setAllChecked: "setAllChecked",
        }),
        // Khi nhấn checked
        //created by Phú
        checked: function () {
            if (this.header) {
                if (!this.display) this.setAllChecked(true);
                else this.setAllChecked(false);
                return;
            }
            this.display = !this.display;
            if (this.display) this.$emit("choosed", this.label);
        },
    },
};
</script>
<style lang="css" scoped>
@import url("../../css/common/font.css");
.center {
    display: flex;
    justify-content: center;
    align-items: center;
    margin: auto !important;
}
/* The container */
.container {
    display: flex;
    justify-content: center;
    align-items: center;
    cursor: pointer;
    font-size: 13px;
    font-family: "notosans-regular", sans-serif !important;
    position: relative;
    /* -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none; */
}

/* Hide the browser's default checkbox */
.container input {
    position: absolute;
    opacity: 0;
    cursor: pointer;
    height: 0;
    width: 0;
}

/* Create a custom checkbox */
.checkmark {
    position: absolute;
    top: 0;
    left: 0;
    height: 15px;
    width: 15px;
    background-color: #fff;
    border: 1px solid #bbb;
    border-radius: 2px;
}
.green-border {
    border-color: #2ca01c !important;
}
.checkmark .checked-container {
    height: 15px;
    width: 15px;
    display: flex;
    justify-content: center;
    align-items: center;
}
.checked-icon {
    background: url("../../assets/resource/img/Sprites.64af8f61.svg") no-repeat -899px -316px;
    width: 11px;
    height: 8px;
}
</style> 