<template>
  <v-app>
    <v-main>
      <!-- <login-page v-if="didAutoLogout"/> -->
      <app-page/>
    </v-main>
  </v-app>
</template>

<script>
import AppPage from './components/layouts/AppPage.vue';

export default {
  name: 'App',

  components: {
    AppPage,
  },
  computed: {
    didAutoLogout() {
      return !this.$store.getters.isAuthenticated;
    }
  },
  created() {
    this.$store.dispatch('tryLogin');
  },
  data: () => ({
    //
  }),
}
</script>
<style>
body{
  font-family: sans-serif;
}
</style>
