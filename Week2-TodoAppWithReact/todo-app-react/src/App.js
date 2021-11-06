import './App.css';

//Importing components
import Form from './components/Form/form';
import Todolist from './components/Todolist/todolist';

//Hooks
import {useState,useEffect} from 'react';

// My constant local storage key 
const STORAGEKEYOFTODOS = "myTodos";

function App() {

  //States
  const [inputText,setInputText] = useState("");
  const [todos,setTodos] = useState([]);
  const [status,setStatus] = useState("all");
  const [filteredTodos,setFilteredTodos] = useState([]);

  //Events
  
    //It is called only once when app is rendered 
    //      for taking existing todos from local storage
    //          and showing in UI
  useEffect(() => {
    getTodosFromLocalStorage();
  }, [])

  useEffect(() => {
      if(status === "completed"){
        setFilteredTodos(todos.filter((todo) => todo.isCompleted === true))
      }
      else if(status === "uncompleted"){
        setFilteredTodos(todos.filter((todo) => todo.isCompleted === false))
      }
      else{
        setFilteredTodos(todos);
      }
    saveTodosToLocalStorage();
  },[todos])

  useEffect(() => {
    switch (status) {
        case "completed":
          setFilteredTodos(todos.filter((todo) => todo.isCompleted === true))
          break;
        case "uncompleted":
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
        <h1>Emre KURTAR's To-Do</h1>
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