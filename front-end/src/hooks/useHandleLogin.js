import { useCookies } from "react-cookie";

import axios from 'axios';
const { baseURL } = require("enviroments/constants");
const { useState, useEffect } = require("react");

export function useHandleLogin(){
    const [cookies, setCookie] = useCookies(['token_access']);
    const [isLogin, setIsLogin] = useState(false)
    const [token, setToken] = useState('')

    const handleLogin = async (userRequest) => {
        try {
            const response = await axios.post(`${baseURL}Auth/login`, userRequest);
            const tokenData = response.data; // Đảm bảo bạn lấy đúng trường chứa token
            setCookie('token_access', tokenData, { path: '/' });
            setToken(tokenData);
            setIsLogin(true);
        } catch (error) {
            console.error('Login failed:', error);
            setIsLogin(false);
        }
    };

    const getCurrentUser = () => {
        return token
    }
    return {isLogin, handleLogin, getCurrentUser, token}
}