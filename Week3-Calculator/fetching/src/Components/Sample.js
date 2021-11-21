import React from 'react'
import { useContext } from 'react'
import WeatherContext from '../Context/WeatherContext';

function Sample() {

    const data = useContext(WeatherContext);

        console.log(data)
    return (
        <div>
            <h6>sample comp</h6>
            <button className="btn btn-danger"> Emre</button>
        </div>
    )
}

export default Sample
