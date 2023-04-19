<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách thông báo</p>
      </div>
      <div class="row mt-1">
        <div class="col-sm-6">
          <button-base
            :col="'col-12'"
            :class="'btn-submit'"
            link
            :to="registerPostLink"
            >Tạo bài mới</button-base
          >
        </div>
        <div class="col-sm-6">
          <button-base :col="'col-12'" link :to="'/'"
            >Quay về trang chính</button-base
          >
        </div>
      </div>
      <div>
        <notification-base
          v-for="post in posts.postList"
          :key="post.id"
          :id="post.id"
          :post="post"
        ></notification-base>
      </div>
      <div class="text-center">
        <v-row justify="center">
          <v-col cols="6">
            <v-pagination
              v-model="page"
              class="my-4"
              :length="posts.total"
              @update:modelValue="paginationNoti"
            ></v-pagination>
          </v-col>
        </v-row>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data: () => ({
    page: 1,
    posts: [],
  }),
  methods: {
    paginationNoti() {
      this.loadPosts();
    },
    async loadPosts() {
      var payload = {
        page: this.page,
        number: 10
      }
      try {
        this.posts = await this.$store.dispatch(
          "admin/loadNotification",
          payload
        );
        if (this.posts.length == 0) {
          this.$toast.warning(`Không có thông báo nào!`);
        }
      } catch (error) {
        this.$toast.error("Không thể tải bài các thông báo!");
      }
    },
  },
  async created() {
    await this.loadPosts();
  },
  computed: {
    registerPostLink() {
      return this.$route.path + "/register";
    },
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
.box-title .btn-submit {
  margin: 4px;
}
</style>