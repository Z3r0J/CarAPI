import { apiURL } from "../helpers/apiConnectionHelper";


const CarServices = {};

CarServices.GET = async () => {
    try {
        try {
            const response = await apiURL.get('Car/Get');
            return response;
        } catch (message) {
            return console.log(message);
        }
    } finally { }
}

CarServices.DELETE = (id)=>{
    try {
        try {
            const response = apiURL.delete(`Car/Delete/${id}`)

            return response;

        } catch (error) {
            return console.error(error);
        }
    }finally{ }
}

export default CarServices;