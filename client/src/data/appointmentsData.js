const _apiUrl = "/api/appointments";

export const getAppointments = () => {
  return fetch(`${_apiUrl}`).then(res => res.json())
}

export const getAppointmentById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then(r => r.json())
}