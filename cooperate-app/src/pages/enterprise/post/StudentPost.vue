<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách ứng viên "{{ students.postTitle }}"</p>
      </div>
      <div class="row">
        <v-table fixed-header height="auto" class="table-employee">
          <thead>
            <tr>
              <th class="text-left">Mã sinh viên</th>
              <th class="text-left">Tên sinh viên</th>
              <th class="text-left">Email</th>
              <th class="text-left">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in students.postList" :key="item.id">
              <td>{{ item.studentCode == null ? "#" : item.studentCode }} <a v-if="item.fileCV != null" :href="urlApi+item.fileCV" target="_blank">Xem CV</a></td>
              <td>{{ item.studentName == null ? "#" : item.studentName }}</td>
              <td>{{ item.studentCode == null ? "#" : item.studentCode+'@ute.udn.vn' }}</td>
              <td>
                <button-base :class="'btn-delete'" @click="accepted(item)">{{
                  item.isAccept ? "Không đồng ý" : "Đồng ý"
                }}</button-base>&nbsp;
              </td>
            </tr>
          </tbody>
        </v-table>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="page" class="my-4" :length="students.total"
                @update:modelValue="paginationStudentPost"></v-pagination>
            </v-col>
          </v-row>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import urlApi from "@/interceptors/url";
export default {
  props: ["id"],
  data: () => ({
    students: [],
    page: 1,
    urlApi: urlApi,
  }),
  async created() {
    await this.loadStudents();
  },
  methods: {
    paginationStudentPost() {
      this.loadStudents();
    },
    async loadStudents() {
      try {
        var payload = {
          id: this.id,
          page: this.page
        }
        this.students = await this.$store.dispatch("post/loadStudents", payload);
        if (this.students.length == 0) {
          this.$toast.warning("Không có sinh viên nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải danh sách sinh viên!");
      }
    },
    async accepted(event) {
      let payload = {
        postId: event.id,
        studentId: event.studentId,
        isAccepted: !event.isAccept
      };
      var accepted = await this.$store.dispatch("post/acceptedCV", payload);
      if (accepted) {
        this.students.postList.forEach((item) => {
          if (item == event) {
            item.isAccept = !item.isAccept;
          }
        })
        var message = !event.isAccept ? "hủy thành công" :"được đồng ý thành công."
        this.$toast.success(
          `Sinh viên: ${event.studentName} ${message}`
        );
      } else {
        this.$toast.error(`Đã xảy ra lỗi trong quá trình xử lý`);
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
</style>