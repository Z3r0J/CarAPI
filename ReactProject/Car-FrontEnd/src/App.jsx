import { useState } from 'react'
import Layout from './components/Layout/Layout'

function App() {
  const [count, setCount] = useState(0)

  return (
    <Layout>
      <h3>Hello</h3>
    </Layout>
  )
}

export default App
