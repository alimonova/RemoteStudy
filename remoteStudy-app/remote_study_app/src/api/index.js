import apiServer from "./apiServser";

const servUrl = "http://localhost:5000";

export default {
  getTeachers: {
    url: `${servUrl}/api/Account/Teachers`,
    method: "GET",
  },

  auth: {
    register: {
      url: `${servUrl}/api/Account/Registration`,
      method: "POST",
    },

    login: {
      url: `${servUrl}/api/Account/Authorization`,
      method: "POST",
    },
  },
};

export { apiServer };
