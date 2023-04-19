<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Tin tức mới nhất</p>
      </div>
      <div class="row">
        <noti-item-base
          :class="'col-sm-4'"
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
</template>
<script>
import NotiItemBase from "@/components/ui/NotiItemBase.vue";
export default {
  components: { NotiItemBase },
  data: () => ({
    pageNoti: 1,
    postsNoti: [],
  }),
  methods: {
    paginationNoti() {
      this.loadPostsNoti();
    },
    async loadPostsNoti() {
      var payload = {
        page: this.pageNoti,
        number: 20,
      };
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
  },
  async created() {
    await this.loadPostsNoti();
  },
  computed: {},
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
}
</style>