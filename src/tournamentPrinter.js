import React, { useEffect, useState } from "react";
import axios from "axios";

import BracketGenerator from "./components/BracketGenerator";
import useDataCheck from "./useDataCheck";

function Bracket() {
  const [tournamentData, setTournamentData] = useState();

  useEffect(() => {
    axios({
      method: "get",
      url: "http://localhost:8000/tournamentData",
      responseType: "json",
    })
      .then((res) => {
        setTournamentData(res.data);
      })
      .catch((err) => err);
  }, []);

  return (
    <>
      {useDataCheck(
        <BracketGenerator {...tournamentData} isUpper={true} />,
        tournamentData
      )}
      {useDataCheck(
        <BracketGenerator {...tournamentData} isUpper={false} />,
        tournamentData
      )}
    </>
  );
}

export default Bracket;
