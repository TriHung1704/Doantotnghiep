<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách sinh viên</p>
      </div>
      <div class="row mt-1">
        <div class="col-sm-12">
          <div class="col-sm-2 d-inline-block">
            <button-base :disabled="isDisabled" @click="registerStudent()" :class="'btn-submit'">Thêm sinh viên</button-base>
          </div>
          <div class="col-sm-10 d-inline-block">
            <v-file-input
              accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel"
              id="file" ref="file" @change="handleFileUpload()" label="Chọn file" variant="outlined" dense></v-file-input>
          </div>
        </div>
      </div>
      <div class="row">
        <v-table fixed-header height="auto" class="table-employee">
          <thead>
            <tr>
              <th class="text-left">MSV/Tài khoản</th>
              <th class="text-left">Tên sinh viên</th>
              <th class="text-left">Lớp</th>
              <th class="text-left">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in students.studentModels" :key="item.id">
              <td>{{ item.userName == null ? "#" : item.userName }}</td>
              <td>{{ item.fullName == null ? "#" : item.fullName }}</td>
              <td>{{ item.className == null ? "#" : item.className }}</td>
              <td>
                <button-base :class="'btn-delete'" @click="lookStudent(item)">{{
                  item.isDeleted ? "Mở khóa" : "Khóa"
                }}</button-base>&nbsp;
                <v-icon v-if="item.isDeleted">mdi-lock</v-icon>
              </td>
            </tr>
          </tbody>
        </v-table>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="page" class="my-4" :length="students.total"
                @update:modelValue="paginationStudent"></v-pagination>
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
      file: null,
      students: [],
      page: 1,
      searchName: "",
      isDisabled: true,
    };
  },
  async created() {
    await this.loadStudents();
  },
  methods: {
    paginationStudent() {
      this.loadStudents();
    },
    async loadStudents() {
      try {
        this.students = await this.$store.dispatch("admin/loadStudents", this.page);
        if (this.students.studentModels.length == 0) {
          this.$toast.warning("Không có sinh viên nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải danh sách sinh viên!");
      }
    },
    handleFileUpload() {
      this.file = this.$refs.file.files[0];
      this.isDisabled = false
    },
    async registerStudent() {
      try {
        this.isDisabled = true;
        var result = await this.$store.dispatch("admin/registerStudent", this.file);
        if (result) {
          this.$refs.file.reset();
          this.isDisabled = true;
          this.loadStudents();
          this.$toast.success("Thêm danh sách thành công!");
        }
      } catch {
        this.isDisabled = true;
        this.$refs.file.reset();
        this.$toast.warning("Đã xảy ra sự cố!");
      }
    },
    async lookStudent(event) {
      let postData = {
        userId: event.id,
        isLock: !event.isDeleted
      };
      var removeData = await this.$store.dispatch("admin/deleteStudent", postData);
      if (removeData) {
        this.students.studentModels.forEach((item) => {
          if (item == event) {
            item.isDeleted = !item.isDeleted;
          }
        })
        if (event.isDeleted) {
          this.$toast.warning(
            `Sinh viên: ${event.fullName} đã bị khóa tài khoản.`
          );
        } else {
          this.$toast.success(
            `Sinh viên: ${event.fullName} được mở khóa tài khoản.`);
        }

      } else {
        this.$toast.error(`Sinh viên: ${event.fullName} xóa không thành công.`);
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