import React from "react";

import { Routes, Route, Redirect } from "react-router-dom";

import "./App.css";
import Bracket from "./components/Brakcet";

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path="/" />
        <Route path={`/:id`} element={<Bracket />} />
      </Routes>
    </div>
  );
}

export default App;
