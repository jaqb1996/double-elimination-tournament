using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentWebApi.TournamentLogic
{
    public class TeamsBracketMovements
    {
        public static Dictionary<int, Movement> MOVEMENTS_FOR_8_TEAMS { get; } = new Dictionary<int, Movement>
            {
                { 1, new Movement(LooserNewMatch: 11, LooserNewPositionInMatch: 0, WinnerNewMatch: 5, WinnerNewPositionInMatch: 0)},
                { 2, new Movement(LooserNewMatch: 11, LooserNewPositionInMatch: 1, WinnerNewMatch: 5, WinnerNewPositionInMatch: 1)},
                { 3, new Movement(LooserNewMatch: 12, LooserNewPositionInMatch: 0, WinnerNewMatch: 6, WinnerNewPositionInMatch: 0)},
                { 4, new Movement(LooserNewMatch: 12, LooserNewPositionInMatch: 1, WinnerNewMatch: 6, WinnerNewPositionInMatch: 1)},
                { 5, new Movement(LooserNewMatch: 9, LooserNewPositionInMatch: 0, WinnerNewMatch: 7, WinnerNewPositionInMatch: 0)},
                { 6, new Movement(LooserNewMatch: 10, LooserNewPositionInMatch: 0, WinnerNewMatch: 8, WinnerNewPositionInMatch: 0)},
                { 7, new Movement(LooserNewMatch: 14, LooserNewPositionInMatch: 0, WinnerNewMatch: 13, WinnerNewPositionInMatch: 0)},
                { 8, new Movement(LooserNewMatch: 14, LooserNewPositionInMatch: 1, WinnerNewMatch: 13, WinnerNewPositionInMatch: 1)},
                { 9, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 7, WinnerNewPositionInMatch: 1)},
                { 10, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 8, WinnerNewPositionInMatch: 1)},
                { 11, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 9, WinnerNewPositionInMatch: 1)},
                { 12, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 10, WinnerNewPositionInMatch: 1)},
                { 13, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: null, WinnerNewPositionInMatch: null)},
                { 14, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: null, WinnerNewPositionInMatch: null)},
            };
        public record Movement(int? LooserNewMatch, int? LooserNewPositionInMatch,
                               int? WinnerNewMatch, int? WinnerNewPositionInMatch);
    }
}
