using System.Collections.Generic;

namespace RockPaperScissorsLizardSpock.Repository
{
    public interface IGameOptions
    {
        List<GameOption> GetRockWinningOptions();

        List<GameOption> GetPaperWinningOptions();

        List<GameOption> GetScissorsWinningOptions();

        List<GameOption> GetLizardWinningOptions();

        List<GameOption> GetSpockWinningOptions();
    }
}
