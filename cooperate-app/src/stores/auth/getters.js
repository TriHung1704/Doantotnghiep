export default{
  userId(state){
    return state.userId;
  },
  token(state) {
    return state.token;
  },
  isAuthenticated(state) {
    return !!state.token;
  },
  fullName(state){
    return state.fullName;
  },
  isActiveLoader(state){
    return state.isActiveLoader;
  },
  roles(state){
    // return localStorage.getItem("roles");
    return state.roles;
  },
}