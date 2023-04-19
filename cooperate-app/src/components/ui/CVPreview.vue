<template>
  <embed
      v-if="fileShowSrc"
      type="application/pdf"
      :src="fileShowSrc"
      width="100%"
      style="max-height: 100rem; min-height: 100rem"
  />
</template>
<script>
import urlApi from "@/interceptors/url";
export default {
  props: ["fileShow"],
  computed: {
    fileShowSrc() {
      if (this.fileShow != null) {
        return urlApi + this.fileShow;
      }
      return "";
    },
  },
};
</script>