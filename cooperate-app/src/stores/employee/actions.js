import axios from "../../interceptors/axios.js";

export default {
  async loadEmployees() {
    const response = await axios.get("enterprise/employee");
    return response.data;
  },
  async postEmployees(_,postData) {
    const response = await axios.post("enterprise/create-employee", postData);
    return response.data;
  },
  async deleteEmployee(_,postData) {
    const response = await axios.delete("enterprise/lock-employee/"+postData.isLock +"/"+ postData.userId);
    return response.data;
  }
};
