import React, { Fragment } from "react";
import { nanoid } from "nanoid";
import Game from "./Game";

const BracketGenerator = (props) => {
  const {
    lowerBracket,
    upperBracket,
    numberOfContestants,
    isUpper,
    updateTournamentData,
  } = props;
  const bracket = isUpper === "upper" ? upperBracket : lowerBracket;

  const gridBracketGenerator = (bracket) => {
    const grid = {
      gridTemplateColumns: `repeat(${bracket.length}, 1fr)`,
      gridTemplateRows: `repeat(${bracket[0].matches.length + 1}, auto)`,
    };
    return grid;
  };

  return (
    <div className="bracket">
      <h3 className="bracket-badge">
        {isUpper === "upper" ? "Upperbracket" : "LowerBracket"}
      </h3>
      <div
        className={`${isUpper === "upper" ? "upper" : "lower"}-bracket`}
        style={gridBracketGenerator(bracket)}
      >
        {bracket.map((round) => (
          <Fragment key={nanoid()}>
            <div
              className={`rounds r-${round.roundNumber}-${numberOfContestants}${
                isUpper === "upper" ? "" : "-l"
              }`}
              key={nanoid()}
            >
              <span>Runda {round.roundNumber}</span>
            </div>
            {round.matches.map((game) => (
              <div
                className={
                  "div" +
                  game.id +
                  "-" +
                  numberOfContestants +
                  `${isUpper === "upper" ? "" : "-l"}`
                }
                key={nanoid()}
              >
                <Game
                  date={game.date}
                  round={round.roundNumber}
                  FPscore={game.firstTeamScore}
                  FPname={game.firstTeamName}
                  SPscore={game.secondTeamScore}
                  SPname={game.secondTeamName}
                  id={game.id}
                  updateTournamentData={updateTournamentData}
                  isUpper={isUpper}
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

export default BracketGenerator;
