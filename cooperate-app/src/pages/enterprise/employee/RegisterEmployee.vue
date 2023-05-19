<template>
  <section>
    <div class="box-title">
      <p>Trang chủ / Tạo nhân viên</p>
    </div>
    <br />

    <v-form v-model="form" @submit.prevent="onSubmit">
      <div class="row">
        <div class="col-sm-6">
          <v-text-field
            v-model="fullName"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Tên nhân viên"
            prepend-inner-icon="mdi-pencil"
            variant="outlined"
            autocomplete="null"
          ></v-text-field>
        </div>

        <div class="col-sm-6">
          <v-text-field
            v-model="email"
            :readonly="loading"
            :rules="[rules.email, required]"
            clearable
            label="Email"
            prepend-inner-icon="mdi-pencil"
            variant="outlined"
            autocomplete="null"
          ></v-text-field>
        </div>
        <p class="text-red">[*Mật khẩu mặc định là 1234]</p>
        <div class="col-sm-6">
          <v-text-field
            v-model="userName"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Tài khoản"
            prepend-inner-icon="mdi-pencil"
            variant="outlined"
            autocomplete="null"
          ></v-text-field>
        </div>
        <div class="col-sm-6">
          <v-radio-group inline v-model="idGenderSelected">
            <div
              class="col-sm-12 d-flex justify-center border border-secondary rounded p-2"
            >
              <span class="title-gender">Giới tính</span>
              <v-radio
                label="Nữ"
                color="red"
                :key="false"
                :value="false"
              ></v-radio>
              <v-radio
                label="Nam"
                color="red"
                :key="true"
                :value="true"
              ></v-radio>
            </div>
          </v-radio-group>
        </div>
        <div class="col-sm-4 d-inline-block">
          <v-text-field
            v-model="birthDay"
            :readonly="loading"
            :rules="[required, requiredDate]"
            clearable
            label="Ngày sinh"
            variant="outlined"
            type="date"
          ></v-text-field>
        </div>
        <div class="col-sm-4 d-inline-block">
          <v-radio-group v-model="idSelected">
            <div
              class="col-sm-12 d-flex justify-center border border-secondary rounded p-2"
            >
              <v-radio
                label="Nhân viên tuyển dụng"
                color="red"
                :key="2"
                :value="2"
              ></v-radio>
            </div>
          </v-radio-group>
        </div>
        <div class="col-sm-4">
          <v-text-field
            class="phone-number"
            v-model="phone"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Số điện thoại"
            variant="outlined"
            type="number"
          ></v-text-field>
        </div>
        <div class="col-sm-4">
          <v-text-field
            v-model="provinceAddress"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Tỉnh/Thành phố"
            variant="outlined"
          ></v-text-field>
        </div>
        <div class="col-sm-8">
          <v-text-field
            v-model="detailAddress"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Địa chỉ cụ thể"
            variant="outlined"
          ></v-text-field>
        </div>
        <div class="col-sm-12">
          <div class="row">
            <div class="col-sm-8">
              <v-file-input
                accept="image/*"
                id="file"
                ref="file"
                @change="handleFileUpload()"
                label="Hình ảnh"
                variant="outlined"
                dense
              ></v-file-input>
            </div>
            <div class="col-sm-4">
              <div class="text-center">
                <img class="image-preview" :src="imageSrc" />
              </div>
            </div>
          </div>
        </div>

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
            {{ id == null ? "Tạo nhân viên" : "Cập nhật nhân viên" }}
          </v-btn>
        </div>
      </div>
    </v-form>
  </section>
</template>
<script>
import moment from "moment";
export default {
  props: ["id"],
  data() {
    return {
      userName: "",
      fullName: "",
      email: "",
      birthDay: null,
      idSelected: 2,
      idGenderSelected: null,
      phone: "",
      detailAddress: "",
      provinceAddress: "",
      imageSrc: "",
      file: "",
      form: false,
      rules: {
        email: (value) => {
          const pattern =
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
          return pattern.test(value) || "Email phải hợp lệ";
        },
      },
    };
  },
  methods: {
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
      this.imageSrc = window.URL.createObjectURL(this.file);
    },
    async onSubmit() {
      let postData = {
        userName: this.userName,
        fullName: this.fullName,
        email: this.email,
        birthDay: this.birthDay,
        employeeType: this.idSelected,
        gender: this.idGenderSelected,
        phone: this.phone,
        detailAddress: this.detailAddress,
        provinceAddress: this.provinceAddress,
      };
      let payload = {
        employeeData: postData,
        fileUpload: this.file,
      };
      try {
        if (this.id == null) {
          let responData = await this.$store.dispatch(
            "employee/postEmployees",
            payload
          );
          if (responData == true) {
            this.$toast.success(
              `Nhân viên ${this.fullName} được tạo thành công.`
            );
            this.$router.replace("/enterprise/employee");
          } else {
            this.$toast.warning(`Tài khoản ${this.userName} đã bị trùng.`);
          }
        }
      } catch (err) {
        this.$toast.error(err.mesage || "Đã xảy ra lỗi");
        this.$router.replace("/enterprise/employee");
      }
    },
    required(v) {
      return !!v || "Không được để trống";
    },
    requiredDate(v) {
      let diffTime = moment(new Date()) - moment(v);
      let totalDays = Math.floor(diffTime / (1000 * 60 * 60 * 24));
      console.log(Math.floor(totalDays / 365.25));
      return Math.floor(totalDays / 365.25) >= 18 || "Tuổi phải lớn hơn 18!";
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

.title-gender {
  display: flex;
  align-items: center;
}

.phone-number >>> input[type="number"] {
  -moz-appearance: textfield;
}
.phone-number >>> input::-webkit-outer-spin-button,
.phone-number >>> input::-webkit-inner-spin-button {
  appearance: none;
  -webkit-appearance: none;
  -moz-appearance: none;
}
</style>