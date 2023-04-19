import { createApp } from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'
import router from "./router.js"
import store from "./stores/index.js";
import AppPage from "./components/layouts/AppPage.vue";
import Toaster from "@meforma/vue-toaster";
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import CardBase from "./components/ui/CardBase.vue"
import ItemBase from "./components/ui/ItemBase.vue"
import ButtonBase from "./components/ui/ButtonBase.vue"
import DialogBase from "./components/ui/DialogBase.vue"
import NotificationBase from "./components/ui/NotificationBase.vue"
import NotiItemBase from "./components/ui/NotiItemBase.vue"
import AccessRolesBase from "./components/ui/AccessRolesBase.vue"
import ImagePost from "./components/ui/ImagePost.vue"
import CVPreview from "./components/ui/CVPreview.vue"
import { QuillEditor } from '@vueup/vue-quill'
import '@vueup/vue-quill/dist/vue-quill.snow.css';

import 'vue3-carousel/dist/carousel.css'
import { Carousel, Slide, Pagination, Navigation } from 'vue3-carousel'
import VPagination from 'v-pagination-3';
loadFonts()

createApp(App)
  .use(vuetify)
  .use(router)
  .use(store)
  .use(Toaster, {
    position: "top-right",
    duration: 4000,})
  .component("app-page", AppPage)
  .component("card-base", CardBase)
  .component("item-base", ItemBase)
  .component("button-base", ButtonBase)
  .component("dialog-base", DialogBase)
  .component("access-roles-base", AccessRolesBase)
  .component("image-post", ImagePost)
  .component("notification-base", NotificationBase)
  .component("noti-item-base", NotiItemBase)
  .component("cv-preview", CVPreview)
  .component('QuillEditor', QuillEditor)
  .component('navigation ', Navigation)
  .component('pagination', Pagination)
  .component('carousel', Carousel)
  .component('slide', Slide)
  .component('v-pagination', VPagination)
  .mount('#app')
