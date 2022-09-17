import React from 'react'
import { BrowserRouter,Routes,Route } from 'react-router-dom'
import Car from '../components/Car/Car'
import { CarForm } from '../components/Car/CarForm'

const Router = () => {
  return (
    <BrowserRouter>
    <Routes>
        <Route path="/" element={<Car/>}/>
        <Route path="/edit/:id" element={<CarForm/>}/>
        <Route path="/create" element={<CarForm/>}/>
    </Routes>
    </BrowserRouter>
    )
}

export default Router;
