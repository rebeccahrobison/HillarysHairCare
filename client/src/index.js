import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { AppointmentsList } from './components/appointments/AppointmentsList';
import { AppointmentDetails } from './components/appointments/AppointmentDetails';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />}>
        <Route path="appointments">
          <Route index element={<AppointmentsList /> } />
          <Route path=":id" element={<AppointmentDetails />} />
        </Route>
        <Route path="customers">

        </Route>
        <Route path="stylists">

        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);


