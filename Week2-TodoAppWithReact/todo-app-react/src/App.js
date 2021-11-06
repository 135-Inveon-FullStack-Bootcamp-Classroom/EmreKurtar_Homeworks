import './App.css';
import Form from './components/Form/form';
import Todolist from './components/Todolist/todolist';

import {useState,useEffect} from 'react';
const STORAGEKEYOFTODOS = "myTodos";

function App() {

  const [inputText,setInputText] = useState("");
  const [todos,setTodos] = useState([]);
  const [status,setStatus] = useState("all");
  const [filteredTodos,setFilteredTodos] = useState([]);


  useEffect(() => {
    console.log("storage effect")
    getTodosFromLocalStorage();
  }, [])

  useEffect(() => {
    console.log("effect1")
      if(status === "completed"){
        console.log("status completed")
        setFilteredTodos(todos.filter((todo) => todo.isCompleted === true))
      }
      else if(status === "uncompleted"){
        console.log("status UNNcompleted")
        setFilteredTodos(todos.filter((todo) => todo.isCompleted === false))
      }
      else{
        setFilteredTodos(todos);
      }
    saveTodosToLocalStorage();
  },[todos])

  useEffect(() => {
    console.log("effect2")
    switch (status) {
        case "completed":
          console.log("status completed")
          setFilteredTodos(todos.filter((todo) => todo.isCompleted === true))
          break;
        case "uncompleted":
          console.log("status UNNcompleted")
          //console.log(todos.filter((todo) => todo.isCompleted === false))
          setFilteredTodos(todos.filter((todo) => todo.isCompleted === false))
          break;
        default:
          setFilteredTodos(todos);
          break;
      }
  },[status])

 


  const saveTodosToLocalStorage = () => {
    localStorage.setItem(STORAGEKEYOFTODOS,JSON.stringify(todos))
  }

  const getTodosFromLocalStorage = () => {
    if(localStorage.getItem(STORAGEKEYOFTODOS) === null){
      localStorage.setItem(STORAGEKEYOFTODOS,JSON.stringify([]))
    }else{
      let todosfromlocal = JSON.parse(localStorage.getItem(STORAGEKEYOFTODOS));
      setTodos(todosfromlocal);
    }
  }

  return (
    <div className="App">
      
      <header >
        <h1>Emre KURTAR's todo list</h1>
        </header>
        <Form
          inputText = {inputText}
          todos = {todos}
          setTodos = {setTodos}
          setInputText ={setInputText} 
          setStatus = {setStatus}
          />
          <Todolist todos = {todos} 
            setTodos = {setTodos}
            filteredTodos = {filteredTodos}
          />

    </div>
  );
}

export default App;