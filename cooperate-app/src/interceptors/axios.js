import axios from "axios";
import store from "../stores/index.js";
import router from "@/router.js";

var instance = axios.create({
  baseURL: "https://localhost:44366/api/",
});

instance.interceptors.request.use(
  (config) => {
    const token = store.getters.token;
    store._state.data.auth.isActiveLoader = true;
    if (token) {
      config.headers["Authorization"] = "Bearer " + token;
      config.headers["Content-Type"] = 'application/json';
    }
    return config;
  },
  async (error) => {
    return Promise.reject(error);
  }
);

instance.interceptors.response.use(
  (res) => {
    store._state.data.auth.isActiveLoader = false;
    return res;
  },
  async (err) => {
    const originalConfig = err.config;
    if (originalConfig.url !== "login" && err.response) {
      // Access Token was expired
      if (err.response.status === 401 && !originalConfig._retry) {
        originalConfig._retry = true;
        try {
          const actionPayload = {
            refreshToken: localStorage.getItem("refreshToken"),
            accessToken:  localStorage.getItem("token")
          };
          const rs = await instance.post("login/refresh-token", actionPayload);
          const responseData  = rs.data;

          store.dispatch('refreshToken', responseData);
          err.config.headers[
            "Authorization"
          ] = `Bearer ${responseData.accessToken}`;
          return instance(err.config);
        } catch (_error) {
          store._state.data.auth.isActiveLoader = false;
          return Promise.reject(_error);
        }
      }else if(err.response.status === 403 ){
        store._state.data.auth.isActiveLoader = false;
        router.replace("/forbidden");
      }
    }
    if(err.response.status === 400){
      router.replace("/forbidden");
    }

    store._state.data.auth.isActiveLoader = false;
    return Promise.reject(err);
  }
);
export default instance;
