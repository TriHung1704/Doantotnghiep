<template>
    <div>
        <div class="box-post">
            <div class="box-title">
                <p v-if="this.type == 'recruitment'">Trang chủ / Danh sách bài tuyển dụng</p>
                <p v-if="this.type == 'internship'">Trang chủ / Danh sách bài tuyển thực tập sinh</p>
                <p v-if="this.type == 'seminar'">Trang chủ / Danh sách bài hội thảo</p>
            </div>
            <div class="row mt-1">
                <div class="col-sm-6">
                    <button-base :col="'col-12'" :class="'btn-submit'" link :to="registerPostLink">Tạo bài mới</button-base>
                </div>
                <div class="col-sm-6">
                    <button-base :col="'col-12'" link :to="'/'">Quay trở lại trang chủ</button-base>
                </div>
            </div>
            <div>
                <item-base v-for="post in posts.postList" :key="post.id" :id="post.id" :post="post"></item-base>
            </div>
            <div class="text-center">
          <v-row justify="center">
            <v-col cols="6">
              <v-pagination v-model="page" class="my-4" :length="posts.total"
                @update:modelValue="paginationPosts"></v-pagination>
            </v-col>
          </v-row>
        </div>
        </div>
    </div>
</template>
<script>
export default {
    props: ["type"],
    data: () => ({
        posts: [],
        page: 1,
        message: ""
    }),
    methods: {
        paginationPosts(){
            this.loadPosts();
        },
        async loadPosts() {
            try {
                switch(this.type){
                    case "recruitment":
                        this.message = "bài tuyển dụng";
                        break;
                    case "internship":
                        this.message = "bài tuyển thực tập sinh";
                        break;
                    case "seminar":
                        this.message = "bài hội thảo";
                        break;
                }
                let payload = {
                    type: this.type,
                    page : this.page,
                    limit: 20
                }
                this.posts = await this.$store.dispatch("post/loadPostByEmployee", payload);
                if (this.posts.length == 0) {
                    this.$toast.warning(`Không có ${this.message} nào!`);
                }
            } catch (error) {
                this.$toast.error("Không thể tải bài các bài tuyển dụng!");
            }
        },
    },
    async created() {
        await this.loadPosts();
    },
    computed: {
        registerPostLink() {
            return this.$route.path + "/register";
        },
    },
    watch: {
        type(newType, oldType) {
            if (newType != oldType) {
                this.loadPosts();
            }
        }
    }
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
</style>