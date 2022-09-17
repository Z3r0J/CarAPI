import axios from "axios";


export const apiURL = axios.create({
baseURL: 'https://localhost:5001/api/'
});