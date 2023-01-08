import React, {useState, useEffect } from "react";
import "./FormContainer.css";

export default function FormLogIn()
{
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage ] = useState("");

    function validateForm()
    {
        return email.length > 0 && password.length > 0;
    }

    async function handleSubmit(event)
    {
        event.preventDefault();

        const dtoLogIn = {
            email: email,
            password: password
        };

        fetch("http://localhost:5255/api/Request/LogInRequest", {
            method: 'POST',
            headers: {
                'Accept': 'text/dtotoken',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(dtoLogIn)
            }).then((response) => { 
                if(response.status >= 200 && response.status < 299)
                {
                    console.log(response.json())
                }               
            
                
            }).then((data) => {
                if(data !== undefined)
                {
                    setMessage("HI")
                }
                console.log(data)
                //return data;
            }).catch(error => console.error('Error: ', error));

    }

    useEffect(()=> {
        console.log("Use Effect has happened!")
    },[message])

    return (
        <div>
            <h1>{message}</h1>
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