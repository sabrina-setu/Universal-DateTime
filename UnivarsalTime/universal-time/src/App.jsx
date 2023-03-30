import axios from "axios";
import { useEffect, useState } from "react";
import "./App.css";

const http = axios.create({
    baseURL: "https://localhost:7131/api",
});
const route = "/Times";

function App() {
    const [data, setData] = useState(null);
    useEffect(() => {
        getTimes();
    }, []);

    const getTimes = () => {
        http.get(route).then((response) => {
            setData(response.data);
            console.debug(response.data);
        });
    };
    return (
        <div className="App">
            {data?.map((i) => (
                <div key={i.id}>
                    <p> {new Date(i.createdAt).toLocaleString()}</p>
                </div>
            ))}
        </div>
    );
}

export default App;
