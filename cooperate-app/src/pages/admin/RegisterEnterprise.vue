<template>
  <section>
    <div class="box-title">
      <p>Trang chủ / Tài khoản doanh nghiệp</p>
    </div>
    <br />

    <v-form v-model="form" @submit.prevent="onSubmit">
      <div class="row">
        <div class="col-sm-8">
          <div class="row">
            <div class="col-sm-12">
              <v-text-field
                v-model="enterpriseName"
                :readonly="loading"
                :rules="[required]"
                clearable
                label="Tên doanh nghiệp"
                prepend-inner-icon="mdi-pencil"
                variant="outlined"
                autocomplete="null"
              ></v-text-field>
            </div>
            <div class="col-sm-12">
              <v-text-field
                v-model="corporateTaxCode"
                :readonly="loading"
                :rules="[required]"
                clearable
                label="Mã số thuế"
                prepend-inner-icon="mdi-pencil"
                variant="outlined"
                autocomplete="null"
              ></v-text-field>
            </div>
            <div class="col-sm-12">
              <v-text-field
                v-model="director"
                :readonly="loading"
                :rules="[required]"
                clearable
                label="Giám đốc"
                prepend-inner-icon="mdi-pencil"
                variant="outlined"
                autocomplete="null"
              ></v-text-field>
            </div>
            <div class="col-sm-12">
              <v-text-field
                v-model="enterpriseEmail"
                :readonly="loading"
                :rules="[required, rules.email]"
                clearable
                label="Email doanh nghiệp"
                prepend-inner-icon="mdi-pencil"
                variant="outlined"
                autocomplete="null"
              ></v-text-field>
            </div>
            <div class="col-sm-12">
              <v-text-field
                v-model="website"
                :readonly="loading"
                :rules="[required]"
                clearable
                label="Website"
                prepend-inner-icon="mdi-pencil"
                variant="outlined"
                autocomplete="null"
              ></v-text-field>
            </div>
            <div class="col-sm-12">
              <v-text-field
                class="phone-number"
                type="number"
                v-model="enterprisePhone"
                :readonly="loading"
                :rules="[required]"
                clearable
                label="Số điện thoại doanh nghiệp"
                prepend-inner-icon="mdi-pencil"
                variant="outlined"
                autocomplete="null"
              ></v-text-field>
            </div>
            <div class="col-sm-12">
              <div class="row">
                <div class="col-sm-10">
                  <v-text-field
                    class="row"
                    v-model="addressCompany"
                    clearable
                    label="Chi nhánh doanh nghiệp"
                    prepend-inner-icon="mdi-pencil"
                    variant="outlined"
                    autocomplete="null"
                  ></v-text-field>
                </div>
                <div class="col-sm-2">
                  <button class="col-sm-12 add-address" type="button" @click="addAddress()">+</button>
                </div>
              </div>
              <div class="mb-3">
                <v-table class="table-address col-sm-12" v-if="addressCompanyList.length > 0">
                  <thead>
                    <tr>
                      <th class="text-left">Địa chỉ</th>
                      <th class="text-left"></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="item in addressCompanyList" :key="item.id">
                      <td>{{ item.detailAddress }}</td>
                      <td>
                        <div @click="deleteList(item)" title="Xóa" class="delete">
                          x
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </v-table>
              </div>
            </div>
            <div class="col-sm-12">
              <div class="row">
                <div class="col-sm-10">
                  <v-text-field
                    class="row"
                    v-model="fieldCompany"
                    clearable
                    label="Lĩnh vực kinh doanh"
                    prepend-inner-icon="mdi-pencil"
                    variant="outlined"
                    autocomplete="null"
                  ></v-text-field>
                </div>
                <div class="col-sm-2">
                  <button class="col-sm-12 field-company" type="button" @click="addFieldCompany()">+</button>
                </div>
              </div>
              <div>
                <v-table class="table-address col-sm-12" v-if="fieldCompanyList.length > 0">
                  <thead>
                    <tr>
                      <th class="text-left">Lĩnh vực</th>
                      <th class="text-left"></th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="item in fieldCompanyList" :key="item.id">
                      <td>{{ item.name }}</td>
                      <td>
                        <div @click="deleteFieldCompanyList(item)" title="Xóa" class="delete">
                          x
                        </div>
                      </td>
                    </tr>
                  </tbody>
                </v-table>
              </div>
            </div>
          </div>
        </div>
        <div class="col-sm-4">
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
          <p class="text-red">[*Mật khẩu mặc định là 1234]</p>
          <div class="col-sm-12">
            <v-textarea
              v-model="description"
              :readonly="loading"
              :rules="[required]"
              clearable
              label="Giới thiệu doanh nghiệp"
              prepend-inner-icon="mdi-pencil"
              variant="outlined"
              autocomplete="null"
            ></v-textarea>
          </div>
          <div class="col-sm-12">
            <v-file-input
              accept="image/*"
              id="file"
              ref="file"
              @change="handleFileUpload()"
              label="Hình ảnh logo"
              variant="outlined"
              dense
            ></v-file-input>
          </div>
          <div class="text-center">
            <img class="image-preview" :src="imageSrc" />
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
            {{ id == null ? "Tạo doanh nghiệp" : "Cập nhật doanh nghiệp" }}
          </v-btn>
        </div>
      </div>
    </v-form>
  </section>
</template>
<script>
import urlApi from "@/interceptors/url";
export default {
  props: ["id"],
  data() {
    return {
      enterpriseName: "",
      corporateTaxCode: "",
      director: "",
      enterpriseEmail: "",
      website: "",
      enterprisePhone: "",
      description: "",
      imageLogo: "",
      imageSrc: "",
      file: "",
      userName: "",
      addressCompany: "",
      addressCompanyList: [],
      fieldCompany: "",
      fieldCompanyList: [],
      editting: null,
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
    if (this.id != null) {
      await this.loadEnterprise();
    }
  },
  methods: {
    addAddress() {
      this.addressCompanyList.push({ detailAddress: this.addressCompany });
    },
    deleteList(item) {
      const index = this.addressCompanyList.indexOf(item);
      this.addressCompanyList.splice(index, 1);
    },
    addFieldCompany() {
      this.fieldCompanyList.push({ name: this.fieldCompany });
    },
    deleteFieldCompanyList(item) {
      const index = this.fieldCompanyList.indexOf(item);
      this.fieldCompanyList.splice(index, 1);
    },

    async loadEnterprise() {
      try {
        var enterprise = await this.$store.dispatch(
          "admin/loadEnterprise",
          this.id
        );
        if (enterprise.length == 0) {
          this.$toast.warning("Không thể tải doanh nghiệp!");
          this.$router.back();
        }
        this.enterpriseName = enterprise.name;
        this.corporateTaxCode = enterprise.corporateTaxCode;
        this.director = enterprise.director;
        this.enterpriseEmail = enterprise.email;
        this.website = enterprise.website;
        this.enterprisePhone = enterprise.phone;
        this.description = enterprise.description;
        this.imageLogo = enterprise.imageLogo;
        this.imageSrc = urlApi + enterprise.imageLogo;
        this.userName = enterprise.userName;
        this.userId = enterprise.userId;
        this.addressCompanyList = enterprise.addressCompanyList;
        this.fieldCompanyList = enterprise.fieldCompanyList;
      } catch (error) {
        this.$toast.error("Đã xảy ra lỗi trong quá trình tải!");
      }
    },
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
      this.imageSrc = window.URL.createObjectURL(this.file);
    },
    async onSubmit() {
      let postData = {
        name: this.enterpriseName,
        corporateTaxCode: this.corporateTaxCode,
        director: this.director,
        email: this.enterpriseEmail,
        website: this.website,
        phone: this.enterprisePhone,
        description: this.description,
        imageLogo: this.imageLogo,
        userName: this.userName,
        userId: this.userId,
        fieldCompanyList: this.fieldCompanyList,
        addressCompanyList: this.addressCompanyList
      };
      let payload = {
        enterpriseData: postData,
        fileUpload: this.file,
      };
      try {
        if (this.id == null) {
          let responData = await this.$store.dispatch(
            "admin/registerEnterprise",
            payload
          );
          if (responData == true) {
            this.$router.replace("/admin/enterprise");
            this.$toast.success(
              `Tạo tài khoản công ty ${this.enterpriseName} thành công.`
            );
          } else {
            this.$toast.warning(
              `Tên tài khoản của ${this.enterpriseName} đã bị trùng.`
            );
          }
        } else {
          payload.enterpriseData.id = this.id;
          let responData = await this.$store.dispatch(
            "admin/updateEnterprise",
            payload
          );
          if (responData == true) {
            this.$router.replace("/admin/enterprise");
            this.$toast.success(
              `Cập nhật tài khoản công ty ${this.enterpriseName} thành công.`
            );
          } else {
            this.$toast.warning(
              `Cập tài khoản công ty ${this.enterpriseName} không thành công.`
            );
          }
        }
      } catch (err) {
        this.$toast.error(err.mesage || "Đã xảy ra lỗi");
        this.$router.replace("/admin/enterprise");
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

.add-address, .field-company{
  white-space: nowrap;
    text-decoration: none;
    padding: 5px 10px;
    text-align: center;
    font: inherit;
    border: 2px solid #5b5b5b;
    color: #5b5b5b;
    cursor: pointer;
    border-radius: 4px;
    height: 56px;
    display: inline-block;
}

.delete{
  cursor: pointer;
    text-align: center;
    border: 2px solid #be0b0b;
    color: #ffffff;
    background: #be0b0b;
    border-radius: 4px;
    width: 35px;
    float: right;
}

.table-address{
  border: solid 1px #c7c7c7;
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