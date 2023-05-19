<template>
  <div v-if="isShow" class="row box-item">
    <div class="col-sm-3">
      <image-post :image="image" class="card-img-top"></image-post>
    </div>
    <div class="col-sm-9">
      <div class="row">
        <div class="row box-company">
          <router-link :to="postDetailsLink">{{ title }}</router-link>
        </div>
        <div class="row box-description">
          <p
            v-html="
              description.length > 350
                ? description.substring(0, 350) + ' ...'
                : description
            "
          ></p>

          <div>
            <p class="display-date">{{ getFormattedDate(expireTime) }}</p>
            <v-icon size="12" icon="mdi-calendar"></v-icon>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-sm-4 box-btn">
          <button-base link class="" :to="applyCVLink" col="col-12"
            >{{ type == 3 ? "Danh sách tham gia" : "Danh sách ứng tuyển" }}
            <v-badge :content="post.numberNotification" color="error"><v-icon>mdi-bell-outline</v-icon>
            </v-badge>
          </button-base>
        </div>
        <div class="col-sm-4 box-btn">
          <button-base link class="btn-delete" :to="postEditLink" col="col-12"
            >Chỉnh sửa</button-base
          >
        </div>
        <div class="col-sm-4 box-btn">
          <button-base @click="deletePost()" class="btn-delete" col="col-12"
            >Xóa</button-base
          >
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import moment from "moment";
export default {
  props: ["post"],
  data() {
    return {
      id: this.post.id,
      title: this.post.title,
      description: this.post.description,
      quantity: this.post.quantity,
      image: this.post.image,
      imageByte: this.post.imageByte,
      expireTime: this.post.expireTime,
      viewNumber: this.post.viewNumber,
      enterpriseName: this.post.enterpriseName,
      userName: this.post.userName,
      majorsModels: this.post.majorsModels,
      type: this.post.type,
      isShow: true,
    };
  },
  computed: {
    postDetailsLink() {
      return this.$route.path + "/detail/" + this.id;
    },
    postEditLink() {
      return this.$route.path + "/edit/" + this.id;
    },
    applyCVLink() {
      if (this.type == 3) {
        return "/senimar-attend/" + this.id;
      }
      return "/apply-cv/" + this.id;
    },
  },
  methods: {
    async deletePost() {
      var removeData = await this.$store.dispatch("post/deletePost", this.id);
      if (removeData) {
        this.isShow = false;
        this.$toast.success(`Bài ${this.title} được xóa thành công.`);
      } else {
        this.$toast.error(`Bài ${this.title} xóa không thành công.`);
      }
    },
    getFormattedDate(date) {
      return moment(date).format("DD-MM-YYYY");
    },
  },
};
</script>
<style scoped>
.box-description {
  font-size: 16px;
  text-align: justify;
  margin-top: 15px;
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
.box-item {
  margin: 10px 0;
  border-radius: 10px 0px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
}

.box-item img {
  object-fit: cover;
  height: -webkit-fill-available;
}

.box-btn {
  padding: 5px;
  bottom: 0;
}

.box-left {
  justify-content: center;
  display: flex;
  flex-direction: column;
}

.box-card {
  border-radius: 10px 0px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
  margin: 0.5rem auto;
}

.box-card img {
  border-radius: 10px 0px 0px;
  max-height: 150px;
  height: 150px;
  object-fit: cover;
}

.card-body {
  padding: 0px 10px;
  max-height: 150px;
  height: 200px;
}

.box-company a {
  text-decoration: none;
  font-size: 16px;
  font-weight: bold;
  cursor: pointer;
  color: aliceblue;
}

.display-date {
  font-size: 12px;
  color: #3a3a3a;
  margin: 0px 0px;
  display: inline-block;
  padding: 5px;
}

.card-body .card-text {
  font-size: 14px;
  height: 150px;
}

.footer-card {
  padding: 10px 10px;
  align-items: center;
}

.box-company {
  background-color: #1F9AD6;
  color: aliceblue;
  font-size: 14px;
  padding: 5px 0px;
  box-shadow: 0 2px 8px rgb(0 0 0 / 26%);
}
</style>