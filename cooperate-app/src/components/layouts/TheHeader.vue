<template>
  <header>
    <ul class="sidenav">
      <li>
        <a href="/">Trường Đại học Sư phạm Kỹ thuật - Đại học Đà Nẵng</a>
      </li>
      <li>
        <a href="/">Hợp tác - Phát triển cùng Doanh nghiệp</a>
      </li>
      <li v-if="!isLoggedIn" style="float: right; cursor: pointer">
        <a @click="openModal">Đăng nhập</a>
      </li>
      <li v-else style="float: right; cursor: pointer">
        <v-menu location="bottom">
          <template v-slot:activator="{ props }">
            <a v-bind="props"><img class="img-avatar" v-if="!!avatar" :src="avatar" />{{
              fullName
            }}</a>
          </template>
          <v-list>
            <v-list-item @click="profile()" prepend-icon="mdi-account" title="Trang cá nhân">
            </v-list-item>
            <!-- Nhân viên tuyển dụng -->
            <access-roles-base :accessRoles="['EmployeeHRM']">
              <v-list-item @click="postsRecruitment()" prepend-icon="mdi-folder-open"
                title="Quản lý bài tuyển dụng"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['EmployeeHRM']">
              <v-list-item @click="postsInternship()" prepend-icon="mdi-folder-open"
                title="Quản lý bài thực tập"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['EmployeeHRM']">
              <v-list-item @click="postsSeminar()" prepend-icon="mdi-folder-open"
                title="Quản lý bài hội thảo"></v-list-item>
            </access-roles-base>
            <!-- Nhân viên Admin -->
            <access-roles-base :accessRoles="['EmployeeAdmin']">
              <v-list-item @click="employee()" prepend-icon="mdi-folder-open" title="Quản lý nhân viên"></v-list-item>
            </access-roles-base>
            <!-- Sinh viên -->
            <access-roles-base :accessRoles="['Student']">
              <v-list-item @click="curriculumVitae()" prepend-icon="mdi-folder-open" title="Quản lý CV"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['Student']">
              <v-list-item @click="applyCV()" prepend-icon="mdi-folder-open" title="Quản lý ứng tuyển"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['Student']">
              <v-list-item @click="senimarAttend()" prepend-icon="mdi-folder-open"
                title="Hội thảo tham gia"></v-list-item>
            </access-roles-base>
            <!-- Admin -->
            <access-roles-base :accessRoles="['Administrator']">
              <v-list-item @click="postNotification()" prepend-icon="mdi-folder-open"
                title="Đăng thông báo"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['Administrator']">
              <v-list-item @click="banner()" prepend-icon="mdi-folder-open" title="Quản lý banner"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['Administrator']">
              <v-list-item @click="student()" prepend-icon="mdi-folder-open"
                title="Quản lý tài khoản sinh viên"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['Administrator']">
              <v-list-item @click="enterprise()" prepend-icon="mdi-folder-open"
                title="Quản lý tài khoản doanh nghiệp"></v-list-item>
            </access-roles-base>
            <access-roles-base :accessRoles="['Administrator']">
              <v-list-item @click="enterprisePost()" prepend-icon="mdi-folder-open"
                title="Quản lý bài đăng doanh nghiệp"></v-list-item>
            </access-roles-base>
            <v-list-item @click="logout()" prepend-icon="mdi-lock" title="Đăng xuất">
            </v-list-item>
          </v-list>
        </v-menu>
      </li>
    </ul>
    <div class="logo">
      <v-img :src="'http://localhost:44647/' + bannerSrc" />
    </div>
    <ul class="menunav">
      <li><router-link to="/home">TRANG CHỦ</router-link></li>
      <li><router-link to="/recruitment">TUYỂN DỤNG</router-link></li>
      <li><router-link to="/internship">THỰC TẬP</router-link></li>
      <li><router-link to="/senimar">HỘI THẢO</router-link></li>
      <li><router-link to="/notification">THÔNG BÁO</router-link></li>
      <li><router-link to="/information">GIỚI THIỆU</router-link></li>
    </ul>
    <dialog-base :show="isShowModal" title="Đăng nhập hệ thống" @close="closeModal">
      <v-form v-model="form" @submit.prevent="onSubmit">
        <v-text-field v-model="userName" :readonly="loading" :rules="[required]" clearable label="Tài khoản"
          prepend-inner-icon="mdi-account" variant="outlined" autocomplete="null"></v-text-field>

        <v-text-field v-model="password" :readonly="loading" :rules="[required]" clearable autocomplete="null"
          label="Mật khẩu" prepend-inner-icon="mdi-lock" variant="outlined" type="password"></v-text-field>
        <br />
        <v-btn :disabled="!form" :loading="loading" block color="success" size="large" type="submit" variant="elevated">
          Đăng nhập
        </v-btn>
      </v-form>
    </dialog-base>
  </header>
</template>

<script>
import urlApi from "@/interceptors/url";
export default {
  components: {},
  data() {
    return {
      isShowModal: false,
      form: false,
      userName: null,
      password: null,
      loading: false,
      selected: false,
      message: "",
      bannerSrc: null,
    };
  },
  async created() {
    await this.loadSlide();
  },
  computed: {
    isActiveLoader() {
      return this.$store.getters.isActiveLoader;
    },
    fullName() {
      return this.$store.getters.fullName;
    },
    avatar() {
      return urlApi + this.$store.getters.avatar;
    },
    isLoggedIn() {
      return this.$store.getters.isAuthenticated;
    },
  },
  methods: {
    async loadSlide() {
      var data = await this.$store.dispatch("getSlide");
      var dataEnabled = data.filter((e) => e.isEnable == true);
      if (dataEnabled.length > 0) {
        this.bannerSrc = dataEnabled[0].image;
      }
    },
    postsSeminar() {
      this.$router.replace("/enterprise/posts/seminar");
    },
    postsRecruitment() {
      this.$router.replace("/enterprise/posts/recruitment");
    },
    postsInternship() {
      this.$router.replace("/enterprise/posts/internship");
    },
    banner() {
      this.$router.replace("/admin/banner");
    },
    student() {
      this.$router.replace("/admin/student");
    },
    enterprise() {
      this.$router.replace("/admin/enterprise");
    },
    postNotification() {
      this.$router.replace("/admin/post/notification");
    },
    employee() {
      this.$router.replace("/enterprise/employee");
    },
    curriculumVitae() {
      this.$router.replace("/curriculum-vitae");
    },
    applyCV() {
      this.$router.replace("/apply-curriculum-vitae");
    },
    senimarAttend() {
      this.$router.replace("/senimar-attend");
    },
    enterprisePost() {
      this.$router.replace("/admin/enterprise-post");
    },
    profile() {
      this.$router.replace("/profile");
    },
    openModal() {
      this.isShowModal = true;
    },
    logout() {
      this.$store.dispatch("logout");
      this.$router.go();
    },
    closeModal() {
      this.isShowModal = false;
    },
    async onSubmit() {
      if (!this.form) return;
      this.loading = true;
      const actionPayload = {
        userName: this.userName,
        password: this.password,
      };
      try {
        await this.$store.dispatch("login", actionPayload);
        // this.message = "Đăng nhập thành công!";
        // this.closeModal();
        this.$router.go();
        // this.$toast.success(this.message);
        // this.$router.replace("/home");
      } catch (err) {
        this.message = "Đăng nhập thất bại!";
        this.$toast.warning(this.message);
      }
      this.loading = false;
    },
    required(v) {
      return !!v || "Không được để trống";
    },
  },
};
</script>
<style scoped>
.example-slide {
  align-items: center;
  background-color: #666;
  color: #999;
  display: block;
  font-size: 1.5rem;
  justify-content: center;
  min-height: 200px;
}

.logo div {
  /* max-height: 200px;
  height: 200px;
  width: 75%;
  display: inline-block;
  object-fit: cover; */
}

.box-login {
  float: right;
  cursor: pointer;
}

ul.sidenav {
  list-style-type: none;
  background-color: #222831;
  list-style-type: none;
  margin: 0;
  padding: 5px;
  overflow: hidden;
  position: fixed;
  width: -webkit-fill-available;
  z-index: 100;
  font-family: "Arial", sans-serif;
}

ul.sidenav li {
  float: left;
  border-right: 1px solid #bbb;
}

ul.sidenav li a {
  font-size: 12px;
  font-weight: bold;
  display: block;
  color: white;
  text-align: center;
  padding: 0px 16px;
  text-decoration: none;
}

ul.sidenav li a i {
  background: rgb(241, 241, 223);
  border-radius: 50%;
}

.logo {
  padding: 10px;
  padding-top: 40px;
}

.logo img {
  width: 25%;
}

ul.menunav {
  list-style-type: none;
  margin: 0;
  padding: 0;
  width: 25%;
  background-color: #f1f1f1;
  position: fixed;
  height: 100%;
  overflow: auto;
  font-family: "Arial", sans-serif;

}

ul.menunav li a {
  display: block;
  color: #000;
  padding: 8px 16px;
  text-decoration: none;
}

ul.menunav li a.active {
  background-color: #4caf50;
  color: white;
}

ul.menunav li a:hover:not(.active) {
  background-color: #555;
  color: white;
}

div.content {
  margin-left: 25%;
  padding: 1px 16px;
  height: 1000px;
}

@media screen and (max-width: 3000px) {
  ul.menunav {
    width: 92%;
    height: auto;
    position: inherit;
    margin: auto;
  }

  ul.menunav li a {
    float: left;
    padding: 15px;
  }

  div.content {
    margin-left: 0;
  }
}

@media screen and (max-width: 400px) {
  ul.menunav li a {
    text-align: center;
    float: none;
  }
}

ul.menunav li a:hover,
ul.menunav li a.router-link-active {
  background-color: #77c77a;
  color: white;
  border-bottom: 3px solid red;
}

h1 {
  margin: 0;
}

h1 a {
  color: white;
  margin: 0;
}

.img-avatar {
  height: 20px;
  width: 20px;
  border-radius: 50%;
  border: solid 1px;
  margin-right: 5px;
}
</style>
