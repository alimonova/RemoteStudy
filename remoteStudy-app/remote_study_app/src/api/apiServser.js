import axios from "axios";

const headers = {
  "Access-Control-Allow-Origin": "*",
};

export default async function apiServer(obj) {
  const { api, body, formData } = obj;

  try {
    const url = new URL(api.url);

    let requestParams = { ...api };
    delete requestParams.url;

    let res = undefined;

    switch (requestParams.method) {
      case "DELETE":
        res = await axios({
          headers: headers,
          withCredentials: true,
          method: "DELETE",
          url: url,
          data: body,
        });
        break;

      case "PATCH":
        res = await axios.patch(url, body, {
          headers: headers,
          withCredentials: true,
        });
        break;

      case "PUT":
        res = await axios.put(url, body, {
          headers: headers,
          withCredentials: true,
        });
        break;

      case "POST":
        res = await axios.post(url, body, {
          headers: headers,
        //   withCredentials: true,
        });
        break;

      case "FILE":
        res = await axios.post(url, formData, {
          headers: {
            "content-type": "multipart/form-data",
          },
          withCredentials: true,
        });
        break;

      case "GET":
        res = await axios.get(url, {
          headers: headers,
        //   withCredentials: true,
        });
        break;

      default:
        res = await axios.get(url, {
          headers: headers,
          withCredentials: true,
        });
        break;
    }

    if (res.data) {
      return res.data;
    } else {
      return { err: "fetch error" };
    }
  } catch (error) {
    if (error.response && error.response.data && error.response.data.error)
      return { err: error.response.data.error };
    else if (error.response && error.response.data) {
      return { err: error.response.data };
    } else return { err: "fetch error" };
  }
}
