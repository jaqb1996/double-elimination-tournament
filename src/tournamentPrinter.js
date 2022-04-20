import React, { useEffect, useState, useReducer } from "react";
import axios from "axios";

import BracketGenerator from "./components/BracketGenerator";
import useDataCheck from "./useDataCheck";
import { nanoid } from "nanoid";

function Bracket() {
  const [tournamentData, setTournamentData] = useState();
  const [, forceUpdate] = useReducer((x) => x + 1, 0);

  useEffect(() => {
    axios({
      method: "get",
      url: "http://localhost:8000/tournamentData",
      responseType: "json",
    })
      .then((res) => {
        setTournamentData(res.data);
      })
      .catch((err) => err)
      .then(() => {});
  }, []);

  const updateTournamentData = (isUpper, round, id, FPscore, SPscore) => {
    const j = tournamentData;

    (isUpper === true ? j.roundsUpperBracket : j.roundsLowerBracket)[
      round - 1
    ].matches.find((m) => m.id === id).FirstParticipant.score = FPscore;
    (isUpper === true ? j.roundsUpperBracket : j.roundsLowerBracket)[
      round - 1
    ].matches.find((m) => m.id === id).SecondParticipant.score = SPscore;
    console.log(j);
    setTournamentData(j);
    axios
      .put("http://localhost:8000/tournamentData", j)
      .then((res) => {
        console.log(res);
      })
      .catch((err) => err)
      .then(() => {});
    forceUpdate();
  };

  return (
    <>
      {useDataCheck(
        <BracketGenerator
          key={nanoid()}
          {...tournamentData}
          updateTournamentData={updateTournamentData}
          isUpper={true}
        />,
        tournamentData
      )}
      {useDataCheck(
        <BracketGenerator key={nanoid()} {...tournamentData} isUpper={false} />,
        tournamentData
      )}
    </>
  );
}

export default Bracket;
