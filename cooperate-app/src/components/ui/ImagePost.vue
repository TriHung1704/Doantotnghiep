<template>
  <img :src="imageSrc" class="card-img-top" alt="hình ảnh bài đăng" />
</template>
<script>
import urlApi from "@/interceptors/url";
export default {
  props: ["image"],
  computed: {
    imageSrc() {
      if (this.image != null) {
        return urlApi + this.image;
      }
      return urlApi+"Uploads/Post/post-image.jpg";
    },
  },
};
</script>