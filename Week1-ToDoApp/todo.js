const todoForm = document.querySelector("#todo-form");
const inputForm = document.querySelector("#todo");
const clearTodos = document.querySelector("#clear-todos");
const filter = document.querySelector("#filter");
const cardBody1 = document.getElementsByClassName("card-body")[0];
const cardBody2 = document.getElementsByClassName("card-body")[1];
const listGroup = document.querySelector("#todoLists");


//console.log(listGroup.children);

eventListeners();

function eventListeners(){
    // Assignment eventlistener to the elements

    todoForm.addEventListener("submit",addToDo);
    document.addEventListener("DOMContentLoaded",loadToDos);
    cardBody2.addEventListener("click",deleteTodos);
    filter.addEventListener("keyup",filterInTodos);
    clearTodos.addEventListener("click",deleteAllTodosFromStorage);

}

// Deleting all To-Do's from local storage
function deleteAllTodosFromStorage(){

    if(confirm("Are you sure to delete all To Do's ? ")){
        while(listGroup.firstElementChild){
            listGroup.removeChild(listGroup.lastElementChild);
        }
        localStorage.removeItem("mytodos");
    }
}

// Filtering in To-Do's
function filterInTodos(event){


    let todos = getValuesFromLocalStorage();
    todos.map(todo => console.log(todo));

    let wordInFilter = filter.value.toLowerCase();

    // If entered word is found in the specific To-Do's
    //      change the element's style  
    for(i of listGroup.children){
        if(i.textContent.toLowerCase().indexOf(wordInFilter) === -1){
            i.setAttribute("style","display : none ! important"); 
        }
        else{
            i.setAttribute("style","display : block "); 
        }
        
    }


}

// Deleting To-Do's from UI
function deleteTodos(event){
    if(event.target.className === "fa fa-remove"){
        let parentElement = event.target.parentNode.parentNode;
        parentElement.parentNode.removeChild(parentElement);

        deleteTodoFromStorage(event.target.parentNode.parentNode.textContent.toLowerCase());
    }
}

// Deleting specific To-Do's from local storage
function deleteTodoFromStorage(text){

    let todos = getValuesFromLocalStorage();
    
    todos.forEach(function(element,index){
        if(text === element.toLowerCase()){
                //console.log("naber");
                todos.splice(index,1);
                localStorage.setItem("mytodos",JSON.stringify(todos));
            }
        }
    );
}

// Loading To-Do's when page is loaded
function loadToDos(){

    let mytodos = getValuesFromLocalStorage();

    mytodos.forEach(element => {
        addToDoUI(element);
    });

}

// Adding To-Do's
function addToDo(event){
    const text = inputForm.value.trim();
    
    if(text === ""){
        showAlert("danger","Enter a To Do");
        
    }
    else{
        addToDoUI(text);
        addtoDoLocalStorage(text);
        showAlert("success","To Do is added successfully");
        inputForm.value = "";
    }
    
    event.preventDefault();
}

// Creating alert message according to alert type
function showAlert(type,message){

//     <div class="alert alert-danger" role="alert">
//          This is a danger alert—check it out!
//     </div>
    let div = document.createElement("div");
    div.className = `alert alert-${type}`;
    div.textContent = message;
    cardBody1.appendChild(div);

    setTimeout(() => {
        cardBody1.removeChild(div);
    }, 2000);
}

// Creating li,a and i elements and adding To-Do's on UI 
function addToDoUI(text){

    // <li class="list-group-item d-flex justify-content-between">
    // Todo 1
    // <a href = "#" class ="delete-item">
    //     <i class = "fa fa-remove"></i>
    // </a>

    // </li> 

    let li = document.createElement("li");
    li.className = "list-group-item d-flex justify-content-between";

    let a = document.createElement("a");
    a.href = "#";
    a.className = "delete-item";
    a.innerHTML = "<i class = 'fa fa-remove'></i>";
    
    li.appendChild(document.createTextNode(text));
    li.appendChild(a);

    listGroup.appendChild(li);
    
}

// Get To-Do's from local storage
function getValuesFromLocalStorage(){
    let mytodos;

    if(localStorage.getItem("mytodos") === null){
        mytodos = [];
    }
    else{
        mytodos = JSON.parse(localStorage.getItem("mytodos"));
    }

    return mytodos;
}

// Adding To-Do's to the local storage
function addtoDoLocalStorage(text){

    let mytodos = getValuesFromLocalStorage();
    mytodos.push(text);
    localStorage.setItem("mytodos",JSON.stringify(mytodos));
}