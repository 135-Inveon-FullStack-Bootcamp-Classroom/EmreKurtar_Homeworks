import React from 'react';
import Todo from '../Todo/todo';

function Todolist({filteredTodos, todos,setTodos}) {
  return (
    <div className="todo-container">
      <ul className="todo-list">
          
          {filteredTodos.map((todo,index) => (
              <Todo todo ={todo} todos={todos} setTodos = {setTodos} key={index} text={todo.text} />
          ))}
      </ul>
    </div>
  );
}

export default Todolist;