import { apiURL } from "../helpers/apiConnectionHelper";

const BrandServices = {};

BrandServices.GET = () =>{
    try {
        try {
            const response = apiURL.get('Brand/Get')

            return response;
        } catch (error) {
            console.error(error);
        }
    } finally{}
}

export default BrandServices;