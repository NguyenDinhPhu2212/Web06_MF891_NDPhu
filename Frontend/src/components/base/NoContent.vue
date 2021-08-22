<template>
    <div class="noContent" v-if="show">
        <div>
            <img
                src="https://actappg1.misacdn.net/img/bg_report_nodata.76e50bd8.svg"
                alt=""
            />
        </div>
        <div>Không có dữ liệu</div>
    </div>
</template>
<style lang="css" scoped>
.noContent {
    position: absolute;
    width: 100%;
    top: 216px;
    left: 0;
    height: calc(100vh - 224px);
    z-index: 21;
    background: white;
}
.noContent> div:nth-child(1){
    display: flex;
    justify-content: center;
}
.noContent> div:nth-child(1) > img {
    margin: 50px 50px 30px 50px;
    width: 200px;
}
.noContent > div:nth-child(2) {
    text-align: center;
}
</style> 
<script>
export default {
    name: "NoContent",
    props: {
        showNoContent: { default: false, type: Boolean },
    },
    data() {
        return {
            show: this.showNoContent,
        };
    },
    watch: {
        showNoContent: function () {
            this.show = this.showNoContent;
        },
    },
};
</script>
