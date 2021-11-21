import React, { useContext }  from 'react'
import FormInput from './FormInput'
import Sample from './Sample'
import WeatherContext from '../Context/WeatherContext'

function Container(){

    const {setSelectedCityName} = useContext(WeatherContext)

    return(
        <div className="container">
        <FormInput setSelectedCityName={setSelectedCityName}/>
         <Sample />
         </div>
    )

}

export default Container