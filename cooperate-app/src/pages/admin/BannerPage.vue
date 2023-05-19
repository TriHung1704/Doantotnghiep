<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Quản lý banner</p>
      </div>
      <div class="mt-3">
        <v-radio-group v-model="idSelected">
          <div class="row box-banner" v-for="banner in banners" :key="banner.id">
            <div class="col-sm-2 d-flex justify-center">
              <v-radio label="" color="red" :key="banner.id" :value="banner.id"></v-radio>
            </div>
            <div class="col-sm-10">
              <img :src="'http://localhost:44647/' + banner.image" class="item-image-banner" alt="banner" />
            </div>
          </div>
          <div class="col-sm-12">
            <button-base @click="submitBanner()" :class="'btn-submit'">Hiển thị banner</button-base>
          </div>
        </v-radio-group>
        <hr />
        <div class="row">
          <div class="col-sm-12">
            <div class="col-sm-2 d-inline-block">
              <button-base :disabled="isDisabled" @click="registerBanner()" :class="'btn-submit'">Thêm
                banner</button-base>
            </div>
            <div class="col-sm-4 d-inline-block">
              <v-file-input accept="image/*" id="file" ref="file" @change="handleFileUpload()" label="Chọn file"
                variant="outlined" dense></v-file-input>
            </div>
            <div class="col-sm-6 d-inline-block text-center">
              <img class="image-preview" :src="fileSrc" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data: () => ({
    banners: [],
    file: null,
    idSelected: null,
    fileSrc: null,
    isDisabled: true
  }),
  methods: {
    async loadBanners() {
      try {
        this.banners = await this.$store.dispatch("admin/loadBanners");

        if (this.banners.length == 0) {
          this.$toast.warning("Không có banner nào!");
        } else {
          var selected = this.banners.filter((e) => e.isEnable == true).map((e) => { return { id: e.id } });
          this.idSelected = selected != null ? selected[0].id : null;
        }
      } catch (error) {
        // this.$toast.error("Không thể tải banner!");
      }
    },
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
      this.fileSrc = window.URL.createObjectURL(this.file);
      this.isDisabled = false;
    },
    async registerBanner() {
      this.isDisabled = true;
      var bannerData = await this.$store.dispatch("admin/registerBanner", this.file);
      if (bannerData != null) {
        this.isDisabled = false;
        this.$router.go();
      } else {
        this.$toast.error(`Đã xảy ra lỗi trong quá trình tạo.`);
      }
    },
    async submitBanner() {
      var bannerData = await this.$store.dispatch("admin/enabledBanner", this.idSelected);
      if (bannerData) {
        this.$router.go();
      } else {
        this.$toast.error(`Đã xảy ra lỗi trong quá trình tạo.`);
      }
    },
  },
  async created() {
    await this.loadBanners();
  },
};
</script>
<style scoped>
.box-banner {
  border-radius: 10px 0px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 30%);
  margin: 4px;
}

.item-image-banner {
  max-height: 150px;
  max-width: 100%;
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

.box-post {
  min-height: 500px;
}

.image-preview {
  max-width: -webkit-fill-available;
}
</style>