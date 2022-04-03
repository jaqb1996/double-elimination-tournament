const matchWrapperWidth = 150;
const matchWrapperHeight = 80;
const leftMargin = 10;
const topMargin = 10;
const VerticalBreakBetweenMatches = 5;
const HorizontalBreakBetweenRounds = 20;
function printTournamentBracket(wrapper, matches) {
    winnersBracket = matches["W"];
    for (let roundNumber = 0; roundNumber < winnersBracket.length; roundNumber++) {
        const round = winnersBracket[roundNumber];
        for (let matchNumber = 0; matchNumber < round.length; matchNumber++) {
            const match = round[matchNumber];
            position_x = leftMargin + roundNumber * (matchWrapperWidth + HorizontalBreakBetweenRounds);
            position_y = topMargin + 0.5 * roundNumber * (matchWrapperHeight + VerticalBreakBetweenMatches) + matchNumber * ((roundNumber + 1) * matchWrapperHeight + VerticalBreakBetweenMatches);
            console.log(position_x + ", " + position_y);
            matchWrapper = printMatch(match.Date, match.FirstParticipant, match.SecondParticipant, position_x, position_y);
            wrapper.appendChild(matchWrapper);
        }
    }
    // matchDateStr = "pon 12";
    // firstTeamName = "Team 1";
    // secondTeamName = "Team 2";
    // position_x = 100;
    // position_y = 200;
    // matchWrapper = printMatch(matchDateStr, firstTeamName, secondTeamName, position_x, position_y);
    wrapper.appendChild(matchWrapper);
}
function printMatch(matchDateStr, firstTeamName, secondTeamName, position_x, position_y) {
    const matchWrapper = document.createElement('div');
    const matchDateDiv = document.createElement('div');
    matchDateDiv.textContent = matchDateStr;
    matchDateDiv.style.color = 'gray';
    matchWrapper.appendChild(matchDateDiv);

    const firstTeamNameDiv = document.createElement('div');
    firstTeamNameDiv.textContent = firstTeamName;
    firstTeamNameDiv.style.backgroundColor = 'blue';
    firstTeamNameDiv.style.color = 'white';
    matchWrapper.appendChild(firstTeamNameDiv);

    const secondTeamNameDiv = document.createElement('div');
    secondTeamNameDiv.textContent = secondTeamName;
    secondTeamNameDiv.style.cssText += firstTeamNameDiv.style.cssText;
    matchWrapper.appendChild(secondTeamNameDiv);
    
    matchWrapper.style.display = "flex";
    matchWrapper.style.flexDirection = "column";
    matchWrapper.style.cssText += "justify-content: flex-start;"
    matchWrapper.style.width = matchWrapperWidth + "px";
    matchWrapper.style.height = matchWrapperHeight + "px";
    matchWrapper.style.position = "absolute";
    matchWrapper.style.top = position_y + "px";
    matchWrapper.style.left = position_x + "px";

    return matchWrapper;
}

matches = {
    W: [
        [
            {
                "FirstParticipant": "Team 1",
                "SecondParticipant": "Team 2",
                "Date": "Pon 12"
            },
            {
                "FirstParticipant": "Team 3",
                "SecondParticipant": "Team 4",
                "Date": "Pon 13"
            },
            {
                "FirstParticipant": "Team 5",
                "SecondParticipant": "Team 6",
                "Date": "Pon 14"
            },
            {
                "FirstParticipant": "Team 7",
                "SecondParticipant": "Team 8",
                "Date": "Pon 15"
            },
            {
                "FirstParticipant": "Team 1",
                "SecondParticipant": "Team 2",
                "Date": "Pon 12"
            },
            {
                "FirstParticipant": "Team 3",
                "SecondParticipant": "Team 4",
                "Date": "Pon 13"
            },
            {
                "FirstParticipant": "Team 5",
                "SecondParticipant": "Team 6",
                "Date": "Pon 14"
            },
            {
                "FirstParticipant": "Team 7",
                "SecondParticipant": "Team 8",
                "Date": "Pon 15"
            }
        ],
        [
            {
                "FirstParticipant": "Team 1",
                "SecondParticipant": "Team 4",
                "Date": "Pon 17"
            },
            {
                "FirstParticipant": "Team 8",
                "SecondParticipant": "Team 9",
                "Date": "Pon 18"
            },
            {
                "FirstParticipant": "Team 1",
                "SecondParticipant": "Team 4",
                "Date": "Pon 17"
            },
            {
                "FirstParticipant": "Team 8",
                "SecondParticipant": "Team 9",
                "Date": "Pon 18"
            }
        ],
        [
            {
                "FirstParticipant": "Team 1",
                "SecondParticipant": "Team 4",
                "Date": "Pon 17"
            },
            {
                "FirstParticipant": "Team 8",
                "SecondParticipant": "Team 9",
                "Date": "Pon 18"
            }
        ]
    ]
}
const main = document.getElementById('main');
printTournamentBracket(main, matches);
const main2 = document.getElementById('main2');
printTournamentBracket(main2, matches);
