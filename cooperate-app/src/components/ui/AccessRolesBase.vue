<template>
  <div v-if="isActive">
    <slot></slot>
  </div>
</template>
<script>
export default {
  props: {
    accessRoles: {
      type: Array,
      required: false,
      default: null,
    },
  },
  computed: {
    isActive() {
      const roles = this.$store.getters.roles;
      if (this.accessRoles === null) {
        return true;
      } else if (roles === null || roles === undefined) {
        return false;
      }
      return (
        this.accessRoles.filter(function (item) {
          return roles.indexOf(item) > -1;
        }).length > 0
      );
    },
  },
};
</script>
