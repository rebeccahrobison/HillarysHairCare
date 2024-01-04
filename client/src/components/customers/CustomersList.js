import { useEffect, useState } from "react"
import { getCustomers } from "../../data/customersData"
import { Link, useNavigate } from "react-router-dom"
import { formatTimestamp } from "../formatTimestamp"

export const CustomersList = () => {
  const [customers, setCustomers] = useState([])
  const navigate = useNavigate()

  useEffect(() => {
    getCustomers().then(arr => setCustomers(arr))
  }, [])

  const handleAddCustomerBtn = (e) => {
    e.preventDefault()

    navigate("/customers/add")
  }

  return (
    <div className="container">
      <div className="appts-header">
        <h4>Customers</h4>
        <button className="add-btn" onClick={e => handleAddCustomerBtn(e)}>Add Customer</button>
      </div>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Email</th>
              <th>Appointments</th>
            </tr>
          </thead>
          <tbody>
            {customers.map((c) => (
              <tr key={`customers-${c?.customer.id}`}>
                <td>{c?.customer.name}</td>
                <td>{c?.customer.email}</td>
                <td className="appt-time">
                  {c?.appointments.map(a => (
                  <div key={a.id}><Link to={`/appointments/${a.id}`}>{formatTimestamp(a?.apptTime)}</Link></div>
                  ))}
                </td>
              </tr>
            ))}
          </tbody>

        </table>
      </div>

    </div>
  )
}