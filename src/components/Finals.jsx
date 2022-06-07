import React, { Fragment } from "react";
import { nanoid } from "nanoid";
import Game from "./Game";

const Finals = (props) => {
  const { finals, isUpper, updateTournamentData } = props;
  return (
    <div className="bracket">
      <h3 className="bracket-badge">Finals</h3>
      <div className={"finals-bracket"}>
        {finals.map((round) => (
          <Fragment key={nanoid()}>
            <div className={`rounds r-${round.roundNumber}-f`} key={nanoid()}>
              <span>Runda {round.roundNumber}</span>
            </div>
            {round.matches.map((game) => (
              <div className={"div" + game.id + "-f"} key={nanoid()}>
                <Game
                  date={game.date}
                  round={round.roundNumber}
                  FPscore={game.FirstParticipant.score}
                  FPname={game.FirstParticipant.name}
                  SPscore={game.SecondParticipant.score}
                  SPname={game.SecondParticipant.name}
                  id={game.id}
                  isUpper={isUpper}
                  updateTournamentData={updateTournamentData}
                  key={nanoid()}
                />
              </div>
            ))}
          </Fragment>
        ))}
      </div>
    </div>
  );
};

export default Finals;
