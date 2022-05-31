import { useEffect, useReducer } from "react";
import { nanoid } from "nanoid";
import axios from "axios";
import { useParams } from "react-router-dom";

import tournamentDataReducer, {
  ACTIONS,
  initialState,
} from "../reducer/tournamentDataReducer";
import BracketGenerator from "./BracketGenerator";
import Loader from "./Loader";
import PageNotFound from "./PageNotFound";
import Finals from "./Finals";

const Bracket = () => {
  const [state, dispatch] = useReducer(tournamentDataReducer, initialState);
  const { tournamentData, loading, pageNotFound } = state;
  const { id: tournamentId } = useParams();

  useEffect(() => {
    dispatch({ type: ACTIONS.FETCH_DATA });
    axios
      .get(`http://jaqbklo.somee.com/api/tournament/get/${tournamentId}`)
      .then((res) => {
        if (res.status === 200) {
          dispatch({ type: ACTIONS.SUCCESS, data: res.data });
        }
      })
      .catch((err) => {
        if (err.response.status === 404) {
          dispatch({ type: ACTIONS.PAGE_NOT_FOUND, pageNotFound: true });
        }
        dispatch({ type: ACTIONS.ERROR, error: err });
      })
      .then(() => {});
  }, []);

  const updateTournamentData = (isUpper, round, id, FPscore, SPscore, date) => {
    const j = tournamentData;
    if (isUpper === "upper") {
      j.roundsUpperBracket[round - 1].matches.find(
        (m) => m.id === id
      ).firstTeamScore = FPscore;
      j.roundsUpperBracket[round - 1].matches.find(
        (m) => m.id === id
      ).secondTeamScore = SPscore;
      j.roundsUpperBracket[round - 1].matches.find((m) => m.id === id).date =
        date;
    } else if (isUpper === "lower") {
      j.roundsLowerBracket[round - 1].matches.find(
        (m) => m.id === id
      ).firstTeamScore = FPscore;
      j.roundsLowerBracket[round - 1].matches.find(
        (m) => m.id === id
      ).secondTeamScore = SPscore;
      j.roundsLowerBracket[round - 1].matches.find((m) => m.id === id).date =
        date;
    } else if (isUpper === "finals") {
      j.finals.find((m) => m.id === id).firstTeamScore = FPscore;
      j.finals.find((m) => m.id === id).secondTeamScore = SPscore;
      j.finals.find((m) => m.id === id).date = date;
    }

    dispatch({ type: ACTIONS.UPDATE_SCORE, data: j });

    axios
      .post(`http://localhost:8000/tournamentData/${tournamentId}`, j)
      .then((res) => {
        console.log(res);
      })
      .catch((err) => err);
  };

  return (
    <>
      {pageNotFound ? (
        <PageNotFound />
      ) : !loading ? (
        <>
          <h1 className="title">{tournamentData.name}</h1>
          <BracketGenerator
            key={nanoid()}
            {...tournamentData}
            updateTournamentData={updateTournamentData}
            isUpper={"upper"}
          />
          <BracketGenerator
            key={nanoid()}
            {...tournamentData}
            updateTournamentData={updateTournamentData}
            isUpper={"lower"}
          />
          <Finals
            key={nanoid()}
            {...tournamentData}
            updateTournamentData={updateTournamentData}
            isUpper={"finals"}
          />
        </>
      ) : (
        <Loader />
      )}
    </>
  );
};

export default Bracket;
