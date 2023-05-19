import axios from "../../interceptors/axios.js";
// import VueJwtDecode from "vue-jwt-decode";
// import utf8 from "utf8";
import jwt_decode from "jwt-decode";

export default {
  async getSlide() {
    const response = await axios.get("home/slide");
    return response.data;
  },
  async login(context, payload) {
    await context.dispatch("auth",payload);
  },
  async auth(context, payload) {
    const response = await axios.post("login", payload);
    const dataDecodeToken = jwt_decode(response.data.accessToken);
    // const dataDecodeToken = VueJwtDecode.decode(response.data.accessToken);
    // const fullName = utf8.decode(dataDecodeToken.FullName);

    localStorage.setItem("token", response.data.accessToken);
    localStorage.setItem("refreshToken", response.data.refreshToken);
    localStorage.setItem("fullName", dataDecodeToken.FullName);
    localStorage.setItem("userId", dataDecodeToken.Id);
    localStorage.setItem("roles", dataDecodeToken.Roles);
    localStorage.setItem("avatar", dataDecodeToken.Avatar);

    context.commit("setUser", {
      token: response.data.accessToken,
      refreshToken: response.data.refreshToken,
      userId: dataDecodeToken.Id,
      fullName: dataDecodeToken.FullName,
      roles: dataDecodeToken.Roles,
      avatar: dataDecodeToken.Avatar,
    });
  },
  tryLogin(context) {
    const token = localStorage.getItem("token");
    const userId = localStorage.getItem("userId");
    const refreshToken = localStorage.getItem("refreshToken");
    const fullName = localStorage.getItem("fullName");
    const roles = localStorage.getItem("roles");
    const avatar = localStorage.getItem("avatar");

    if (token && userId) {
      context.commit("setUser", {
        token: token,
        refreshToken: refreshToken,
        userId: userId,
        fullName: fullName,
        roles: roles,
        avatar: avatar
      });
    }
  },
  logout(context) {
    localStorage.removeItem("token");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("userId");
    localStorage.removeItem("fullName");
    localStorage.removeItem("roles");
    localStorage.removeItem("avatar");

    context.commit("setUser", {
      token: null,
      refreshToken: null,
      userId: null,
      fullName: "",
      roles: null,
      avatar: null
    });
  },
  refreshToken(context, payload) {
    localStorage.setItem("token", payload.accessToken);
    localStorage.setItem("refreshToken", payload.refreshToken);
    context.commit("setUser", {
      token: payload.accessToken,
      refreshToken: payload.refreshToken,
      userId: localStorage.getItem("userId"),
      fullName: localStorage.getItem("fullName"),
      roles: localStorage.getItem("roles"),
      avatar: localStorage.getItem("avatar")
    });
  }
};
