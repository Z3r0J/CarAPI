import React, { useState } from 'react'
import Layout from './components/Layout/Layout'
import 'bootstrap/dist/css/bootstrap.min.css'
import Car from './components/Car/Car'
import Spinner from './components/Spinner/Spinner';

const Router = React.lazy(() => import('./router/Router'));


function App() {
  return (
    <React.Suspense fallback={<Spinner/>}>
      <Layout>
        <Router/>
      </Layout>
    </React.Suspense>
  )
}

export default App
