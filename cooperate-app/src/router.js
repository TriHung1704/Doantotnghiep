import { createRouter, createWebHistory } from "vue-router";
import HomePage from "./pages/home/HomePage.vue";
import RecruitmentPage from "./pages/home/RecruitmentPage.vue";
import InternshipPage from "./pages/home/InternshipPage.vue";
import SenimarPage from "./pages/home/SenimarPage.vue";
import NotificationsPage from "./pages/home/NotificationPage.vue";
import PostsPage from "./pages/enterprise/post/PostsPage.vue";
import EmployeePage from "./pages/enterprise/employee/EmployeePage.vue";
import RegisterPost from "./pages/enterprise/post/RegisterPost.vue";
import StudentPost from "./pages/enterprise/post/StudentPost.vue";
import StudentSenimar from "./pages/enterprise/post/StudentSenimar.vue";
import DetailPost from "./pages/enterprise/post/DetailPost.vue";
import BannerPage from "./pages/admin/BannerPage.vue";
import StudentPage from "./pages/admin/StudentPage.vue";
import NotificationPage from "./pages/admin/NotificationPage.vue";
import RegisterNotification from "./pages/admin/RegisterNotification.vue";
import DetailNotification from "./pages/admin/DetailNotification.vue";
import EnterprisePostPage from "./pages/admin/EnterprisePostPage.vue";
import RegisterEmployee from "./pages/enterprise/employee/RegisterEmployee.vue";
import CVPage from "./pages/student/CVPage.vue";
import StudentPostPage from "./pages/student/StudentPostPage.vue";
import SenimarAttendPage from "./pages/student/SenimarAttendPage.vue";
import store from "./stores/index.js";

const RoleAccess = Object.freeze({
  EmployeeHRM: "EmployeeHRM",
  Administrator: "Administrator",
  EmployeeAdmin: "EmployeeAdmin",
  Student: "Student",
});

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: "/", redirect: "/home" },
    { path: "/home", component: HomePage },
    { path: "/recruitment", component: RecruitmentPage },
    { path: "/internship", component: InternshipPage },
    { path: "/senimar", component: SenimarPage },
    { path: "/notification", component: NotificationsPage },
    { path: "/admin/banner",
      component: BannerPage,
      meta: { requiresAuth: true, roles: [RoleAccess.Administrator] },
    },
    { path: "/admin/student",
      component: StudentPage,
      meta: { requiresAuth: true, roles: [RoleAccess.Administrator] },
    },
    { path: "/admin/post/notification",
      component: NotificationPage,
      meta: { requiresAuth: true, roles: [RoleAccess.Administrator] },
    },
    { path: "/admin/post/notification/register",
      component: RegisterNotification,
      meta: { requiresAuth: true, roles: [RoleAccess.Administrator] },
    },
    { path: "/admin/post/notification/edit/:id",
      component: RegisterNotification,
      props: true,
      meta: { requiresAuth: true, roles: [RoleAccess.Administrator] },
    },
    { path: "/admin/enterprise-post",
      component: EnterprisePostPage,
      meta: { requiresAuth: true, roles: [RoleAccess.Administrator] },
    },
    { path: "/notification/:id",
      component: DetailNotification,
      props: true,
      meta: { requiresAuth: true},
    },
    { path: "/enterprise/posts/:type",
      component: PostsPage,
      props: true,
      meta: { requiresAuth: true, roles: [RoleAccess.EmployeeHRM] },
    },
    {
      path: "/enterprise/posts/:type/register",
      component: RegisterPost,
      props: true,
      meta: { requiresAuth: true, roles: [RoleAccess.EmployeeHRM] },
    },
    {
      path: "/enterprise/posts/:type/detail/:id",
      component: DetailPost,
      props: true,
    },
    {
      path: "/enterprise/posts/:type/edit/:id",
      component: RegisterPost,
      props: true,
      meta: { requiresAuth: true, roles: [RoleAccess.EmployeeHRM] },
    },
    {
      path: "/apply-cv/:id",
      component: StudentPost,
      props: true,
      meta: { requiresAuth: true, roles: [RoleAccess.EmployeeHRM] },
    },
    {
      path: "/senimar-attend/:id",
      component: StudentSenimar,
      props: true,
      meta: { requiresAuth: true, roles: [RoleAccess.EmployeeHRM] },
    },
    { path: "/enterprise/employee",
      component: EmployeePage,
      meta: { requiresAuth: true, roles: [RoleAccess.EmployeeAdmin] },
    },
    { path: "/enterprise/employee/register",
      component: RegisterEmployee,
      meta: { requiresAuth: true, roles: [RoleAccess.EmployeeAdmin] },
    },
    { path: "/curriculum-vitae",
      component: CVPage,
      meta: { requiresAuth: true, roles: [RoleAccess.Student] },
    },
    { path: "/apply-curriculum-vitae",
      component: StudentPostPage,
      meta: { requiresAuth: true, roles: [RoleAccess.Student] },
    },
    { path: "/senimar-attend",
      component: SenimarAttendPage,
      meta: { requiresAuth: true, roles: [RoleAccess.Student] },
    },
    { path: "/:notFound(.*)", redirect: "/home" },
  ],
  scrollBehavior() {
    return { top: 0 };
  },
});
router.beforeEach(function (to, _, next) {
  const roles = store.getters.roles;
  if (to.meta.requiresAuth && !store.getters.isAuthenticated) {
    next("/home");
  } else if (
    typeof to.meta.roles != "undefined" &&
    to.meta.requiresAuth &&
    store.getters.isAuthenticated &&
    !(
      to.meta.roles.filter(function (item) {
        return roles.indexOf(item) > -1;
      }).length > 0
    )
  ) {
    next("/forbidden");
  } else if(roles === undefined ) {
    store.dispatch('tryLogin');
  }
  next();
});

export default router;
