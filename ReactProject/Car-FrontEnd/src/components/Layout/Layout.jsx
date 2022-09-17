import React, { Component } from 'react'
import { Container } from 'reactstrap'
import Car from '../Car/Car'
import { CarCard } from '../Car/CarCard'

export default class Layout extends Component {
  render() {
    return (

      <Container fluid="fluid" className='vh-100'>
        {this.props.children}
      </Container>
    )
  }
}
