import React from "react";
import {createRoot} from "react-dom/client";
// import { Provider } from "react-redux";
import App from "./app";
import * as serviceWorkerRegistration from "./serviceWorkerRegistration";
import reportWebVitals from "./reportWebVitals";
import "./index.css";

const rootElement = document.getElementById("root");
const root = createRoot(rootElement!);

root.render(
    // <Provider store={store}>
    <App/>
    // </Provider>
);

serviceWorkerRegistration.register();

// eslint-disable-next-line no-console
reportWebVitals(console.log);
