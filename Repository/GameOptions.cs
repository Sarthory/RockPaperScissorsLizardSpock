using System.Collections.Generic;

namespace RockPaperScissorsLizardSpock.Repository
{
    public class GameOptions : IGameOptions
    {
        #region Lizard

        public List<GameOption> GetLizardWinningOptions()
        {
            return new List<GameOption>
            {
                GameOption.Spock,
                GameOption.Paper
            };
        }

        #endregion

        #region Paper

        public List<GameOption> GetPaperWinningOptions()
        {
            return new List<GameOption>
            {
                GameOption.Rock,
                GameOption.Spock
            };
        }

        #endregion

        #region Rock

        public List<GameOption> GetRockWinningOptions()
        {
            return new List<GameOption>
            {
                GameOption.Lizard,
                GameOption.Scissors
            };
        }

        #endregion

        #region Scissors

        public List<GameOption> GetScissorsWinningOptions()
        {
            return new List<GameOption>
            {
                GameOption.Lizard,
                GameOption.Paper
            };
        }

        #endregion

        #region Spock

        public List<GameOption> GetSpockWinningOptions()
        {
            return new List<GameOption>
            {
                GameOption.Rock,
                GameOption.Scissors
            };
        }

        #endregion
    }
}
