import React, { useState } from 'react'
import { Card, CardBody, CardImg, CardSubtitle, CardText, CardTitle, Col, Row } from 'reactstrap'
import CarServices from '../../services/CarServices'

export const CarCard = ({ car }) => {

  return (
    <div className='col-lg-3 col-sm-3 col-xl-3 col-md-3 mt-2 mb-2'>
    <Card className="bg-dark text-white border-light shadow shadow-2 rounded rounded-1">
      <CardBody>
        <CardImg 
        src={`${car.photoUrl}`}
        top
        className='mb-2 rounded-4'></CardImg>
        <CardTitle className='h6'>{car.brandName} {car.model} ({car.year})</CardTitle>
        <CardSubtitle className='text-white-50'>{car.brandName}</CardSubtitle>
        <hr/>
        <CardText>
          {car.brandName} {car.model} was created in the year of {car.year} with a speed of {car.speed} km/h
        </CardText>
        <button className='btn btn-danger' onClick={()=>{
          const r = confirm(`Are you sure want to delete ${car.model}?`)
          r?CarServices.DELETE(car.id).then(location.reload()):"";
        }}>Delete</button>
      </CardBody>
    </Card>
    </div>
  )
}
