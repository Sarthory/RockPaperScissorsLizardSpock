using System;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsLizardSpock.Repository;

namespace RockPaperScissorsLizardSpock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameOptions _gameOptions;

        public GameController(IGameOptions gameOptions)
        {
            _gameOptions = gameOptions;
        }

        [HttpPost]
        [Route("Play")]
        public IActionResult Play(GameOption playerOne, GameOption playerTwo)
        {
            try
            {
                if (playerOne.Equals(playerTwo))
                {
                    return Ok(new
                    {
                        status = "success",
                        message = "Empate!"
                    });
                }

                bool playerOneWins;

                switch (playerOne)
                {
                    case GameOption.Rock:
                        {
                            playerOneWins = _gameOptions.GetRockWinningOptions().Contains(playerTwo);
                            break;
                        }

                    case GameOption.Paper:
                        {
                            playerOneWins = _gameOptions.GetPaperWinningOptions().Contains(playerTwo);
                            break;
                        }

                    case GameOption.Scissors:
                        {
                            playerOneWins = _gameOptions.GetScissorsWinningOptions().Contains(playerTwo);
                            break;
                        }

                    case GameOption.Lizard:
                        {
                            playerOneWins = _gameOptions.GetLizardWinningOptions().Contains(playerTwo);
                            break;
                        }

                    case GameOption.Spock:
                        {
                            playerOneWins = _gameOptions.GetSpockWinningOptions().Contains(playerTwo);
                            break;
                        }

                    default:
                        throw new ArgumentOutOfRangeException(nameof(playerOne), playerOne, null);
                }

                return Ok(new
                {
                    status = "success",
                    message = $"O jogador {(playerOneWins ? "1" : "2")} ganhou!"
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

    }
}