import React from "react";

const PopUp = (props) => {
  const { date, FPscore, FPname, SPscore, SPname, id, togglePopUp } = props;
  return (
    <>
      <div className="popup-container">
        <div className="popup-box">
          <span className="popup-close" onClick={togglePopUp}>
            &times;{" "}
          </span>
          <p onClick={console.log(props)}>Clicked game with ID: {id}</p>
          <div className="popup-game">
            <div className="popup-contestant">
              <span className="popup-contestant-name">{FPname}</span>
              <input
                className="popup-contestant-score"
                placeholder={FPscore}
              ></input>
            </div>
            <div className="popup-contestant">
              <span className="popup-contestant-name">{SPname}</span>
              <input
                className="popup-contestant-score"
                placeholder={SPscore}
              ></input>
            </div>
          </div>
          <button>Submit</button>
        </div>
      </div>
    </>
  );
};

export default PopUp;
