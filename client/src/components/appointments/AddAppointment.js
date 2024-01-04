import { useEffect, useState } from "react"
import { getStylists } from "../../data/stylistsData"
import { getCustomers } from "../../data/customersData"
import { getServices } from "../../data/servicesData"
import { useNavigate } from "react-router-dom"
import { postAppointment } from "../../data/appointmentsData"

export const AddAppointment = () => {
  const [stylists, setStylists] = useState([])
  const [customers, setCustomers] = useState([])
  const [services, setServices] = useState([])
  const [chosenStylist, setChosenStylist] = useState(0)
  const [chosenCustomer, setChosenCustomer] = useState(0)
  const [chosenServices, setChosenServices] = useState([])
  const [selectedDate, setSelectedDate] = useState({
    year: "2024",
    month: "Jan",
    day: "1",
    time: "9:00am"
  })

  const navigate = useNavigate()
  const timeArr = ['9:00am', '10:00am', '11:00am', '12:00pm', '1:00pm', '2:00pm', '3:00pm', '4:00pm', '5:00pm']


  // useEffects
  useEffect(() => {
    getStylists().then(arr => setStylists(arr))
  }, [])

  useEffect(() => {
    getCustomers().then(arr => setCustomers(arr))
  }, [])

  useEffect(() => {
    getServices().then(arr => setServices(arr))
  }, [])

  // Functions

  const formatSelectedDate = () => {
    const { year, month, day, time } = selectedDate;
    const monthIndex = ('JanFebMarAprMayJunJulAugSepOctNovDec'.indexOf(month) / 3) + 1;
    const formattedMonth = monthIndex < 10 ? `0${monthIndex}` : `${monthIndex}`;
    const formattedDay = day < 10 ? `0${day}` : `${day}`;
    const formattedTime = time.replace(/(\d+):(\d+)(am|pm)/, (_, hours, minutes, period) => {
      // const formattedHours = period === 'pm' && parseInt(hours, 10) !== 12 ? parseInt(hours, 10) + 12 : hours;
      const formattedHours = period === 'pm' && parseInt(hours, 10) !== 12
      ? `${parseInt(hours, 10) + 12}`.padStart(2, '0')  // Add leading zero and ensure two digits
      : hours.padStart(2, '0');  // Add leading zero and ensure two digits
      return `${formattedHours}:${minutes}`;
    });

    return `${year}-${formattedMonth}-${formattedDay}T${formattedTime}:00`;
  };

    // console.log(formatSelectedDate())

  const handleDateChange = (e) => {
    const { name, value } = e.target
    setSelectedDate((prevDate) => ({...prevDate, [name]: value}))
  }

  const handleRemoveBtn = (e, serviceId) => {
    e.preventDefault()
    const updatedChosenServices = chosenServices.filter(s => s.id !== serviceId)
    setChosenServices(updatedChosenServices)
  }

  const handleServiceChange = (e) => {
    const chosenServiceId = parseInt(e.target.value)
    const chosenService = services.find(s => s.id === chosenServiceId)
    if(chosenService) {
      const updatedChosenServices = [...chosenServices, chosenService]
      setChosenServices(updatedChosenServices)
    }
  }

  const handleAddApptBtn = (e) => {
    e.preventDefault()

    const apptToAdd = {
      apptTime: formatSelectedDate(),
      stylistId: chosenStylist,
      customerId: chosenCustomer,
      services: chosenServices
    }

    console.log("appt to add", apptToAdd)

    postAppointment(apptToAdd).then(() => navigate("/appointments"))
  }

  return (
    <div className="container">
      <h4>Add Appointment Form</h4>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Time</th>
              <th>Stylist</th>
              <th>Customer</th>
              <th>Services</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>
                <select name="year" onChange={handleDateChange} value={selectedDate.year}>
                  <option>2024</option>
                  <option>2025</option>
                </select>
                <select name="month" onChange={handleDateChange} value={selectedDate.month}>
                  <option>Jan</option>
                  <option>Feb</option>
                  <option>Mar</option>
                  <option>Apr</option>
                  <option>May</option>
                  <option>Jun</option>
                  <option>Jul</option>
                  <option>Aug</option>
                  <option>Sep</option>
                  <option>Oct</option>
                  <option>Nov</option>
                  <option>Dec</option>
                </select>
                <select name="day" onChange={handleDateChange} value={selectedDate.day}>
                  {Array.from({length: 31}, (_, index) => (
                    <option key={index + 1} value={index + 1}>{index + 1}</option>
                  ))}
                </select>
                <select name="time" onChange={handleDateChange} value={selectedDate.time}>
                  {timeArr.map((ta, index) => (
                    <option key={index} value={ta}>{ta}</option>
                  ))}
                </select>
              </td>
              <td>
                <select onChange={(e) => {
                  setChosenStylist(parseInt(e.target.value))
                }}>
                  <option value="0">Choose a Stylist</option>
                  {stylists.map(s => {
                    return (
                      <option value={s.stylist.id} key={s.stylist.id}>{s.stylist.name}</option>
                    )
                  })}
                </select>
              </td>
              <td>
                <select onChange={(e) => {
                  setChosenCustomer(parseInt(e.target.value))
                }}>
                  <option value="0">Choose a Customer</option>
                  {customers.map(c => {
                    return (
                      <option value={c.customer.id} key={c.customer.id}>{c.customer.name}</option>
                    )
                  })}
                </select>
              </td>
              <td>
                {chosenServices.map(cs => {
                  return (
                  <div className="service-container"  key={cs.id}>
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
            </tr>
          </tbody>
        </table>
      </div>
      <button className="addappt-btn" onClick={e => handleAddApptBtn(e)}>Add Appointment</button>
    </div>

  )
}