import { useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom";
import { cancelAppointment, deleteAppointmentService, getAppointmentById, getAppointmentServices, postAppointmentService } from "../../data/appointmentsData";
import { formatTimestamp } from "../formatTimestamp";
import { getServices } from "../../data/servicesData";

export const AppointmentDetails = () => {
  const [appointment, setAppointment] = useState({})
  const [services, setServices] = useState([])
  const [appointmentServices, setAppointmentServices] = useState([])
  const [chosenServices, setChosenServices] = useState([])
  const appointmentId = useParams().id
  const navigate = useNavigate()
  // console.log(appointmentId)
  // console.log("typeof Date.now():", typeof(Date.now()))
  // console.log("typeof appointment.apptTime:", typeof(appointment.apptTime))

  useEffect(() => {
    getAppointmentById(appointmentId).then(obj => setAppointment(obj))
  }, [appointmentId])

  useEffect(() => {
    getServices().then(arr => setServices(arr))
  }, [])

  useEffect(() => {
    getAppointmentServices().then(arr => setAppointmentServices(arr))
  }, [])

  useEffect(() => {
    // if (!chosenServices) {
      setChosenServices(appointment?.services)
    // }
  }, [appointment])

  const handleCancelBtn = (e) => {
    e.preventDefault();

    cancelAppointment(appointmentId).then(navigate("/appointments"))
  }

  const handleRemoveBtn = (e, serviceId) => {
    e.preventDefault()
    const updatedChosenServices = chosenServices.filter(s => s.id !== serviceId)
    setChosenServices(updatedChosenServices)
  }

  const handleServiceChange = (e) => {
    const chosenServiceId = parseInt(e.target.value)
    const chosenService = services.find(s => s.id === chosenServiceId)
    if (chosenService) {
      const updatedChosenServices = [...chosenServices, chosenService]
      setChosenServices(updatedChosenServices)
    }
  }

  const handleUpdateBtn= (e) => {
    e.preventDefault()
    if (!chosenServices) {
      window.alert("Please choose at least one service")
    }

    for (const cs of chosenServices) {
      for (const s of appointment?.services) {
        if (cs.id !== s.id) {
          console.log(cs.name + " " + s.name)
          const foundApptService = appointmentServices.find(a => a.appointmentId == appointmentId && a.serviceId == s.id)
          deleteAppointmentService(foundApptService.id)
          const apptServiceToPost = {serviceId: cs.id, appointmentId: appointmentId}
          console.log(apptServiceToPost)
          postAppointmentService(apptServiceToPost)
        }
      }
    }

    navigate("/appointments")
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
              {new Date(appointment.apptTime) > Date.now() ?
                <td>
                  {chosenServices?.map(cs => {
                    return (
                      <div className="service-container" key={cs.id}>
                        <div>{cs.name}</div>
                        <button className="remove-btn" onClick={(e) => handleRemoveBtn(e, cs.id)}>remove</button>
                      </div>)
                  })}
                  <select onChange={handleServiceChange}>
                    <option value="0">Choose a Service</option>
                    {services.map(s => {
                      return (
                        <option value={s.id} key={s.id}>{s.name}</option>
                      )
                    })}
                  </select>
                </td>
                :
                <td>
                  {appointment?.services?.map(s => (
                    <div key={`services=${s?.id}`}>{s.name}</div>
                  ))}
                </td>
              }


              <td>${appointment?.totalPrice}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <div className="btns-container">
        {new Date(appointment.apptTime) > Date.now() ?
          <>
            <button className="btn btn-update" onClick={e => handleUpdateBtn(e)}>Update Appointment</button>
            <button className="btn btn-cancel" onClick={e => handleCancelBtn(e)}>Cancel Appointment</button>
          </>
          :
          ""
        }
      </div>
    </div>
  )
}