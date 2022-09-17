import React, { Component, useState } from 'react'
import BrandServices from '../../services/BrandServices';
import CarServices from '../../services/CarServices';
import { CarCard } from './CarCard';

let response =[{}];
class Car extends Component{
  constructor(){
    super();
    this.state={
      data:[],
      brand:[],
      button:[
        {
          all:true
        }
      ]
    }
  }

  async componentDidMount(){
      response=await CarServices.GET();
    response.status===200?
      this.setState({data:response.data})
    :
    console.log(response.statusText)    
  
    BrandServices.GET().then(value=>this.setState({brand:value.data}));
}

  render(){
    return(
        this.state.data?
          <div className='row mt-4'>
            <div className='col-md-12 d-flex justify-content-between mb-2 mt-2'>
              <div className='border-right border-5 border-primary text-white fs-4 fw-bold'>Cars</div>
              <a href='/create' className='btn btn-primary shadow shadow-2 fs-5'>Create</a>
            </div>
            <div className="col-md-12 d-flex justify-content-center mb-4 mt-2">
              <div className='card bg-dark border-light w-75'>
                <div className='card-body'>
                  <button className='btn btn-primary rounded rounded-5 me-2' onClick={()=>this.setState({data:response.data})} style={{width:"10%", fontSize:"12px"}}>All</button>
                  {this.state.brand.map(brand=>{
                    const name = brand.name;
                    return(
                  <button key={brand.name} onClick={()=>this.setState({data:brand.cars})} className='btn btn-primary rounded rounded-5 me-2' style={{width:"10%", fontSize:"12px"}}>{name}</button>
                  )})}
                </div>
              </div>
            </div>
            {this.state.data.map(car=>{return(<CarCard key={car.id} car={car}/>)})}
            </div>
            :<p><em>Loading...</em></p>
    )
  }

}

export default Car;