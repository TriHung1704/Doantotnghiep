import axios from "../../interceptors/axios.js";

export default {
  async loadPosts(_, payload) {
    if (payload.limit == undefined) {
      payload.limit = 6;
    }
    if (payload.title == undefined) {
      payload.title = "";
    }
    if (payload.enterpriseName == undefined) {
      payload.enterpriseName = "";
    }
    if (payload.majorsIds == undefined) {
      payload.majorsIds = "";
    }
    const response = await axios.get(`posts?type=${payload.type}&page=${payload.page}&limit=${payload.limit}
      &title=${payload.title}&enterpriseName=${payload.enterpriseName}&majorsIds=${payload.majorsIds}`);
    return response.data;
  },
  async loadPost(_, id) {
    const response = await axios.get("posts/" + id);
    return response.data;
  },
  async loadPostByEmployee(_, payload) {
    const response = await axios.get(`posts/posts-employee?type=${payload.type}&page=${payload.page}&limit=${payload.limit}`);
    return response.data;
  },
  async registerPost(_, payload) {
    let formData = new FormData();
    if (payload.fileUpload == "") {
      payload.postData.image = payload.image;
    } else {
      formData.append("file", payload.fileUpload);
      const response = await axios.post("posts/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      payload.postData.image = response.data;
    }
    const responseData = await axios.post("posts/" + payload.type, payload.postData);
    return responseData.data;
  },
  async editPost(_, payload) {
    let formData = new FormData();
    if (!payload.fileUpload == "") {
      formData.append("file", payload.fileUpload);
      const response = await axios.post("posts/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      payload.postData.image = response.data;
    }
    const responseData = await axios.put("posts/" + payload.type, payload.postData);
    return responseData.data;
  },
  async loadMajors() {
    const response = await axios.get("majors");
    return response.data;
  },
  async deletePost(_, id) {
    const response = await axios.delete("posts/" + id);
    return response.data;
  },
  async loadStudents(_, payload) {
    const response = await axios.get("enterprise/apply-cv?postId=" + payload.id + "&page=" + payload.page);
    return response.data;
  },
  async acceptedCV(_, payload) {
    const response = await axios.post("enterprise/accepted-cv?postId=" + payload.postId + "&studentId=" + payload.studentId + "&isAccepted=" + payload.isAccepted);
    return response.data;
  },
  async loadStudentSenimars(_, payload) {
    const response = await axios.get("enterprise/senimar-attend?postId=" + payload.id + "&page=" + payload.page);
    return response.data;
  },
};
