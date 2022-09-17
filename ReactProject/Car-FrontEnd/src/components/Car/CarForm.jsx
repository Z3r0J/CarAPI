import React, { useEffect, useState } from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import { Toast,ToastBody, ToastHeader } from 'reactstrap';
import BrandServices from '../../services/BrandServices';
import CarServices from '../../services/CarServices';

export const CarForm = () => {

  const { id } = useParams();
  const navigate = useNavigate();
  const [success,setSuccess] = useState(false);

  const [mode,setMode] = useState({
    create:true,
    edit:false
  });

  const [CarBrand,setCarBrand] = useState([]);

  const [formValue,setFormValue] = useState(
    {
      id: 0,
      model: "",
      photoUrl: "",
      year: 0,
      speed: 0,
      brandId: 1
    }
  )

  useEffect(()=>{
      id!==undefined?setMode({create:false,edit:true}):"";

      id!==undefined?CarServices.GETBYID(id).then(value=>setFormValue({...value.data})):"";

      BrandServices.GET().then(value=>setCarBrand(value.data))

  },[])

  const handleInputChange = (e)=>{
    setFormValue(
      {
        ...formValue,
        [e.currentTarget.name]: e.currentTarget.value
      }
      )

      console.log(formValue);
  }

  const handleSubmitForm = (e) =>{
    e.preventDefault();
    const response = id!==undefined?CarServices.UPDATE(id,formValue):CarServices.CREATE(formValue);
    response.then(()=>{setTimeout(()=>{navigate('/')},3000);setSuccess(true)})
  }

  
  return (
    <div className='row mt-4 d-flex justify-content-center'>
      <div className='col-xl-4 col-lg-4 col-sm-4 col-md-12'>
        <div className='card bg-dark text-white border-light shadow shadow-3 rounded rounded-2'>
          <div className='card-header text-center border-0'>
          <h3>{mode.edit?`Edit`: "Create"}</h3>
          </div>
          <div className='card-body'>
            <form onSubmit={handleSubmitForm}>
              <label className='form-label'>Model: </label>
              <input value={formValue.model||""} name="model" onChange={handleInputChange} type="text" className='form-control' required/>
              <label className='form-label'>Photo URL: </label>
              <input value={formValue.photoUrl||""} name="photoUrl" onChange={handleInputChange} type="text" className='form-control' required/>
              <label className='form-label'>Year: </label>
              <input value={formValue.year||""} name="year" onChange={handleInputChange} type="number" className='form-control' required/>
              <label className='form-label'>Speed: </label>
              <input value={formValue.speed||""} name="speed" onChange={handleInputChange} type="number" className='form-control' required/>
              <label className='form-label'>Brand: </label>
              <select value={Number(formValue.brandId)||1} name="brandId" onChange={handleInputChange} className='form-control' required>
                {CarBrand.map(brand=>{
                  return(
                    <option key={brand.id} value={Number(brand.id)}>{brand.name}</option>
                  )
                })}
              </select>
              <a href='/' className='btn btn-danger float-end mt-4 mb-3 me-1 ms-1'>Cancel</a>
              <button type='submit' className='btn btn-primary float-end mt-4 mb-3 me-1 ms-1'>{mode.edit?"Edit":"Create"}</button>
            </form>
          </div>
        </div>
      </div>
      {success?
  <div className="d-flex justify-content-end mt-4 rounded">
  <Toast>
    <ToastHeader>
     {mode.edit?"Edit":"Create"}
    </ToastHeader>
    <ToastBody>
    The Car was {id!==undefined?"edited":"created"} sucessfully
    </ToastBody>
  </Toast>
</div>
      :""}
    </div>
    
  )
}
