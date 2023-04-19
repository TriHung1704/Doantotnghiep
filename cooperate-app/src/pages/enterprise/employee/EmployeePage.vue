<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách nhân viên</p>
        <button-base :class="'btn-submit'" link :to="createPostLink"
          >Tạo nhân viên mới</button-base
        >
      </div>
      <div class="row">
        <v-table fixed-header height="400px" class="table-employee">
          <thead>
            <tr>
              <th class="text-left">Tài khoản</th>
              <th class="text-left">Tên nhân viên</th>
              <th class="text-left">Email</th>
              <th class="text-left">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in employees" :key="item.id">
              <td>{{ item.userName == null ? "#" : item.userName }}</td>
              <td>{{ item.fullName == null ? "#" : item.fullName }}</td>
              <td>{{ item.email == null ? "#" : item.email }}</td>
              <td>
                <button-base :class="'btn-delete'" @click="deleteEmployee(item)">{{item.isDeleted ? "Mở khóa" : "Khóa"}}</button-base>&nbsp;
                <!-- <button-base :class="'btn-submit'">Chỉnh sửa</button-base> -->
                <v-icon v-if="item.isDeleted">mdi-lock</v-icon>
              </td>
            </tr>
          </tbody>
        </v-table>
      </div>
    </div>
  </div>
</template>
<script>

export default {
  data: () => ({
    employees: [], 
    isLock: true
  }),
  methods: {
    async loadEmployees() {
      try {
        this.employees = await this.$store.dispatch("employee/loadEmployees");
        if (this.employees.length == 0) {
          this.$toast.warning("Không có nhân viên nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải danh sách nhân viên!");
      }
    },
    async deleteEmployee(event) {
        let postData = {
        userId: event.id,
        isLock: !event.isDeleted
      };
      var removeData = await this.$store.dispatch("employee/deleteEmployee", postData);
      if (removeData) {
        this.employees.forEach((item) => {
          if(item == event){
            item.isDeleted = !item.isDeleted;
          }
        })
        this.$toast.success(
          `Nhân viên: ${event.fullName} được xóa thành công.`
        );
      } else {
        this.$toast.error(`Nhân viên: ${event.fullName} xóa không thành công.`);
      }
    },
  },
  async created() {
    await this.loadEmployees();
  },
  computed: {
    createPostLink() {
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

.table-employee ::v-deep table {
  margin: 10px 0;
  border-radius: 7px;
  box-shadow: 2px 2px 8px rgb(1 1 1 / 26%);
  border: 1px solid #d6d6d6;
}
</style>