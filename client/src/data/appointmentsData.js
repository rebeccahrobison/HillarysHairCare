const _apiUrl = "/api/appointments";

export const getAppointments = () => {
  return fetch(`${_apiUrl}`).then(res => res.json())
}