<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách bài đăng</p>
      </div>
      <div class="row mt-1">
        <div class="col-sm-12 text-center">
          <v-radio-group v-model="inline" inline>
            <v-radio label="Bài tuyển dụng" color="red" :value="1"></v-radio>
            <v-radio label="Bài tuyển thực tập sinh" color="red" :value="2"></v-radio>
            <v-radio label="Bài tổ chức hội thảo" color="red" :value="3"></v-radio>
          </v-radio-group>
        </div>
      </div>
      <div class="row">
        <v-table fixed-header height="auto" class="table-employee">
          <thead>
            <tr>
              <th class="text-left">Tên bài đăng</th>
              <th class="text-left">Doanh nghiệp</th>
              <th class="text-left">Ngày đăng</th>
              <th class="text-left">Hạn cuối</th>
              <th class="text-left">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in posts.postList" :key="item.id">
              <td>
                <router-link :to="`/enterprise/posts/${item.type}/detail/${item.id}`">{{ item.title }}</router-link>
              </td>
              <td>
                {{ item.enterpriseName == null ? "#" : item.enterpriseName }}
              </td>
              <td>
                {{
                  item.createAt == null ? "#" : getFormattedDate(item.createAt)
                }}
              </td>
              <td>
                {{
                  item.expireTime == null
                  ? "#"
                  : getFormattedDate(item.expireTime)
                }}
              </td>
              <td>
                <button-base :class="'btn-delete'" @click="confirmPost(item)">{{
                  !item.status ? "Duyệt" : "Không duyệt"
                }}</button-base>&nbsp;
                <v-icon v-if="!item.status">mdi-lock</v-icon>
              </td>
            </tr>
          </tbody>
        </v-table>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="page" class="my-4" :length="posts.total"
                @update:modelValue="paginationPost"></v-pagination>
            </v-col>
          </v-row>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import moment from "moment";
export default {
  data() {
    return {
      posts: [],
      page: 1,
      inline: 1,
    };
  },
  async created() {
    await this.loadPosts();
  },
  watch: {
    inline(newType, oldType) {
      if (newType != oldType) {
        this.loadPosts();
      }
    },
  },
  methods: {
    paginationPost() {
      this.loadPosts();
    },
    getFormattedDate(date) {
      return moment(date).format("DD-MM-YYYY");
    },
    async loadPosts() {
      try {
        let payload = {
          type: this.inline,
          page: this.page,
          limit: 20,
        };
        this.posts = await this.$store.dispatch(
          "admin/loadPostsEnterprises",
          payload
        );
        if (this.posts.postList.length == 0) {
          this.$toast.warning("Không có bài đăng nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải danh sách bài đăng!");
      }
    },
    async confirmPost(event) {
      let postData = {
        id: event.id,
        isConfirm: !event.status,
      };
      var removeData = await this.$store.dispatch(
        "admin/confirmPostEnterprise",
        postData
      );
      if (removeData) {
        this.posts.postList.forEach((item) => {
          if (item == event) {
            item.status = !item.status;
          }
        });
        if (!event.status) {
          this.$toast.warning(`Bài đăng: ${event.title} không được duyệt.`);
        } else {
          this.$toast.success(`Bài đăng: ${event.title} được duyệt.`);
        }
      } else {
        this.$toast.error(`Xử lý: ${event.title} không thành công.`);
      }
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

.table-employee ::v-deep table {
  margin: 10px 0;
  border-radius: 7px;
  box-shadow: 2px 2px 8px rgb(1 1 1 / 26%);
  border: 1px solid #d6d6d6;
}

.v-selection-control-group {
  display: block;
}
</style>