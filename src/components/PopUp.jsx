import React, { useState } from "react";
import axios from "axios";
// import { TournamentDataContext } from "../tournamentDataContext";

const PopUp = (props) => {
  const {
    updateTournamentData,
    isUpper,
    round,
    date,
    FPscore,
    FPname,
    SPscore,
    SPname,
    id,
    togglePopUp,
  } = props;

  // const context = useContext(TournamentDataContext);
  // console.log(context);

  const [formData, setFormData] = useState({
    FPscore: FPscore,
    SPscore: SPscore,
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    updateTournamentData(
      isUpper,
      round,
      id,
      formData.FPscore,
      formData.SPscore
    );
  };

  const handleChange = (e) => {
    setFormData((prevData) => ({ ...prevData, [e.target.id]: e.target.value }));
  };

  return (
    <>
      <div className="popup-container">
        <form className="popup-box">
          <div className="popup-close" onClick={togglePopUp}>
            &times;{" "}
          </div>
          {/* <p onClick={console.log(props)}>Clicked game with ID: {id}</p> */}
          <div className="popup-game">
            <div className="popup-contestant">
              <span className="popup-contestant-name">{FPname}</span>
              <input
                className="popup-contestant-score"
                id="FPscore"
                value={formData.FPscore}
                onChange={handleChange}
              ></input>
            </div>
            <div className="popup-contestant">
              <span className="popup-contestant-name">{SPname}</span>
              <input
                className="popup-contestant-score"
                id="SPscore"
                value={formData.SPscore}
                onChange={handleChange}
              ></input>
            </div>
          </div>
          <button
            type="submit"
            onClick={handleSubmit}
            className="popup-submit-btn"
          >
            Submit
          </button>
        </form>
      </div>
    </>
  );
};

export default PopUp;
