import axios from "../../interceptors/axios.js";

export default {
  async loadCV() {
    const response = await axios.get("student/cv");
    return response.data;
  },
  async recruitmentCV(_, id) {
    const response = await axios.post("student/recruitment-cv/"+ id);
    return response.data;
  },
  async cancelCV(_, id) {
    const response = await axios.post("student/cancel-cv/"+ id);
    return response.data;
  },
  async applyCV(_, page) {
    const response = await axios.get("student/apply-cv/"+page);
    return response.data;
  },
  async senimarAttend(_, id) {
    //register attend senimar
    const response = await axios.post("student/senimar-attend/"+ id);
    return response.data;
  },
  async cancelSenimarAttend(_, id) {
    const response = await axios.post("student/cancel-senimar-attend/"+ id);
    return response.data;
  },
  async loadSenimarAttends(_, page) {
    const response = await axios.get("student/my-senimar-attend/"+page);
    return response.data;
  },
  async registerCV(_, payload) {
    let formData = new FormData();
    if (payload != "") {
      formData.append("file", payload);
      const response = await axios.post("student/cv/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      return response.data;
    }
  },
  async loadUser() {
    const response = await axios.get("home/profile");
    return response.data;
  },
};
