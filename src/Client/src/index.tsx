import * as React from "react"
import * as ReactDOM from "react-dom"
import { MyButton } from "./hello"
import 'antd/dist/antd.css';

type FetchState =
    | { status: "loading"; progress: number }
    | { status: "success"; data: string }
    | { status: "error" };


export class App extends React.Component {
    render() {
        return <>
            <h1>Hello, world!</h1>
            <MyButton />
            <div>
                {this.go({ status: "error" })}
            </div>
            <div>
                {this.go({ status: "loading", progress: 99 })}
            </div>
        </>
    }

    go(fetchState: FetchState) {
        switch (fetchState.status) {
            case "loading":
                return <p>Loading... {fetchState.progress}%</p>;
            case "success":
                return <p>{fetchState.data}</p>;
            case "error":
                return <p>Oops, an error occured</p>;
        }
    }
}

var el = document.getElementById("root")
ReactDOM.render(<App />, el)