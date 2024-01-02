import { Outlet } from 'react-router-dom';
import './App.css';

function App() {
  return (
    <>
      <nav>
        <div className="nav-item">✂️🪮<b><a href="http://localhost:3000/appointments">Hillary's Hair Care</a></b></div>
        <div className="nav-item">Customers</div>
        <div className="nav-item">Stylists</div>
      </nav>
      <Outlet />
    </>
  );
}

export default App;
