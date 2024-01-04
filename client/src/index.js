import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { AppointmentsList } from './components/appointments/AppointmentsList';
import { AppointmentDetails } from './components/appointments/AppointmentDetails';
import { AddAppointment } from './components/appointments/AddAppointment';
import { StylistsList } from './components/stylists/StylistsList';
import { AddStylist } from './components/stylists/AddStylist';
import { CustomersList } from './components/customers/CustomersList';
import { AddCustomer } from './components/customers/AddCustomer';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="appointments">
          <Route index element={<AppointmentsList /> } />
          <Route path=":id" element={<AppointmentDetails />} />
          <Route path="add" element={<AddAppointment />} />
        </Route>
        <Route path="customers">
          <Route index element={<CustomersList />} />
          <Route path='add' element={<AddCustomer />}/>
        </Route>
        <Route path="stylists">
          <Route index element={<StylistsList />} />
          <Route path="add" element= {<AddStylist />} />
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);


