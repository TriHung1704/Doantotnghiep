import mutations from "./mutations.js";
import actions from "./actions.js";
import getters from "./getters.js";

export default {
  state() {
    return {
      token: null,
      refreshToken: null,
      userId: null,
      fullName: "",
      avatar: "",
      roles: null,
      isActiveLoader: false,
    };
  },
  mutations,
  actions,
  getters,
};
