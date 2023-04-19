<template>
  <section>
    <div class="box-title">
      <p v-if="this.type == 'recruitment'">Trang chủ / Tạo bài tuyển dụng</p>
      <p v-if="this.type == 'internship'">
        Trang chủ / Tạo bài tuyển thực tập sinh
      </p>
      <p v-if="this.type == 'seminar'">Trang chủ / Tạo bài hội thảo</p>
    </div>
    <br />

    <v-form v-model="form" @submit.prevent="onSubmit">
      <div class="row">
        <div class="col-sm-12">
          <v-text-field
            v-model="title"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Tiêu đề bài đăng"
            prepend-inner-icon="mdi-pencil"
            variant="outlined"
            autocomplete="null"
          ></v-text-field>
        </div>
        <div class="col-sm-12">
          <quill-editor
            v-model:content="description"
            contentType="html"
            :rules="[required]"
            theme="snow"
          ></quill-editor>
        </div>
        <div class="col-sm-12 mt-10 pt-4">
          <div class="col-sm-3 d-inline-block">
            <v-text-field
              v-model="quantity"
              :readonly="loading"
              :rules="[required,requiredNumber]"
              clearable
              label="Số lượng tuyển dụng"
              prepend-inner-icon="mdi-widgets"
              variant="outlined"
              autocomplete="null"
              type="number"
            ></v-text-field>
          </div>
          <div class="col-sm-3 d-inline-block">
            <v-text-field
              v-model="expireTime"
              :readonly="loading"
              :rules="[required,requiredDate]"
              clearable
              label="Ngày hết hạn ứng tuyển"
              prepend-inner-icon="mdi-event"
              variant="outlined"
              type="date"
            ></v-text-field>
          </div>
          <div class="col-sm-6 d-inline-block">
            <v-autocomplete
              v-model="itemsMajor"
              :items="itemsMajors"
              chips
              closable-chips
              solo
              item-title="majorsName"
              item-value="id"
              label="Các ngành học liên quan"
              variant="outlined"
              multiple
            >
              <template v-slot:chip="{ props, item }">
                <v-chip v-bind="props" :text="item.raw.majorsName"></v-chip>
              </template>

              <template v-slot:item="{ props, item }">
                <v-list-item
                  v-bind="props"
                  :title="item?.raw?.majorsName"
                ></v-list-item>
              </template>
            </v-autocomplete>
          </div>
        </div>

        <div class="col-sm-12">
          <div class="col-sm-6 d-inline-block">
            <v-file-input
              accept="image/*"
              id="file"
              ref="file"
              @change="handleFileUpload()"
              label="Hình ảnh background"
              variant="outlined"
              dense
            ></v-file-input>
          </div>
          <div class="col-sm-6 d-inline-block text-center">
            <img class="image-preview" :src="fileSrc" />
          </div>
        </div>
        <div class="col-sm-12"></div>
        <div class="col-sm-12 mt-10">
          <v-btn
            :disabled="!form"
            :loading="loading"
            block
            color="success"
            size="large"
            type="submit"
            variant="elevated"
          >
            {{ id == null ? "Tạo bài đăng" : "Cập nhật bài đăng" }}
          </v-btn>
        </div>
      </div>
    </v-form>
  </section>
</template>
<script>
import moment from 'moment';
export default {
  props: ["id", "type"],
  data() {
    return {
      title: "",
      description: "",
      quantity: 0,
      expireTime: null,
      itemsMajors: [],
      itemsMajor: null,
      fileSrc: null,
      file: "",
      image: "", //update
      form: false,
      message: "",
    };
  },
  async created() {
    await this.loadMajors();
    if (this.id != null) {
      await this.loadPost();
    }
  },
  methods: {
    async loadMajors() {
      let majors = await this.$store.dispatch("post/loadMajors");
      this.itemsMajors = majors;
    },
    async loadPost() {
      try {
        var postData = await this.$store.dispatch("post/loadPost", this.id);
        if (postData.length == 0) {
          this.$toast.warning("Không thể tải bài tuyển dụng!");
          this.$router.back();
        }
        this.title = postData.title;
        this.description = postData.description;
        this.quantity = postData.quantity;
        this.expireTime = postData.expireTime.split("T")[0];
        this.itemsMajor = postData.majorsIds;
        this.fileSrc = "data:image/jpeg;base64," + postData.imageByte;
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
        quantity: this.quantity,
        expireTime: this.expireTime,
        majorsIds: this.itemsMajor,
        image: this.image,
      };
      let payloadData = {
        postData: postData,
        fileUpload: this.file,
        type: this.type
      };
      try {
        var message = "";
        switch (this.type) {
          case "recruitment":
            message = "Bài tuyển dụng";
            break;
          case "internship":
            message = "Bài tuyển thực tập sinh";
            break;
          case "seminar":
            message = "Bài hội thảo";
            break;
        }

        if (this.id == null) {
          let responData = await this.$store.dispatch(
            "post/registerPost",
            payloadData
          );
          if (responData == true) {
            this.$toast.success(
              `${message +" "+ this.title} được tạo thành công. Đang chờ duyệt...`
            );
          } else {
            this.$toast.warning(
              `${message +" "+ this.title} không được tạo thành công. Đang chờ duyệt...`
            );
          }
        } else {
          payloadData.postData.id = this.id;
          let responData = await this.$store.dispatch(
            "post/editPost",
            payloadData
          );
          if (responData == true) {
            this.$toast.success(
              `${message +" "+ this.title} được cập nhật thành công. Đang chờ duyệt...`
            );
          } else {
            this.$toast.warning(
              `${message +" "+ this.title} không được cập nhật thành công. Đang chờ duyệt...`
            );
          }
        }
        this.$router.replace("/enterprise/posts/"+this.type);
      } catch (err) {
        this.$toast.error(err.mesage || "Đã xảy ra lỗi");
        this.$router.replace("/enterprise/posts/"+this.type);
      }
    },
    required(v) {
      return !!v || "Không được để trống!";
    },
    requiredNumber(v) {
      return v>0 || "Không được chọn số nhỏ hơn 0!";
    },
    requiredDate(v) {
      //console.log(moment(new Date()).format('DD-MM-YYYY'))
      console.log(moment(new Date()))
      return moment(v) >= moment(new Date()) || "Không được chọn ngày quá khứ!";
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