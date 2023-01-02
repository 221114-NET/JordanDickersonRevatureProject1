import './App.css';
import FormLogIn from './FormContainer/FormLogIn';
import FormSignUp from './FormContainer/FormSignUp';
import Layout from './LayoutContainer/Layout';
import Home from './HomeContainer/Home';
import {BrowserRouter, Routes, Route} from "react-router-dom";

function App() {
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="login" element={<FormLogIn/>} />
            <Route path="signup" element={<FormSignUp/>} />
          </Route>
        </Routes>
      </BrowserRouter>
      
    </div>
  );
}

export default App;
