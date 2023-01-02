import React, {useState} from "react";
import "./FormContainer.css";

export default function FormLogIn()
{
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    function validateForm()
    {
        return email.length > 0 && password.length > 0;
    }

    function handleSubmit(event)
    {
        event.preventDefault();

    }

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
                <button type="submit"
                    disabled = {!validateForm()}
                ></button>
            </form>
        </div>
    );
}