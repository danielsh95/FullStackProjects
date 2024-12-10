import { useEffect, useState } from "react";
import axios from 'axios';

function TodoComp() {
    const [users, setUsers] = useState([]);
    const [userTitle, setUserTitle] = useState("");
    const [userDescription, setUserDescription] = useState("");
    const [userId, setUserId] = useState("")
    const [user, setUser] = useState(undefined)

    const fetchData = async () => {
        try {
            const response = await axios.get("https://localhost:7257/api/User");
            setUsers(response.data);
        } catch (error) {
            console.error('There was an error fetching the todos!', error);
        }
    }

    useEffect(() => {
        fetchData();
    }, [])

    //const addTodo = async () => {

    //    const response = await axios.post("https://localhost:7257/api/User",
    //        JSON.stringify({ title: userTitle, description: todoDescription }),
    //        { headers: { "Content-Type": "application/json" } });
    //    console.log(response.data);
    //    fetchData();
    //    setTodoTitle("");
    //    setTodoDescription("");
    //}

    //const SearchTodo = async () => {
    //    try {
    //        const response = await axios.get(`https://localhost:7257/api/Todo/${todoId}`);
    //        setTodo(response.data);
    //    } catch (error) {
    //        console.error('There was an error fetching the todos!', error);
    //    }
    //}

    //const UpdateTodo = async () => {
    //    try {
    //        var response = await axios.put(`https://localhost:7257/api/todo/${todoId}`, { title: todoTitle, description: todoDescription });
    //        fetchData();
    //        console.log("Updated Todo:", response.data);
    //    } catch (error) {
    //        console.error("Error updating the Todo:", error);
    //    }
    //}
    //const DeleteTodo = async () => {
    //    try {
    //        var response = await axios.delete(`https://localhost:7257/api/todo/${todoId}`, { title: todoTitle, description: todoDescription });
    //        fetchData();
    //        console.log("Delete Todo:", response.data);
    //    } catch (error) {
    //        console.error("Error delete the Todo:", error); 

    //    }
    //}

    return (
        <div>
            <b>Show all todos:</b>
            <ul>

                {
                    users.map((user, keyy) =>
                        <li key={keyy}> 
                            <b>id: </b>{user.id},&nbsp;&nbsp;
                            <b>UserName: </b>{user.userName},&nbsp;&nbsp;
                            <b>Email: </b>{user.email} &nbsp;&nbsp;
                            <b>Todos: </b>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <ul>
                                {

                                    user.todoLists.todos.map(todo =>
                                        <li key={todo.id}>
                                            <b> Id: </b>{todo.id}&nbsp;&nbsp;
                                            <b> Title: </b>{todo.title}&nbsp;&nbsp;
                                            <b> Description: </b>{todo.description}&nbsp;&nbsp;
                                        </li>
                                    )
                                }
                            </ul>
                        </li> 
                    )
                }
            </ul>



            {/*ID:<input type="text" onChange={e => setTodoId(e.target.value)} value={todoId} />*/}
            {/*Title:  <input type='text' onChange={e => setTodoTitle(e.target.value)} value={todoTitle} /> <br />*/}
            {/*Description:  <input type='text' onChange={e => setTodoDescription(e.target.value)} value={todoDescription} /> <br />*/}

            {/*<input type='button' onClick={addTodo} value="Add"></input> <br />*/}
            {/*<input type="button" onClick={SearchTodo} value="Search" />*/}
            {/*{todo != undefined ? `Result: ${todo.title} (${todo.description})` : ""}<br />*/}
            {/*<input type="button" onClick={UpdateTodo} value="Update" />*/}
            {/*<input type="button" onClick={DeleteTodo} value="Delete" />*/}


        </div>
    );
}

export default TodoComp;