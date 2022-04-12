import React from "react";
import { nanoid } from "nanoid";
import Game from "./Game";

const BracketGenerator = (props) => {
  const {
    roundsLowerBracket,
    roundsUpperBracket,
    numberOfContestants,
    isUpper,
  } = props;
  const bracket = isUpper ? roundsUpperBracket : roundsLowerBracket;

  const gridBracketGenerator = (bracket) => {
    const grid = {
      gridTemplateColumns: `repeat(${bracket.length}, 1fr)`,
      gridTemplateRows: `repeat(${bracket[0].matches.length}, 1fr)`,
    };
    return grid;
  };

  const gridRoundsGenerator = (bracket) => {
    const grid = {
      gridTemplateColumns: `repeat(${bracket.length}, 1fr)`,
    };
    return grid;
  };

  return (
    <>
      <h3 className="bracket-badge">
        {isUpper ? "Upperbracket" : "LowerBracket"}
      </h3>
      <div className="rounds" style={gridRoundsGenerator(bracket)}>
        {bracket.map((round) => (
          <span key={nanoid()}>Runda {round.roundNumber}</span>
        ))}
      </div>
      <div
        className={`${isUpper ? "upper" : "lower"}-bracket`}
        style={gridBracketGenerator(bracket)}
      >
        {bracket.map((round) =>
          round.matches.map((game) => (
            <div
              className={
                "div" +
                game.id +
                "-" +
                numberOfContestants +
                `${isUpper ? "" : "-l"}`
              }
              key={nanoid()}
            >
              <Game
                date={game.Date}
                FPscore={game.FirstParticipant.score}
                FPname={game.FirstParticipant.name}
                SPscore={game.SecondParticipant.score}
                SPname={game.SecondParticipant.name}
                id={game.id}
              />
            </div>
          ))
        )}
      </div>
    </>
  );
};

export default BracketGenerator;
