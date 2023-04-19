<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Quản lý CV</p>
      </div>
      <div class="mt-3">
        <div class="row">
          <div class="col-sm-12">
            <div class="col-sm-2 d-inline-block">
            <button-base :disabled="file == null" @click="registerCV()" :class="'btn-submit'" >Thêm CV</button-base>
           </div> 
            <div class="col-sm-4 d-inline-block">
              <v-file-input
                accept="application/pdf"
                id="file"
                ref="file"
                @change="handleFileUpload()"
                label="Chọn file(.pdf)"
                variant="outlined"
                dense
              ></v-file-input>
            </div>
          </div>
        </div>
        <div class="row">
          <cv-preview :fileShow="fileShow"></cv-preview>
        </div>
      </div>
    </div>
  </div>
</template>
<script>

export default {
  data: () => ({
    cv: null,
    file: null,
    filePreview: null,
    fileShow: null
  }),
  methods: {
    async loadCV() {
      try {
        this.fileShow = await this.$store.dispatch("student/loadCV");
        if (this.url == "") {
          this.$toast.warning("Không có CV nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải CV!");
      }
    },
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
    },
    async registerCV() {
      var cv = await this.$store.dispatch("student/registerCV", this.file);
      if (cv) {
        this.$router.go();
      } else {
        this.$toast.error(`Đã xảy ra lỗi trong quá trình tạo.`);
      }
    }
  },
  async created() {
    await this.loadCV();
  },
};
</script>
<style scoped>
.box-banner{
    border-radius: 10px 0px;
    box-shadow: 0 2px 8px rgb(0 0 0 / 30%);
    margin: 4px;
}
.item-image-banner{
max-height: 150px;
width: auto;
}

.box-title {
  height: 50px;
  margin-top: 10px;
  border: 1px solid;
  background: #222831;
  color: white;
}

.box-title p {
  padding: 12px 10px;
  display: inline-block;
}
.box-title .btn-submit {
  margin: 4px;
}
</style>