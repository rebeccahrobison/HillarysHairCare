import { useEffect, useState } from "react"
import { addStylist } from "../../data/stylistsData"
import { useNavigate } from "react-router-dom"

export const AddStylist = () => {
  const [stylistName, setStylistName] = useState("")
  const navigate = useNavigate()

  useEffect(() => {}, [])

  const handleAddStylistBtn = (e) => {
    e.preventDefault()

    const stylistToAdd = {
      name: stylistName, active: true
    }
    addStylist(stylistToAdd).then(() => navigate("/stylists"))
  }

  return (
    <div className="container">
      <h4>Add Stylist</h4>
      <div className="form-container">
        <div>Stylist Name: </div>
        <input type="text" onChange={e => setStylistName(e.target.value)}/>
      </div>
      <button onClick={e => handleAddStylistBtn(e)}>Add Stylist</button>
    </div>
  )
}