import React, { Component, useState } from 'react'
import CarServices from '../../services/CarServices';
import { CarCard } from './CarCard';

class Car extends Component{
  constructor(){
    super();
    this.state={
      data:[]
    }
  }

  async componentDidMount(){
    const response = await CarServices.GET();
    response.status===200?
      this.setState({data:response.data})
    :
    console.log(response.statusText)    
  }
  render(){
    return(
        this.state.data?
          <div className='row mt-4'>
            <div className='col-md-12 d-flex justify-content-between mb-2 mt-2'>
              <div className='border-right border-5 border-primary text-white fs-4 fw-bold'>Cars</div>
              <a href='/create' className='btn btn-primary shadow shadow-2 fs-5'>Create</a>
            </div>
            {this.state.data.map(car=>{return(<CarCard key={car.id} car={car}/>)})}
            </div>
            :<p><em>Loading...</em></p>
    )
  }

}

export default Car;