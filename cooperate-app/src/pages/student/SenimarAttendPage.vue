<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách hội thảo đã đăng kí tham gia</p>
      </div>
      <div class="row">
        <v-table fixed-header height="auto" class="table-employee">
          <thead>
            <tr>
              <th class="text-left">Tên hội thảo</th>
              <th class="text-left">Hạn cuối</th>
              <th class="text-left">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in senimarAttends.postList" :key="item.id">
              <td><router-link :to="`/enterprise/posts/${item.type}/detail/${item.id}`">{{
                item.title == null ? "#" : item.title
              }}</router-link></td>
              <td>{{ getFormattedDate(item.expireTime) }}</td>
              <td>
                <button-base
                  v-if="!item.IsExpire"
                  :class="'btn-delete'"
                  @click="cancelSenimarAttend(item)"
                  >Hủy tham gia
                  <v-icon start icon="mdi-minus-circle"></v-icon></button-base>
                  <v-badge v-else content="Không thể hủy tham gia" color="error">
                    <v-icon>mdi-bell-outline</v-icon>
                  </v-badge>
              </td>
            </tr>
          </tbody>
        </v-table>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination
                v-model="page"
                class="my-4"
                :length="senimarAttends.total"
                @update:modelValue="pagination"
              ></v-pagination>
            </v-col>
          </v-row>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import moment from 'moment';
export default {
  data() {
    return {
      senimarAttends: [],
      page: 1,
    };
  },
  async created() {
    await this.loadSenimarAttend();
  },
  methods: {
    getFormattedDate(date) {
      return moment(date).format("YYYY-MM-DD")
    },
    pagination() {
      this.loadSenimarAttend();
    },
    async loadSenimarAttend() {
      try {
        this.senimarAttends = await this.$store.dispatch(
          "student/loadSenimarAttends",
          this.page
        );
        if (this.senimarAttends.postList.length == 0) {
          this.$toast.warning("Bạn không đăng kí tham gia hội thảo nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải danh sách!");
      }
    },
    async cancelSenimarAttend(event){
      try {
        var result = await this.$store.dispatch(
          "student/cancelSenimarAttend",
          event.id
        );
        if (result) {
          this.senimarAttends.postList.splice(event, 1);
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