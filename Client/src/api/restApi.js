import axios from 'axios';

const baseUrl = 'http://localhost:43628/api/';

export const get = (config) => {
  const { url, params, headers, onError } = config;

  return axios({
    method: 'get',
    url: baseUrl + url,
    params,
    headers
  }).catch(error => {throw(error);});
};

export const post = (config) => {
  const { url, headers, data, onError } = config;

  return axios({
    method: 'post',
    url: baseUrl + url,
    headers,
    data
  }).catch(error => {throw(error);});
};

