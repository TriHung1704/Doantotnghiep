<template>
  <div>
    <div class="box-title">
      <p>Trang chủ / Hội thảo công nghệ</p>
    </div>
    <div class="row mt-2">
      <div class="col-sm-4">
        <v-text-field
          v-model="title"
          clearable
          label="Tiêu đề bài đăng"
          variant="outlined"
          autocomplete="null"
        ></v-text-field>
      </div>
      <div class="col-sm-4">
        <v-text-field
          v-model="enterprise"
          clearable
          label="Tên doanh nghiệp"
          variant="outlined"
          autocomplete="null"
        ></v-text-field>
      </div>
      <div class="col-sm-3">
        <v-autocomplete
          v-model="itemsMajor"
          :items="itemsMajors"
          chips
          closable-chips
          solo
          item-title="majorsName"
          item-value="id"
          label="Các ngành học liên quan"
          :rules="[required]"
          variant="outlined"
          multiple
        >
          <template v-slot:chip="{ props, item }">
            <v-chip v-bind="props" :text="item.raw.majorsName"></v-chip>
          </template>

          <template v-slot:item="{ props, item }">
            <v-list-item
              v-bind="props"
              :title="item?.raw?.majorsName"
            ></v-list-item>
          </template>
        </v-autocomplete>
      </div>
      <div class="col-sm-1">
        <v-btn
          :disabled="false"
          :loading="false"
          block
          color="success"
          size="large"
          type="submit"
          variant="elevated"
          minHeight="55px"
          @click="loadPostsSeminar()"
        >
          Tìm
        </v-btn>
      </div>
    </div>
    <div class="row">
      <card-base :class="'col-lg-4'"
        v-for="post in postsSeminar.postList"
        :key="post.id"
        :post="post"
      ></card-base>
      <div class="text-center">
        <v-row justify="center">
          <v-col cols="6">
            <v-pagination
              v-model="pageSeminar"
              class="my-4"
              :length="postsSeminar.total"
              @update:modelValue="paginationSeminar"
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
    pageSeminar: 1,
    postsSeminar: [],
    limit: 20,
    itemsMajors: [],
    itemsMajor: [],
    title: "",
    enterprise: "",
  }),
  methods: {
    paginationSeminar() {
      this.loadPostsSeminar();
    },
    async loadMajors() {
      let majors = await this.$store.dispatch("post/loadMajors");
      this.itemsMajors = majors;
    },
    async loadPostsSeminar() {
      try {
        var payloadSeminar = {
          type: "seminar",
          page: this.pageSeminar,
          limit: 20,
          title: this.title,
          enterpriseName: this.enterprise,
          majorsIds: this.itemsMajor ?? this.itemsMajor.join().split(","),
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
  },
  async created() {
    await this.loadMajors();
    await this.loadPostsSeminar();
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