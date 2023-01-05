import React, {useState, useEffect } from "react";
import "./FormContainer.css";

export default function FormLogIn()
{
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [errorMessage, setErrorMessage ] = useState("");

    function validateForm()
    {
        return email.length > 0 && password.length > 0;
    }

    function handleSubmit(event)
    {
        event.preventDefault();

        const dtoLogIn = {
            email: email,
            password: password
        };

        fetch("http://localhost:5255/api/Request/LogInRequest", {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dtoLogIn)
            }).then((response) => { 
                if(response.status >= 200 && response.status < 299)
                {
                    const promise = response.json();
                    console.log(promise)
                }               
            }).catch(error => console.error('Error: ', error));
        
        /*.then(res => res.json())
        .then(
            (result) => {}
        )*/
    }

    /*useEffect(()=> {
        
        
    })*/

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <input type="email" 
                    value={email}
                    autoFocus
                    onChange={(e) => setEmail(e.target.value)} 
                    placeholder="Enter your email"
                />
                <input type="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}  
                    placeholder="Enter your password" 
                />
                <input type="submit"
                    disabled = {!validateForm()}
                />
            </form>
        </div>
    );
}