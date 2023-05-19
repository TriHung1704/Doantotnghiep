<template>
  <div>
    <div class="box-post">
      <div class="box-title">
        <p>Trang chủ / Danh sách doanh nghiệp</p>
      </div>
      <div class="row mt-1">
                <div class="col-sm-6">
                    <button-base :col="'col-12'" :class="'btn-submit'" link :to="registerEnterpriseLink">Tạo doanh nghiệp</button-base>
                </div>
             
            </div>
      <div class="row">
        <v-table fixed-header height="auto" class="table-employee">
          <thead>
            <tr>
              <th class="text-left">#</th>
              <th class="text-left">Doanh nghiệp</th>
              <th class="text-left">Tài khoản doanh nghiệp</th>
              <th class="text-left">Website</th>
              <th class="text-left">Logo</th>
              <th class="text-left">Chức năng</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item,index) in enterprises.enterpriseList" :index="index" :key="item.id">
              <td>
                {{ (index+1) * page }}
              </td>
              <td>
                {{ item.name == null ? "#" : item.name }}
              </td>
              <td>
                {{
                  item.userName
                }}
              </td>
              <td>
                {{
                  item.website
                }}
              </td>
              <td>
                  <image-post v-if="item.imageLogo != null" :image="item.imageLogo" class="img-logo"></image-post>
                  <span v-else>#</span>
              </td>
              <td>
                <button-base :class="'btn-delete'" @click="editEnterprise(item)">
                  Chỉnh sửa
                </button-base>&nbsp;
                <button-base :class="'btn-delete'" @click="lockEnterprise(item)">{{
                  !item.status ? "Mở khóa" : "Khóa"
                }}</button-base>&nbsp;
                <v-icon v-if="!item.status">mdi-lock</v-icon>
              </td>
            </tr>
          </tbody>
        </v-table>
        <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="page" class="my-4" :length="enterprises.total"
                @update:modelValue="paginationEnterprises"></v-pagination>
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
      enterprises: [],
      page: 1,
    };
  },
  async created() {
    await this.loadEnterprises();
  },
  computed:{
    registerEnterpriseLink(){
      return this.$route.path + "/register";
    },
  },
  methods: {
    paginationEnterprises() {
      this.loadEnterprises();
    },
    async loadEnterprises() {
      try {
        this.enterprises = await this.$store.dispatch(
          "admin/loadEnterprises",
          this.page
        );
        if (this.enterprises.enterpriseList.length == 0) {
          this.$toast.warning("Không có doanh nghiệp nào!");
        }
      } catch (error) {
        this.$toast.error("Không thể tải danh sách doanh nghiệp!");
      }
    },
    async editEnterprise(item){
      let url = this.$route.path + "/edit/" + item.id;
      this.$router.replace(url);
    },
    async lockEnterprise(event) {
      debugger
      let postData = {
        enterpriseId: event.id,
        isLock: !event.status,
      };
      var removeData = await this.$store.dispatch(
        "admin/deleteEnterprise",
        postData
      );
      if (removeData) {
        this.enterprises.enterpriseList.forEach((item) => {
          if (item == event) {
            item.status = !item.status;
          }
        });
        if (!event.status) {
          this.$toast.warning(`Doanh nghiệp: ${event.name} đã bị khóa.`);
        } else {
          this.$toast.success(`Doanh nghiệp: ${event.name} được mở khóa.`);
        }
      } else {
        this.$toast.error(`Xử lý không thành công.`);
      }
    },
  },
};
</script>
<style scoped>
.img-logo{
  max-height: 100px;
  max-width: 100px;
}
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
.btn-submit{
  margin-top: 5px;
  width: initial;
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