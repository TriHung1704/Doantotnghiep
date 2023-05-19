<template>
  <section>
    <div class="box-title">
      <p>Thông tin cá nhân</p>
    </div>
    <br />
    <div class="row box-profile">
      <div class="col-sm-4">
        <div class="col-sm-12">

          <img class="image-preview" :src="user.avatar" />
        </div>
      </div>
      <div class="col-sm-8">
        <div class="row">
          <div class="col-sm-5">
            <span class="title"><b>Họ tên:</b> {{ user.fullName == null ? "#" : user.fullName }}</span>
          </div>
          <div class="col-sm-5">
            <span class="title"><b>Email:</b> {{ user.email == null ? "#" : user.email }}</span>
          </div>
         
          <div class="col-sm-5">
            <span class="title"><b>Số điện thoại:</b> {{ user.phone == null ? "#" : user.phone }}</span>
          </div>
         
          <div class="col-sm-5">
            <span class="title"><b>Địa chỉ: </b> {{ user.provinceAddress == null ? "#" : user.provinceAddress }}</span>
          </div>
         
          <div class="col-sm-5">
            <span class="title"><b>Địa chỉ cụ thể:</b> {{ user.detailAddress == null ? "#" : user.detailAddress }}</span>
          </div>
          
          <div class="col-sm-5">
            <span class="title"><b>Giới tính:</b>  {{ user.gender == 1 ? "Nam" : "Nữ" }}</span>
          </div>
          
          <div class="col-sm-5">
            <span class="title"><b>Ngày sinh:</b> {{ getFormattedDate(user.birthday).includes("0001-01-01") ? "#" :
              getFormattedDate(user.birthday) }}</span>
          </div>
          
        </div>
      </div>

    </div>
  </section>
</template>
<script>
import urlApi from "@/interceptors/url";
import moment from "moment";
export default {
  props: ["id"],
  data() {
    return {
      user: []
    };
  },
  async created() {
    await this.loadUser();
  },
  methods: {
    async loadUser() {
      try {
        this.user = await this.$store.dispatch(
          "student/loadUser",
          this.id
        );
        if (this.user == null) {
          this.$toast.warning("Không thể tải thông tin cá nhân!");
        }
        this.user.avatar = urlApi + this.user.avatar;
      } catch (error) {
        this.$toast.error("Đã xảy ra lỗi trong quá trình tải!");
      }
    },
    getFormattedDate(date) {
      return moment(date).format("DD-MM-YYYY");
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
  max-width: 100%;
  border: 2px solid rgba(206, 159, 159, 0.5);
  border-radius: 10px;
  padding: 10px;
  box-shadow: 0px 0px 10px rgba(206, 159, 159, 0.5);
}

.box-profile {
  min-height: 250px;
  max-width: 100%;
  border-radius: 10px;
  padding: 10px 10px;
  box-shadow: 0px 0px 20px rgba(206, 159, 159, 1);
  margin: 10px 30px 30px 30px;
}

.title {
  font-size: 16px;
color: black;
font-weight: 500;
  
}


.col-sm-4 {
  flex: 0 0 auto;
  width: 20%;
}
.col-sm-8 {
    flex: 0 0 auto;
    width: 80%;
    line-height: 2;
    text-align: left;}
    span b {
  color: black
}
</style>