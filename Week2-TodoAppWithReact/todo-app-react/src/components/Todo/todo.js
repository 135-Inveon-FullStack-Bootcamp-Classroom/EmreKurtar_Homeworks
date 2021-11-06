import React from 'react'

function Todo({text, todo, todos, setTodos}) {

    // Events

    const deleteHandler = () => {
        setTodos(todos.filter((item)=>(
            item.text.trim().toLowerCase() !== todo.text.trim().toLowerCase()
        )))
    }

    const completeHandler = () => {
        setTodos(todos.map((item) => {
            if(item.text.trim().toLowerCase() === todo.text.trim().toLowerCase()){
                console.log("item completed")
                return {...item, isCompleted :!todo.isCompleted}
            }
            return item;
        }
        ))
    }

    return (
        <div className="todo">
            <li className={`todo-item ${todo.isCompleted ? `completed` : ``}`}>{text}</li>
            <button onClick = {completeHandler} className="complete-btn">
                <i className="fas fa-check"></i>
            </button>
            <button onClick = {deleteHandler} className="trash-btn">
                <i className="fas fa-trash"></i>
            </button>
        </div>
    )
}

export default Todo