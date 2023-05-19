export default {
  setUser(state, payload) {
    state.token = payload.token;
    state.refreshToken = payload.refreshToken;
    state.userId = payload.userId;
    state.fullName = payload.fullName;
    state.roles = payload.roles;
    state.avatar = payload.avatar;
  },
  setAutoLogout(state) {
    state.didAutoLogout = true;
  }
};
