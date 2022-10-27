// TODO List, stored in LocalStorage

"use strict";

const ENTER_KEY = 13;

const htmlEscapes = {
    "&": "&amp;",
    "<": "&lt;",
    ">": "&gt;",
    '"': "&quot;",
    "'": "&#x27;",
    "`": "&#x60;"
};

const reUnescapedHtml = /[&<>"'`]/g;

function escapeHtmlChar(chr) {
    return htmlEscapes[chr];
}

function escapeHtml(string) {
    return string.replace(reUnescapedHtml, escapeHtmlChar);
}

function createUniqueId() {
    let uuid = "";

    for (let i = 0; i < 32; i++) {
        let random = (Math.random() * 16) | 0;
        if (i === 8 || i === 12 || i === 16 || i === 20) {
            uuid += "-";
        }
        uuid += (i === 12 ? 4 : i === 16 ? (random & 3) | 8 : random).toString(
            16
        );
    }
    return uuid;
}

class Todo {
    constructor(title, completed, id = createUniqueId()) {
        this.id = id;
        this.title = title;
        this.completed = completed;
    }
}

class TodoList {
    constructor(key = "the one and only todo list") {
        this.todos = [];
        this.key = key;
        this.load();
    }

    load() {
        let from_storage = localStorage.getItem(this.key);
        if (from_storage) {
            let data_for_objects = JSON.parse(from_storage);
            for (let data of data_for_objects) {
                let todo = new Todo(data.title, data.completed, data.id);
                this.todos.push(todo);
            }
        }
        console.log(`loaded ${this.todos.length} todos from localstorage`);
        console.dir(this.todos);
    }

    save() {
        localStorage.setItem(this.key, JSON.stringify(this.todos));
        console.log(`saved ${this.todos.length} todos to localstorage`);
    }

    addTodo(text) {
        let trimmedText = text.trim();

        if (trimmedText) {
            let todo = new Todo(trimmedText, false);
            this.todos.push(todo);
        }
        this.save();
    }

    removeTodoById(id) {
        this.todos = this.todos.filter(t => t.id !== id);
        this.save();
    }

    getTodoById(id) {
        for (let i = 0, l = this.todos.length; i < l; i++) {
            if (this.todos[i].id === id) {
                return this.todos[i];
            }
        }
    }

    editTodo(todoId, text) {
        let todo = this.getTodoById(todoId);
        todo.title = text;
        this.save();
    }
}

let todo_list = new TodoList();

window.addEventListener("load", function() {
    document.getElementById('nojs').remove();

    document
        .getElementById("new-todo")
        .addEventListener("keypress", typeInNewTodo, false);
    refreshDisplay(todo_list);
});

function typeInNewTodo(event) {
    if (event.keyCode === ENTER_KEY) {
        todo_list.addTodo(document.getElementById("new-todo").value);
        refreshDisplay(todo_list);
    }
}

function typeInEditTodo(event) {
    if (event.keyCode === ENTER_KEY) {
        let inputEditTodo = event.target,
            trimmedText = inputEditTodo.value.trim(),
            todoId = event.target.id.slice(6);
        todo_list.editTodo(todoId, trimmedText);
        refreshDisplay(todo_list);
    }
}

function inputEditTodoBlurHandler(event) {
    var inputEditTodo = event.target,
        todoId = event.target.id.slice(6);

    todo_list.editTodo(todoId, inputEditTodo.value);
    refreshDisplay(todo_list);
}

function spanDeleteClickHandler(event) {
    todo_list.removeTodoById(event.target.getAttribute("data-todo-id"));
    refreshDisplay(todo_list);
}

function dblclickHandler(event) {
    var todoId = event.target.getAttribute("data-todo-id"),
        div = document.getElementById("li_" + todoId),
        inputEditTodo = document.getElementById("input_" + todoId);

    div.className = "editing"; // makes the input field visible
    inputEditTodo.value = todo_list.getTodoById(todoId).title;
    inputEditTodo.focus();
}

function checkboxChangeHandler(event) {
    var checkbox = event.target,
        todo = todo_list.getTodoById(checkbox.getAttribute("data-todo-id"));

    todo.completed = checkbox.checked;
    todo_list.save();
    refreshDisplay(todo_list);
}

function refreshDisplay(todo_list) {
    document.getElementById("new-todo").value = "";

    let ul = document.getElementById("todo-list");
    ul.innerHTML = "";

    for (let todo of todo_list.todos) {
        let li = document.createElement("li");
        li.id = "li_" + todo.id;
        li.innerHTML = `
          <div class="view" data-todo-id="${todo.id}">
              <input 
                  class="toggle" 
                  data-todo-id="${todo.id}" 
                  type="checkbox" 
                  id="checkbox_${todo.id}">
              <label 
                  data-todo-id="${todo.id}" 
                  id="label_${todo.id}">${escapeHtml(todo.title)}</label>
              <button 
                  class="destroy" 
                  data-todo-id="${todo.id}" 
                  id="del_${todo.id}"></button>
          </div>
          <input id="input_${todo.id}" class="edit">
        `;

        ul.appendChild(li);

        let checkbox = document.getElementById(`checkbox_${todo.id}`);
        if (todo.completed) {
            li.className += "completed";
            checkbox.checked = true;
        }
        checkbox.addEventListener("change", checkboxChangeHandler);

        document
            .getElementById(`label_${todo.id}`)
            .addEventListener("dblclick", dblclickHandler);
        document
            .getElementById(`del_${todo.id}`)
            .addEventListener("click", spanDeleteClickHandler);
        document
            .getElementById(`input_${todo.id}`)
            .addEventListener("keypress", typeInEditTodo);
        document
            .getElementById(`input_${todo.id}`)
            .addEventListener("blur", inputEditTodoBlurHandler);
    }
}
