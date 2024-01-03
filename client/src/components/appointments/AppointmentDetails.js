import { useEffect, useState } from "react"
import { Link, useParams } from "react-router-dom";
import { getAppointmentById } from "../../data/appointmentsData";
import { formatTimestamp } from "../formatTimestamp";

export const AppointmentDetails = () => {
  const [appointment, setAppointment] = useState({})
  const appointmentId = useParams().id;
  // console.log(appointmentId)

  useEffect(() => {
    getAppointmentById(appointmentId).then(obj => setAppointment(obj))
  }, [appointmentId])

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
      
    </div>
  )
}