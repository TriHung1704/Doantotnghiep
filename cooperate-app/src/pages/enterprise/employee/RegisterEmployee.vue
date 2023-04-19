<template>
  <section>
    <div class="box-title">
      <p>Trang chủ / Tạo nhân viên</p>
    </div>
    <br />

    <v-form v-model="form" @submit.prevent="onSubmit">
      <div class="row">
        <div class="col-sm-12">
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
        <p class="text-red">[Mật khẩu mặc định là 1234]</p>
        <div class="col-sm-12">
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
        <div class="col-sm-12">
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
        <div class="col-sm-3 d-inline-block">
          <v-text-field
            v-model="birthDay"
            :readonly="loading"
            :rules="[required]"
            clearable
            label="Ngày sinh"
            prepend-inner-icon="mdi-event"
            variant="outlined"
            type="date"
          ></v-text-field>
        </div>
        <div class="col-sm-9 d-inline-block">
          <v-radio-group v-model="idSelected">
            <div class="col-sm-12 d-flex justify-center border border-secondary rounded p-2">
                <v-radio
                  label="Nhân viên tuyển dụng"
                  color="red"
                  :key="2"
                  :value="2"
                ></v-radio>
                <v-radio
                  label="Nhân viên hướng dẫn"
                  color="red"
                  :key="3"
                  :value="3"
                ></v-radio>
              </div>
          </v-radio-group>
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
export default {
  props: ["id"],
  data() {
    return {
      userName: "",
      fullName: "",
      email: "",
      birthDay: null,
      idSelected: null,
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
  async created() {
    // await this.loadMajors();
    // if (this.id != null) {
    //   await this.loadPost();
    // }
  },
  methods: {
    
    async onSubmit() {
      let postData = {
        userName: this.userName,
        fullName: this.fullName,
        email: this.email,
        birthDay: this.birthDay,
        employeeType: this.idSelected,
      };
      try {
        if (this.id == null) {
          let responData = await this.$store.dispatch(
            "employee/postEmployees",
            postData
          );
          if (responData == true) {
            this.$toast.success(
              `Nhân viên ${this.fullName} được tạo thành công.`
            );
          } else {
            this.$toast.warning(
              `Nhân viên ${this.fullName} không được tạo thành công.`
            );
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
    // emailRules(v) {
    //   return !!v || /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'Email phải hợp lệ'
    // }
  },
};
</script>
<style scoped>
.box-title {
  height: 50px;
  margin-top: 10px;
  border: 1px solid;
  background: #4caf50;
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