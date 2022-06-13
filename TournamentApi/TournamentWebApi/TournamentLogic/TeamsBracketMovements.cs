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
        public static Dictionary<int, Movement> MOVEMENTS_FOR_16_TEAMS { get; } = new Dictionary<int, Movement>
            {
                { 1, new Movement(LooserNewMatch: 25, LooserNewPositionInMatch: 0, WinnerNewMatch: 9, WinnerNewPositionInMatch: 0)},
                { 2, new Movement(LooserNewMatch: 25, LooserNewPositionInMatch: 1, WinnerNewMatch: 9, WinnerNewPositionInMatch: 1)},
                { 3, new Movement(LooserNewMatch: 26, LooserNewPositionInMatch: 0, WinnerNewMatch: 10, WinnerNewPositionInMatch: 0)},
                { 4, new Movement(LooserNewMatch: 26, LooserNewPositionInMatch: 1, WinnerNewMatch: 10, WinnerNewPositionInMatch: 1)},
                { 5, new Movement(LooserNewMatch: 27, LooserNewPositionInMatch: 0, WinnerNewMatch: 11, WinnerNewPositionInMatch: 0)},
                { 6, new Movement(LooserNewMatch: 27, LooserNewPositionInMatch: 1, WinnerNewMatch: 11, WinnerNewPositionInMatch: 1)},
                { 7, new Movement(LooserNewMatch: 28, LooserNewPositionInMatch: 0, WinnerNewMatch: 12, WinnerNewPositionInMatch: 0)},
                { 8, new Movement(LooserNewMatch: 28, LooserNewPositionInMatch: 1, WinnerNewMatch: 12, WinnerNewPositionInMatch: 1)},
                { 9, new Movement(LooserNewMatch: 24, LooserNewPositionInMatch: 1, WinnerNewMatch: 13, WinnerNewPositionInMatch: 0)},
                { 10, new Movement(LooserNewMatch: 21, LooserNewPositionInMatch: 0, WinnerNewMatch: 13, WinnerNewPositionInMatch: 1)},
                { 11, new Movement(LooserNewMatch: 22, LooserNewPositionInMatch: 1, WinnerNewMatch: 14, WinnerNewPositionInMatch: 0)},
                { 12, new Movement(LooserNewMatch: 23, LooserNewPositionInMatch: 0, WinnerNewMatch: 14, WinnerNewPositionInMatch: 1)},
                { 13, new Movement(LooserNewMatch: 18, LooserNewPositionInMatch: 1, WinnerNewMatch: 15, WinnerNewPositionInMatch: 0)},
                { 14, new Movement(LooserNewMatch: 17, LooserNewPositionInMatch: 0, WinnerNewMatch: 16, WinnerNewPositionInMatch: 0)},
                { 15, new Movement(LooserNewMatch: 30, LooserNewPositionInMatch: 0, WinnerNewMatch: 29, WinnerNewPositionInMatch: 0)},
                { 16, new Movement(LooserNewMatch: 30, LooserNewPositionInMatch: 1, WinnerNewMatch: 29, WinnerNewPositionInMatch: 1)},
                { 17, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 15, WinnerNewPositionInMatch: 1)},
                { 18, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 16, WinnerNewPositionInMatch: 1)},
                { 19, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 17, WinnerNewPositionInMatch: 1)},
                { 20, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 18, WinnerNewPositionInMatch: 0)},
                { 21, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 19, WinnerNewPositionInMatch: 0)},
                { 22, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 19, WinnerNewPositionInMatch: 1)},
                { 23, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 20, WinnerNewPositionInMatch: 0)},
                { 24, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 20, WinnerNewPositionInMatch: 1)},
                { 25, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 21, WinnerNewPositionInMatch: 1)},
                { 26, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 22, WinnerNewPositionInMatch: 0)},
                { 27, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 23, WinnerNewPositionInMatch: 1)},
                { 28, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: 24, WinnerNewPositionInMatch: 0)},
                { 29, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: null, WinnerNewPositionInMatch: null)},
                { 30, new Movement(LooserNewMatch: null, LooserNewPositionInMatch: null, WinnerNewMatch: null, WinnerNewPositionInMatch: null)},
            };
        public record Movement(int? LooserNewMatch, int? LooserNewPositionInMatch,
                               int? WinnerNewMatch, int? WinnerNewPositionInMatch);
    }
}
