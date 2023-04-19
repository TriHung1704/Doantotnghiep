<template>
  <section>
    <div class="box-title">
      <p>Trang chủ / Chi tiết thông báo</p>
    </div>
    <br />
    <div class="row">
      <div class="col-sm-8">
        <div class="left-content">
          <span>{{ title }}</span>
          <div class="box-description" v-html="description"></div>
          <div class="text-right">
            <p class="text-right display-date">
              {{ getFormattedDate(createAt) }}
            </p>
            <v-icon size="12" icon="mdi-calendar"></v-icon>
          </div>
          <image-post
            v-if="image != ''"
            :image="image"
            class="img-post"
          ></image-post>
        </div>
      </div>
      <div class="col-sm-4">
        <div class="right-content row">
          <span>Thông báo gần đây</span>
          <noti-item-base :col="'col-sm-12'"
            v-for="post in postsNoti.postList"
            :key="post.id"
            :post="post"
          ></noti-item-base>
          <div class="text-center">
            <v-row justify="center">
              <v-col cols="6">
                <v-pagination
                  v-model="pageNoti"
                  class="my-4"
                  :length="postsNoti.total"
                  @update:modelValue="paginationNoti"
                ></v-pagination>
              </v-col>
            </v-row>
          </div>
        </div>
        
      </div>
    </div>
  </section>
</template>
<script>
import moment from "moment";
export default {
  props: ["id"],
  data() {
    return {
      title: "",
      description: "",
      image: "",
      createAt: null,
      postsNoti: [],
      pageNoti: 1,
    };
  },
  async created() {
    await this.loadPost();
    await this.loadPostsNoti();
  },
  methods: {
    paginationNoti() {
      this.loadPostsNoti();
    },
    async loadPostsNoti() {
      var payload = {
        page: this.pageNoti,
        number: 6
      }
      try {
        this.postsNoti = await this.$store.dispatch(
          "admin/loadNotification",
          payload
        );
        if (this.postsNoti.length == 0) {
          this.$toast.warning("Không có thông báo nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải các thông báo!");
      }
    },
    async loadPost() {
      try {
        var postData = await this.$store.dispatch("admin/loadPost", this.id);
        if (postData.length == 0) {
          this.$toast.warning("Không thể tải bài tuyển dụng!");
          this.$router.back();
        }
        this.title = postData.title;
        this.description = postData.description;
        this.image = postData.image;
        this.createAt = postData.createAt;
      } catch (error) {
        this.$toast.error("Đã xảy ra lỗi trong quá trình tải!");
      }
    },
    getFormattedDate(date) {
      return moment(date).format("YYYY-MM-DD");
    },
  },
  watch: {
    id(newId, oldId) {
        if (newId != oldId) {
            this.loadPost();
        }
    }
  }
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
.right-content span {
  background-color: rgb(214, 65, 65);
  color: aliceblue;
  font-size: 16px;
  text-align: center;
  padding: 5px 5px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
}
.right-content {
  padding: 5px;
  /* position: relative; */
  /* display: flex;
  flex-direction: column; */
  min-width: 0;
  word-wrap: break-word;
  background-color: #fff;
  background-clip: border-box;
  border: 1px solid rgba(0, 0, 0, 0.125);
  border-radius: 0.25rem;
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

.display-date {
  font-size: 10px;
  color: #3a3a3a;
  margin: 0px 0px;
  display: inline-block;
  padding: 5px;
}
</style>