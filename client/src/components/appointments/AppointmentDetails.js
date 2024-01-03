import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom";
import { cancelAppointment, getAppointmentById } from "../../data/appointmentsData";
import { formatTimestamp } from "../formatTimestamp";

export const AppointmentDetails = () => {
  const [appointment, setAppointment] = useState({})
  const appointmentId = useParams().id
  const navigate = useNavigate()
  // console.log(appointmentId)
  // console.log("typeof Date.now():", typeof(Date.now()))
  // console.log("typeof appointment.apptTime:", typeof(appointment.apptTime))

  useEffect(() => {
    getAppointmentById(appointmentId).then(obj => setAppointment(obj))
  }, [appointmentId])

  const handleCancelBtn = (e) => {
    e.preventDefault();

    cancelAppointment(appointmentId).then(navigate("/appointments"))
  }

  return (
    <div className="container">
      <div className="appts-header">
        <h4>Appointment Details</h4>
      </div>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Time</th>
              <th>Stylist</th>
              <th>Customer</th>
              <th>Services</th>
              <th>Total Price</th>
            </tr>
          </thead>
          <tbody>
            <tr key={`appointments-${appointment?.id}`}>
              <td className="appt-time">{formatTimestamp(appointment?.apptTime)}</td>
              <td>{appointment?.stylist?.name}</td>
              <td>{appointment?.customer?.name}</td>
              <td>
                {appointment?.services?.map(s => (
                  <div key={`services=${s?.id}`}>{s.name}</div>
                ))}
              </td>
              <td>${appointment?.totalPrice}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div className="btns-container">
        <button className="btn btn-update">Update Appointment</button>
        {new Date(appointment.apptTime) > Date.now() ?
          <button className="btn btn-cancel" onClick={e => handleCancelBtn(e)}>Cancel Appointment</button>
            : 
          ""
        }
      </div>
    </div>
  )
}