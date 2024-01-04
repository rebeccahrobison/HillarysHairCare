const _apiUrl = "/api/appointments";

export const getAppointments = () => {
  return fetch(`${_apiUrl}`).then(res => res.json())
}

export const getAppointmentById = (id) => {
  return fetch(`${_apiUrl}/${id}`).then(r => r.json())
}

export const cancelAppointment = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: "DELETE"
  })
}

export const postAppointment = (appointment) => {
  return fetch(`${_apiUrl}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(appointment)
  })
}

export const getAppointmentServices = () => {
  return fetch(`/api/appointmentservices`).then(res => res.json())
}

export const postAppointmentService = (appointmentService) => {
  return fetch(`/api/appointmentservices`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(appointmentService)
  })
}

export const deleteAppointmentService = (id) => {
  return fetch(`/api/appointmentservices/${id}`, {
    method: "DELETE"
  })
}

