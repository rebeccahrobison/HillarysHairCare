import { useEffect, useState } from "react"
import { deactivateStylist, getStylists } from "../../data/stylistsData"
import { formatTimestamp } from "../formatTimestamp"
import { Link, useNavigate } from "react-router-dom"

export const StylistsList = () => {
  const [stylists, setStylists] = useState([])
  const navigate = useNavigate()

  const getAndSetStylists = () => {
    getStylists().then(arr => setStylists(arr))
  }

  useEffect(() => {
    getAndSetStylists()
  }, [])

  const handleRemoveStylistBtn = (e, id) => {
    e.preventDefault()

    deactivateStylist(id).then(() => getAndSetStylists())
  }

  const handleAddStylistBtn = (e) => {
    e.preventDefault()

    navigate("/stylists/add")
  }

  return (
    <div className="container">
      <div className="appts-header">
        <h4>Stylists</h4>
        <button className="add-btn" onClick={e => handleAddStylistBtn(e)}>Add Stylist</button>
      </div>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Appointments</th>
              <th>Active</th>
            </tr>
          </thead>
          <tbody>
            {stylists.map((s) => (
              <tr key={`stylists-${s?.id}`}>
                <td>{s?.stylist.name}</td>
                <td className="appt-time">
                  {s?.appointments.map(a => (
                  <div className="stylist-appointments" key={a.id}><Link to={`/appointments/${a.id}`}>{formatTimestamp(a?.apptTime)}</Link></div>
                  ))}
                </td>

                {s.stylist.active ?
                  <td><button className="remove-btn" onClick={e => handleRemoveStylistBtn(e, s.stylist.id)}>Remove</button></td>
                  :
                  <td>Inactive</td>}
              </tr>
            ))}
          </tbody>

        </table>
      </div>

    </div>
  )
}