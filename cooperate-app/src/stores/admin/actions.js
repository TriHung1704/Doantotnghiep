import axios from "../../interceptors/axios.js";

export default {
  async registerStudent(_, payload) {
    let formData = new FormData();
    formData.append("file", payload);
    const response = await axios.post("home/student/upload-file", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return response.data;
  },
  async loadBanners() {
    const response = await axios.get("home/slide");
    return response.data;
  },
  async enabledBanner(_,id) {
    const response = await axios.post("home/slide/enable/"+ id);
    return response.data;
  },
  async registerBanner(_, payload) {
    let formData = new FormData();
    formData.append("file", payload);
    const response = await axios.post("home/slide/upload-file", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    var dataRequest = {
      image: response.data,
      isEnable: false
    }
    const responseData = await axios.post("home/slide", dataRequest);
    return responseData.data;
  },
  async loadStudents(_, page) {
    const response = await axios.get("home/student/"+page);
    return response.data;
  },
  async deleteStudent(_,postData) {
    const response = await axios.delete("home/student/lock-student/"+postData.isLock +"/"+ postData.userId);
    return response.data;
  },
  async registerPost(_, payload) {
    let formData = new FormData();
    if (payload.fileUpload != "") {
      formData.append("file", payload.fileUpload);
      const response = await axios.post("posts/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      payload.postData.image = response.data;
    }
    const responseData = await axios.post("home/posts/notification", payload.postData);
    return responseData.data;
  },
  async editPost(_, payload) {
    let formData = new FormData();
    if (payload.fileUpload != "") {
      formData.append("file", payload.fileUpload);
      const response = await axios.post("posts/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      payload.postData.image = response.data;
    }
    const responseData = await axios.put("home/posts/notification", payload.postData);
    return responseData.data;
  },
  async loadNotification(_, payload) {
    const response = await axios.get("home/posts/notifications?page="+payload.page+"&number="+payload.number);
    return response.data;
  },
  async deletePost(_, id) {
    const response = await axios.delete("home/posts/notification/"+id);
    return response.data;
  },
  async loadPost(_, id) {
    const response = await axios.get("home/posts/notification/"+id);
    return response.data;
  },
  async loadPostsEnterprises(_, payload) {
    const response = await axios.get(`posts/posts-enterprises?type=${payload.type}&page=${payload.page}&limit=${payload.limit}`);
    return response.data;
  },
  async confirmPostEnterprise(_, payload) {
    const response = await axios.get(`posts/confirm-post-enterprise?isConfirm=${payload.isConfirm}&id=${payload.id}`);
    return response.data;
  },
  async registerEnterprise(_, payload) {
    let formData = new FormData();
    debugger
    if (payload.fileUpload != "") {
      formData.append("file", payload.fileUpload);
      const response = await axios.post("enterprise/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      payload.enterpriseData.imageLogo = response.data;
    }
    debugger
    const responseData = await axios.post("enterprise/register", payload.enterpriseData);
    return responseData.data;
  },
  async updateEnterprise(_, payload) {
    let formData = new FormData();
    if (payload.fileUpload != "") {
      formData.append("file", payload.fileUpload);
      const response = await axios.post("enterprise/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      payload.enterpriseData.imageLogo = response.data;
    }
    const responseData = await axios.put("enterprise/update", payload.enterpriseData);
    return responseData.data;
  },
  async loadEnterprises(_, page) {
    const response = await axios.get(`enterprise/list-enterprise?page=${page}`);
    return response.data;
  },
  async loadEnterprise(_, id) {
    const response = await axios.get(`enterprise?id=${id}`);
    return response.data;
  },
  async deleteEnterprise(_,payload) {
    debugger
    const response = await axios.delete("enterprise/lock-enterprise?isLock="+payload.isLock +"&enterpriseId="+ payload.enterpriseId);
    return response.data;
  },
};
