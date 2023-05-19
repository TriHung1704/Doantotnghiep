<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Tin tức mới nhất</p>
      </div>
      <div class="row">
        <noti-item-base :class="'col-lg-4'" v-for="post in postsNoti.postList" :key="post.id"
          :post="post"></noti-item-base>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="pageNoti" class="my-4" :length="postsNoti.total"
                @update:modelValue="paginationNoti"></v-pagination>
            </v-col>
          </v-row>
        </div>
      </div>
      <div class="box-title">
        <p>Trang chủ / Tuyển dụng</p>
      </div>
      <div class="row">
        <card-base :class="'col-lg-4'" v-for="post in postsRecruitment.postList" :key="post.id" :post="post"></card-base>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="pageRecruitment" class="my-4" :length="postsRecruitment.total"
                @update:modelValue="paginationRecruitment"></v-pagination>
            </v-col>
          </v-row>
        </div>
      </div>
    </div>
    <div class="box-title">
      <p>Trang chủ / Thực tập sinh</p>
    </div>
    <div class="row">
      <card-base :class="'col-lg-4'" v-for="post in postsInternship.postList" :key="post.id" :post="post"></card-base>
      <div class="text-center">
        <v-row justify="center">
          <v-col cols="6">
            <v-pagination v-model="pageInternship" class="my-4" :length="postsInternship.total"
              @update:modelValue="paginationInternship"></v-pagination>
          </v-col>
        </v-row>
      </div>
    </div>

    <div class="box-title">
      <p>Trang chủ / Hội thảo công nghệ</p>
    </div>
    <div class="row">
      <card-base v-for="post in postsSeminar.postList" :key="post.id" :post="post"></card-base>
      <div class="text-center">
        <v-row justify="center">
          <v-col cols="6">
            <v-pagination v-model="pageSeminar" class="my-4" :length="postsSeminar.total"
              @update:modelValue="paginationSeminar"></v-pagination>
          </v-col>
        </v-row>
      </div>
    </div>
  </div>
</template>
<script>
import NotiItemBase from '@/components/ui/NotiItemBase.vue';
export default {
  components: { NotiItemBase },
  data: () => ({
    pageRecruitment: 1,
    pageInternship: 1,
    pageSeminar: 1,
    pageNoti: 1,
    postsRecruitment: [],
    postsInternship: [],
    postsSeminar: [],
    postsNoti: [],
  }),
  methods: {
    paginationRecruitment() {
      this.loadPostsRecruitment();
    },
    paginationInternship() {
      this.loadPostsInternship();
    },
    paginationSeminar() {
      this.loadPostsSeminar();
    },
    paginationNoti() {
      this.loadPostsNoti();
    },
    async loadPostsRecruitment() {
      try {
        var payloadRecruitment = {
          type: "recruitment",
          page: this.pageRecruitment,
        };
        this.postsRecruitment = await this.$store.dispatch(
          "post/loadPosts",
          payloadRecruitment
        );
        if (this.postsRecruitment.length == 0) {
          this.$toast.warning("Không có bài tuyển dụng nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải bài các bài tuyển dụng!");
      }
    },
    async loadPostsInternship() {
      try {
        var payloadInternship = {
          type: "internship",
          page: this.pageInternship,
        };
        this.postsInternship = await this.$store.dispatch(
          "post/loadPosts",
          payloadInternship
        );
        if (this.postsInternship.length == 0) {
          this.$toast.warning("Không có bài tuyển thực tập sinh nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải bài các bài tuyển thực tập sinh!");
      }
    },
    async loadPostsSeminar() {
      try {
        var payloadSeminar = {
          type: "seminar",
          page: this.pageSeminar,
        };
        this.postsSeminar = await this.$store.dispatch(
          "post/loadPosts",
          payloadSeminar
        );
        if (this.postsSeminar.length == 0) {
          this.$toast.warning("Không có bài hội thảo nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải bài các bài hội thảo!");
      }
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
  },
  async created() {
    await this.loadPostsRecruitment();
    await this.loadPostsInternship();
    await this.loadPostsSeminar();
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

.v-row {
  display: flex;
  flex-wrap: wrap;
  flex: 1 1 auto;
  margin: -32px;
  
  
}
.row {
    flex-shrink: 0;
    width: 100%;
    max-width: 100%;
    padding: 10px 10px;
    margin-top: 10px;
    text-align: left;
    }
</style>