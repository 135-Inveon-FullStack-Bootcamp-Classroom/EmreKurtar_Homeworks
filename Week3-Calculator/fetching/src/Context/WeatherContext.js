import React, { useState } from 'react'
import { createContext } from 'react';
import axios from 'axios'

 const WeatherContext = createContext();




export const WeatherProvider = ({children}) => {

    const myAPIKey = "845ab5753ba558963fee4d7575b9ba62";
    
    const [selectedCityName,setSelectedCityName] = useState("Istanbul");
      


    // axios.get(`https://api.openweathermap.org/data/2.5/weather?q=${cityName}&appid=${myAPIKey}&units=metric&lang=tr`)
    //     .then(res => {
    //         console.log(res)
    //         setWeatherInfo(res.data)
    //     })

    const values = {
        setSelectedCityName
    }

    return <WeatherContext.Provider value = {values}>
        {children}
    </WeatherContext.Provider>
}

export default WeatherContext;