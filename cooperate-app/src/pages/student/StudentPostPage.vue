<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách đã apply</p>
      </div>
      <div class="row">
        <v-table fixed-header height="auto" class="table-employee">
          <thead>
            <tr>
              <th class="text-left">Tên bài đăng</th>
              <th class="text-left">Loại bài</th>
              <th class="text-left">Nhà tuyển dụng xác nhận</th>
              <th class="text-left">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in studentPosts.postList" :key="item.id">
              <td><router-link :to="`/enterprise/posts/${item.type}/detail/${item.id}`">{{
                item.title == null ? "#" : item.title
              }}</router-link></td>
              <td>{{ item.type == 1 ? "Tuyển dụng nhân viên" : "Tuyển thực tập sinh" }}</td>
              <td>
                <v-btn v-if="item.isAccept" class="ma-2" color="primary">
                  Đã Duyệt<v-icon end icon="mdi-checkbox-marked-circle"></v-icon>
                </v-btn>

                <v-btn v-else class="ma-2" color="red">
                  Chưa Được Duyệt<v-icon end icon="mdi-cancel"></v-icon>
                </v-btn>
              </td>
              <td>
                <button-base v-if="!item.isAccept" :class="'btn-delete'" @click="cancelApply(item)">Hủy ứng tuyển
                  <v-icon start icon="mdi-minus-circle"></v-icon></button-base>
                <v-badge  v-else content="Kiểm tra email của bạn" color="error">
                  <v-icon>mdi-bell-outline</v-icon>
                </v-badge>
              </td>
            </tr>
          </tbody>
        </v-table>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="page" class="my-4" :length="studentPosts.total"
                @update:modelValue="pagination"></v-pagination>
            </v-col>
          </v-row>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      studentPosts: [],
      page: 1,
    };
  },
  async created() {
    await this.loadStudentPosts();
  },
  methods: {
    pagination() {
      this.loadStudentPosts();
    },
    async loadStudentPosts() {
      try {
        this.studentPosts = await this.$store.dispatch(
          "student/applyCV",
          this.page
        );
        if (this.studentPosts.postList.length == 0) {
          this.$toast.warning("Bạn không apply CV nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải danh sách!");
      }
    },
    async cancelApply(event) {
      try {
        var result = await this.$store.dispatch(
          "student/cancelCV",
          event.id
        );
        if (result) {
          this.studentPosts.postList.splice(event, 1);
          this.$toast.warning("Bạn đã xóa ứng tuyển bài đăng!");
        }
      } catch (error) {
        this.$toast.error("Đã xảy ra lỗi trong quá trình thực hiện!");
      }
    },
    detailsLink(event) {
      return `/enterprise/posts/${event.type}/detail/` + event.id;
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

.box-title .btn-submit {
  margin: 4px;
}

.table-employee ::v-deep table {
  margin: 10px 0;
  border-radius: 7px;
  box-shadow: 2px 2px 8px rgb(1 1 1 / 26%);
  border: 1px solid #d6d6d6;
}
</style>