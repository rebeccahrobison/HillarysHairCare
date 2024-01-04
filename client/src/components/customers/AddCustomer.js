import { useState } from "react"
import { useNavigate } from "react-router-dom"
import { addCustomer } from "../../data/customersData"

export const AddCustomer = () => {
  const [customerName, setCustomerName] = useState("")
  const [customerEmail, setCustomerEmail] = useState("")
  const navigate = useNavigate()

  const handleAddCustomerBtn = (e) => {
    e.preventDefault()

    const customerToAdd = {
      name: customerName,
      email: customerEmail
    }

    addCustomer(customerToAdd).then(() => navigate("/customers"))
  }
  return (
    <div className="container">
      <h4>Add Customer</h4>
      <div className="form-container">
        <div>Customer Name: </div>
        <input type="text" onChange={e => setCustomerName(e.target.value)} />
      </div>
      <div className="form-container">
        <div>Customer Email: </div>
        <input type="email" onChange={e => setCustomerEmail(e.target.value)} />
      </div>
      <button onClick={e => handleAddCustomerBtn(e)}>Add Customer</button>
    </div>
  )
}
