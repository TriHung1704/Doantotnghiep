<template>
  <section>
    <div class="box-title">
      <p>Trang chủ / Đăng thông báo</p>
    </div>
    <br />
    <v-form v-model="form" @submit.prevent="onSubmit">
      <div class="row">
        <div class="col-sm-12">
          <v-text-field v-model="title" :readonly="loading" :rules="[required]" clearable label="Tiêu đề bài đăng"
            prepend-inner-icon="mdi-pencil" variant="outlined" autocomplete="null"></v-text-field>
        </div>
        <div class="col-sm-12">
          <quill-editor v-model:content="description" contentType="html" :rules="[required]" theme="snow"></quill-editor>
        </div>

        <div class="col-sm-12 mt-10 pt-4">
          <div class="col-sm-6 d-inline-block">
            <v-file-input accept="image/*" id="file" ref="file" @change="handleFileUpload()" label="Hình ảnh background"
              variant="outlined" dense></v-file-input>
          </div>
          <div class="col-sm-6 d-inline-block text-center">
            <img class="image-preview" :src="fileSrc" />
          </div>
        </div>
        <div class="col-sm-12"></div>
        <div class="col-sm-12 mt-10">
          <v-btn :disabled="!form" :loading="loading" block color="success" size="large" type="submit" variant="elevated">
            {{ id == null ? "Tạo bài đăng" : "Cập nhật bài đăng" }}
          </v-btn>
        </div>
      </div>
    </v-form>
  </section>
</template>
<script>
import urlApi from '@/interceptors/url';
export default {
  props: ["id"],
  data() {
    return {
      title: "",
      description: "",
      fileSrc: null,
      file: "",
      image: "", //update
      form: false
    };
  },
  async created() {
    if (this.id != null) {
      await this.loadPost();
    }
  },
  methods: {
    async loadPost() {
      try {
        var postData = await this.$store.dispatch("admin/loadPost", this.id);
        if (postData.length == 0) {
          this.$toast.warning("Không thể tải bài tuyển dụng!");
          this.$router.back();
        }
        this.title = postData.title;
        this.description = postData.description;
        this.fileSrc = urlApi + postData.image;
        this.image = postData.image;
      } catch (error) {
        this.$toast.error("Đã xảy ra lỗi trong quá trình tải!");
      }
    },
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
      this.fileSrc = window.URL.createObjectURL(this.file);
    },
    async onSubmit() {
      let postData = {
        title: this.title,
        description: this.description,
        image: this.image,
      };
      let payloadData = {
        postData: postData,
        fileUpload: this.file
      };
      try {
        if (this.id == null) {
          let responData = await this.$store.dispatch(
            "admin/registerPost",
            payloadData
          );
          if (responData == true) {
            this.$toast.success(
              `${"Thông báo " + this.title} được tạo thành công!`
            );
          } else {
            this.$toast.warning(
              `${"Thông báo " + this.title} không được tạo thành công!`
            );
          }
        } else {
          payloadData.postData.id = this.id;
          let responData = await this.$store.dispatch(
            "admin/editPost",
            payloadData
          );
          if (responData == true) {
            this.$toast.success(
              `${"Thông báo " + this.title} được cập nhật thành công!`
            );
          } else {
            this.$toast.warning(
              `${"Thông báo " + this.title} không được cập nhật thành công!`
            );
          }
        }
        this.$router.replace("/admin/post/notification");
      } catch (err) {
        this.$toast.error(err.mesage || "Đã xảy ra lỗi");
        this.$router.replace("/admin/post/notification");
      }
    },
    required(v) {
      return !!v || "Không được để trống";
    },
  },
};
</script>
<style scoped>
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

.image-preview {
  max-height: 100px;
}

.ql-container {
  min-height: 150px;
}
</style>