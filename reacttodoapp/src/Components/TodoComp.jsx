import { useEffect, useState } from "react";
import axios from 'axios';

function TodoComp() {
    const [todos, setTodos] = useState([]);
    const [todoTitle, setTodoTitle] = useState("");
    const [todoDescription, setTodoDescription] = useState("");
    const [todoId, setTodoId] = useState("")
    const [todo, setTodo] = useState(undefined)

    const fetchData = async () => {
        try {
            const response = await axios.get("https://localhost:7257/api/Todo");
            setTodos(response.data);
        } catch (error) {
            console.error('There was an error fetching the todos!', error);
        }
    }

    useEffect(() => {
        fetchData();
    }, [])

    const addTodo = async () => {

        const response = await axios.post("https://localhost:7257/api/Todo",
            JSON.stringify({ title: todoTitle, description: todoDescription }),
            { headers: { "Content-Type": "application/json" } });
        console.log(response.data);
        fetchData();
        setTodoTitle("");
        setTodoDescription("");
    }

    const SearchTodo = async () => {
        try {
            const response = await axios.get(`https://localhost:7257/api/Todo/${todoId}`);
            setTodo(response.data);
        } catch (error) {
            console.error('There was an error fetching the todos!', error);
        }
    }

    const UpdateTodo = async () => {
        try {
            var response = await axios.put(`https://localhost:7257/api/todo/${todoId}`, { title: todoTitle, description: todoDescription });
            fetchData();
            console.log("Updated Todo:", response.data);
        } catch (error) {
            console.error("Error updating the Todo:", error);
        }
    }
    const DeleteTodo = async () => {
        try {
            var response = await axios.delete(`https://localhost:7257/api/todo/${todoId}`, { title: todoTitle, description: todoDescription });
            fetchData();
            console.log("Delete Todo:", response.data);
        } catch (error) {
            console.error("Error delete the Todo:", error); 

        }
    }

    return (
        <div>
            <b>Show all todos:</b>
            <ul>

                {
                    todos.map((todo, keyy) =>
                        <li key={keyy}>id: {todo.id},  Title:  {todo.title},        Description: {todo.description}</li>
                    )
                }
            </ul>



            ID:<input type="text" onChange={e => setTodoId(e.target.value)} value={todoId} />
            Title:  <input type='text' onChange={e => setTodoTitle(e.target.value)} value={todoTitle} /> <br />
            Description:  <input type='text' onChange={e => setTodoDescription(e.target.value)} value={todoDescription} /> <br />

            <input type='button' onClick={addTodo} value="Add"></input> <br />
            <input type="button" onClick={SearchTodo} value="Search" />
            {todo != undefined ? `Result: ${todo.title} (${todo.description})` : ""}<br />
            <input type="button" onClick={UpdateTodo} value="Update" />
            <input type="button" onClick={DeleteTodo} value="Delete" />


        </div>
    );
}

export default TodoComp;