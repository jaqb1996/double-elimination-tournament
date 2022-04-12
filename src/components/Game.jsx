import React, { useState } from "react";
import { nanoid } from "nanoid";

import PopUp from "./PopUp";

const Game = (props) => {
  const [popUp, setPopUp] = useState(false);

  const { date, FPscore, FPname, SPscore, SPname, id } = props;

  function styleScore(score) {
    return score !== 3
      ? { color: "rgba(0, 103, 120, 0.5)", fontWeight: 500 }
      : {};
  }

  const togglePopUp = () => {
    setPopUp(!popUp);
  };

  const cursorPopUpStyle = popUp
    ? { cursor: "default" }
    : { cursor: "pointer" };

  return (
    <>
      <span className="date">{date}</span>
      <div
        className="game"
        onClick={popUp ? null : togglePopUp}
        style={cursorPopUpStyle}
      >
        {popUp ? <PopUp {...props} togglePopUp={togglePopUp} /> : null}
        <div
          className="contestant first-contestant"
          style={styleScore(FPscore)}
        >
          <span className="contestant-name">{FPname}</span>
          <span className="contestant-score">{FPscore}</span>
        </div>
        <div className="contestant" style={styleScore(SPscore)}>
          <span className="contestant-name">{SPname}</span>
          <span className="contestant-score">{SPscore}</span>
        </div>
      </div>
    </>
  );
};

export default Game;
