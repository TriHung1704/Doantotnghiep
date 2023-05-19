import axios from "../../interceptors/axios.js";

export default {
  async loadEmployees() {
    const response = await axios.get("enterprise/employee");
    return response.data;
  },
  async postEmployees(_,payload) {
    let formData = new FormData();
    if (payload.fileUpload != "") {
      formData.append("file", payload.fileUpload);
      const response = await axios.post("enterprise/upload-file", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      payload.employeeData.avatar = response.data;
    }
    debugger
    const responseData = await axios.post("enterprise/create-employee", payload.employeeData);
    return responseData.data;

    // const response = await axios.post("enterprise/create-employee", postData);
    // return response.data;
  },
  async deleteEmployee(_,postData) {
    const response = await axios.delete("enterprise/lock-employee/"+postData.isLock +"/"+ postData.userId);
    return response.data;
  }
};
