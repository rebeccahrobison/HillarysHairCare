import { useEffect, useState } from "react"
import { getAppointments } from "../../data/appointmentsData"
import "../appointments/Appointments.css"
import { formatTimestamp } from "../formatTimestamp"
import { Link, useNavigate } from "react-router-dom"


export const AppointmentsList = () => {
  const [appointments, setAppointments] = useState([])
  const navigate = useNavigate()

  const getAndSetAppointments = () => {
    getAppointments().then(arr => setAppointments(arr))
  }

  useEffect(() => {
    getAndSetAppointments()
  }, [])

  const handleAddBtn = (e) => {
    e.preventDefault()

    navigate("add")
  }

  return (
    <div className="container">
      <div className="appts-header">
        <h4>Appointments</h4>
        <button className="add-btn" onClick={e => handleAddBtn(e)}>Add Appointment</button>
      </div>
      <div className="table-container">
        <table>
        <thead>
          <tr>
          <th>Time</th>
          <th>Stylist</th>
          <th>Customer</th>
        </tr>
        </thead>
        <tbody>
          {appointments.map((a) => (
            <tr key={`appointments-${a?.id}`}>
              <td className="appt-time"><Link to={`${a.id}`}>{formatTimestamp(a?.apptTime)}</Link></td>
              <td>{a?.stylist.name}</td>
              <td>{a?.customer.name}</td>
            </tr>
          ))}
        </tbody>
        
      </table>
      </div>
      
    </div>
  )
}