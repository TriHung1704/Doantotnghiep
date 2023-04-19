<template>
  <section>
    <div class="box-title">
      <p>Trang chủ / Chi tiết bài tuyển dụng</p>
    </div>
    <br />
    <div class="row">
      <div class="col-sm-12">
        <div class="box about-comp">
          <div class="name-comp clearfix d-flex">
            <p class="img fl">
              <a href="/">
                <img
                  loading="lazy"
                  class="logo-company"
                  :src="imageLogoSrc == '' ? require('@/assets/' + 'company-default.png') : imageLogoSrc"
                  alt="Campany Logo"
              /></a>
            </p>
            <div class="box-company">
              <a href="#">
                <p class="comapny-name">
                  {{ post.enterprise.name }}
                </p>
              </a>
              <p class="text-justify">
                <a :href="'mailto: ' + post.enterprise.email"
                  >Liên hệ qua email</a
                >
                -
                <a :href="post.enterprise.website">Website doanh nghiệp</a>
              </p>
            </div>
          </div>
        </div>
      </div>
      <div class="col-sm-8">
        <div class="left-content">
          <span>{{ post.title }}</span>
          <div class="box-description" v-html="post.description"></div>
          <image-post :image="imageSrc" class="img-post"></image-post>
        </div>
      </div>
      <div class="col-sm-4">
        <div class="right-content">
          <div class="button-content">
            <access-roles-base :accessRoles="['Student']">
              <button-base
                v-if="post.type == 3"
                :disabled="post.isSeen || requiredDate"
                class="btn-submit"
                @click="senimarAttends()"
                >Tham gia ngay
                <v-badge v-if="post.isSeen" content="Đã đăng kí" color="error">
                  <v-icon>mdi-send</v-icon>
                </v-badge></button-base
              >
              <button-base
                v-else
                :disabled="post.isSeen || requiredDate"
                class="btn-submit"
                @click="recruitmentCV()"
                >Ứng tuyển ngay
                <v-badge
                  v-if="post.isSeen"
                  content="Đã ứng tuyển"
                  color="error"
                >
                  <v-icon>mdi-send</v-icon>
                </v-badge></button-base
              >
              <span>Hoặc</span>
            </access-roles-base>

            <button-base
              ><span :title="post.enterprise.phone"
                >Liên hệ qua SĐT</span
              ></button-base
            >
            <span :class="requiredDate ? 'text-red' : ''"
              >Hạn cuối: {{ getFormattedDate(post.expireTime) }}
              <v-icon size="12" icon="mdi-calendar"></v-icon
            ></span>
          </div>
          <hr />
          <div class="company-info">
            <span class="company-title">Thông tin công ty</span>
            <div class="company-des">
              <span>Doanh nghiệp</span>
              <p>{{ post.enterprise.name }}</p>
              <span>Địa chỉ</span>
              <ol>
                <li
                  v-for="facility in post.enterpriseFacilities"
                  :key="facility.id"
                >
                  {{ facility.name + " - " + facility.provinceAddress }}
                </li>
              </ol>
              <span>Ngành nghề</span>
              <ol>
                <li v-for="field in post.enterpriseFields" :key="field.id">
                  {{ field.name }}
                </li>
              </ol>
            </div>
          </div>
          <hr />
          <div class="company-info">
            <span class="company-title">Chuyên ngành liên quan</span>
            <div class="majors-related">
              <div v-for="majors in post.majorsModels" :key="majors.id">
                {{ majors.majorsName }}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
import moment from "moment";
import urlApi from "@/interceptors/url";
export default {
  props: ["id"],
  data() {
    return {
      post: null,
      imageSrc: null,
      imageLogoSrc: null,
    };
  },
  async created() {
    await this.loadPost();
  },
  computed:{
    requiredDate() {
      let date = moment(this.post.expireTime).format("YYYY-MM-DD")
      console.log(date);
      return moment(date) < moment(new Date());
    },
  },
  methods: {
    async loadPost() {
      try {
        this.post = await this.$store.dispatch("post/loadPost", this.id);
        if (this.post.enterprise.imageLogo == null || this.post.enterprise.imageLogo == "") {
          this.imageLogoSrc = "";
        }else{
          this.imageLogoSrc = urlApi + this.post.enterprise.imageLogo;
        }
        if (this.post.length == 0) {
          this.$toast.warning("Không có bài tuyển dụng nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải bài bài tuyển dụng!");
      }
    },
    async recruitmentCV() {
      try {
        var result = await this.$store.dispatch(
          "student/recruitmentCV",
          this.id
        );
        if (result) {
          this.post.isSeen = true;
          this.$toast.success(
            "Bạn đã ứng tuyển! Hãy đợi nhà tuyển dụng xác nhận..."
          );
        } else {
          this.$toast.warning("Ứng tuyển không thành công!");
        }
      } catch (error) {
        this.$toast.error("Không thể ứng tuyển!");
      }
    },
    async senimarAttends() {
      try {
        var result = await this.$store.dispatch(
          "student/senimarAttend",
          this.id
        );
        if (result) {
          this.post.isSeen = true;
          this.$toast.success("Bạn đã đăng kí tham gia!");
        } else {
          this.$toast.warning("Đăng ki tham gia không thành công!");
        }
      } catch (error) {
        this.$toast.error("Không thể tham gia!");
      }
    },
    getFormattedDate(date) {
      return moment(date).format("YYYY-MM-DD");
    }
  },
};
</script>
<style scoped>
.box-title {
  margin-top: 10px;
  border: 1px solid;
  background: #222831;
  color: white;
}

.box-title p {
  padding: 12px 10px;
  display: inline-block;
  margin-bottom: 0;
}

.left-content {
  display: flex;
  flex-direction: column;
  min-width: 0;
  word-wrap: break-word;
  background-color: #fff;
  background-clip: border-box;
  border: 1px solid rgba(0, 0, 0, 0.125);
  border-radius: 0.25rem;
  padding: 5px;
}

.left-content span {
  background-color: darkolivegreen;
  color: aliceblue;
  font-size: 16px;
  /* text-align: center; */
  padding: 5px 5px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
}
.right-content {
  padding: 5px;
  /* position: relative; */
  display: flex;
  flex-direction: column;
  min-width: 0;
  word-wrap: break-word;
  background-color: #fff;
  background-clip: border-box;
  border: 1px solid rgba(0, 0, 0, 0.125);
  border-radius: 0.25rem;
}

span.text-red{
  color: red;
}

.button-content {
  text-align: center;
  /* position: relative; */
  display: flex;
  flex-direction: column;
  min-width: 0;
  word-wrap: break-word;
}

.button-content span {
  padding: 5px;
  font-size: 14px;
  color: rgb(49, 53, 53);
}

.button-content div button {
  width: 100%;
}

.logo-company {
  max-height: 100px;
}

.img.fl {
  border: 1px solid hsla(0, 0%, 80%, 0.8);
  box-shadow: 0 4px 6px 0 rgb(0 0 0 / 20%);
}

.box-company {
  padding-left: 10px;
}

.company-info .company-title {
  text-align: center;
  display: flex;
  flex-direction: column;
  min-width: 0;
  word-wrap: break-word;
  font-size: 16px;
  font-weight: 700;
}

.company-info .company-des span {
  word-wrap: break-word;
  font-size: 16px;
  font-weight: 500;
}
.company-info .company-des p,
.company-info .company-des ol {
  word-wrap: break-word;
  font-size: 14px;
}

.box-company a {
  text-decoration: none;
  color: inherit;
}
.box-company .comapny-name {
  font-weight: 700;
  font-size: 20px;
}
.box-description {
  font-size: 16px;
  text-align: justify;
}
.box-description::v-deep h1 {
  font-size: 16px;
  text-align: justify;
}
.box-description::v-deep h2 {
  font-size: 14px;
}
.box-description::v-deep h3 {
  font-size: 12px;
}
.box-description::v-deep ul,
.box-description::v-deep p,
.box-description::v-deep ol {
  font-size: 14px;
}
.majors-related div {
  margin: 5px;
  display: inline-flex;
  font-size: 14px;
  white-space: nowrap;
  text-align: center;
  width: fit-content;
  padding: 5px 5px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
}
</style>