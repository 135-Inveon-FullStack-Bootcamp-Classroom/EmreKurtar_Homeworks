import React, { useState } from "react";
import turkeycities from './cities.json'

function FormInput({setSelectedCityName}) {

    const [isActive,setIsActive] = useState(false)

    

  return (
    <div className="dropdown">
        <div className="dropdown-btn" onClick={(e)=>setIsActive(!isActive)}>
            Select A City
            <i className="fas fa-caret-down"></i>
        </div>

        {isActive && (
            <div className="dropdown-content">
                {turkeycities.map((item)=>{
                    return(
                    <div className="dropdown-item" 
                    onClick={() => {
                        setSelectedCityName(item.name)
                        setIsActive(false)
                        }}>
                        {item.name}
                    </div>
                    )
                })}
            </div>
        )}

    </div>
  )
}

export default FormInput;
