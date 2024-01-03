const _apiUrl = "/api/customers";

export const getCustomers = () => {
  return fetch(`${_apiUrl}`).then(res => res.json())
}