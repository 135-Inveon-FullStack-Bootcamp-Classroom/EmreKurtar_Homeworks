import React, { useState, createContext } from "react";

export const CalcContext = createContext();

export const CalcProvider = ({ children }) => {

    //USESTATE HOOKS
  const [mainText, setMainText] = useState("0");
  const [lastResult, setLastResult] = useState(0);
  const [history,setHistory] = useState("");
  const [lastOperation,setLastOperation] = useState();

    // Button Click Handle

  const handleKeyClick = (isNumber, label, editing,operator) => {

    if (isNumber) {
        const lastElementofHistory = history[history.length-2];
        const conditionOflastElementofHistory = (
            lastElementofHistory === "+" ||
            lastElementofHistory === "-" ||
            lastElementofHistory === "x" ||
            lastElementofHistory === "/" 
            );

    // If user enter a number, after input an operation 
    //      set the operation to the "LastOperation" useState hooks.
        
    // If there is no operation before the number, take the number and
    //      add the value to the mainText(Number) as a string

        if(conditionOflastElementofHistory){
            setLastOperation(lastElementofHistory);
            setMainText(label)
            setHistory(history + label)
        }else if(mainText === "0"){
            setMainText(label)
            setHistory(history + label)
        }
        else if(mainText !== "0"){
            setMainText(mainText + label)
            setHistory(history + label)
        }
    }

    if(editing){

        switch (label) {
            case "C":
                setMainText("")
                setHistory("")
                setLastResult(0)
                return;
            default:
                break;
        }
        
    }

    if (operator) {

        if(history.length !== 0){
            const lastElementofHistory = history[history.length-2];
            const conditionOflastElementofHistory = (
                lastElementofHistory === "+" ||
                lastElementofHistory === "-" ||
                lastElementofHistory === "x" ||
                lastElementofHistory === "/" 
                );

            //If user entering a false operation and then
            //      if the user wants to change this false operation 
            //          this block control that condition.
            if(conditionOflastElementofHistory){
                
              setHistory(history.slice(0,history.length-2) + " " +label + " ")
              return;
            }
            setHistory(history + " " + label + " ")
        }
        

        
        const specialOperatorCondition = 
        (
            label === "x²" || 
            label === "1/x" ||
            label === "√"
        );

        // If special operator is founded, just change the mainText and history
        //      because actual operation is executed after normal operator clicked.
        if(specialOperatorCondition){
            switch (label) {
                case "x²":  
                        setMainText(Math.pow(mainText,2));
                        setHistory(`${history.slice(0,-(mainText.length))} sqr(${mainText}) `);
                        return;
                case "√":  
                        setMainText(Math.sqrt(mainText));
                        setHistory(`${history.slice(0,-(mainText.length))} √(${mainText}) `);
                        return;
                case "1/x":  
                        setMainText(1 / Number(mainText));
                        setHistory(`${history.slice(0,-(mainText.length))} 1/(${mainText}) `);
                        return;    

                default:

                
                    return;
            }
        }



        if(lastOperation === undefined){
            setLastResult(Number(mainText))
            setLastOperation(label);
        }
        else{
            switch (lastOperation) {
                //Math operations depend on lastOperation state

                //In end of the every case, set the lastOperation with current label
                case "+":
                    setLastResult(lastResult + Number(mainText))
                    setMainText(Number(lastResult) + Number(mainText))
                    setLastOperation(label);
                    break;
            
                case "-":
                    setLastResult(lastResult - Number(mainText))
                    setMainText(Number(lastResult) - Number(mainText))
                    setLastOperation(label);
                    break;

                case "/":
                    setLastResult(lastResult / Number(mainText))
                    setMainText(Number(lastResult) / Number(mainText))
                    setLastOperation(label);
                    break;
                case "x":
                    setLastResult(lastResult * Number(mainText))
                    setMainText(Number(lastResult) * Number(mainText))
                    setLastOperation(label);
                    break;
                case "=":
                    setLastResult(lastResult * Number(mainText))
                    setMainText(Number(lastResult) * Number(mainText))
                    setLastOperation(label);
                    break;
                
                default:
                    break;
            }
        }

      
    }
}
  

  const values = {
    mainText,
    history,
    setMainText,
    handleKeyClick,
    lastResult,
    
  }

  return (
    <CalcContext.Provider value={values}>
      {children}
    </CalcContext.Provider>
  );
};
