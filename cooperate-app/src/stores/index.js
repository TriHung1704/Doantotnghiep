import { createStore } from 'vuex';
import authModule from './auth/index.js';
import postModule from './post/index.js';
import adminModule from './admin/index.js';
import employeeModule from './employee/index.js';
import studentModule from './student/index.js';


const store = createStore({
  modules: {
    auth: authModule,
    post: postModule,
    admin: adminModule,
    employee: employeeModule,
    student: studentModule
  }
});

export default store;