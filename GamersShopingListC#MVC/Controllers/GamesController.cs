using GamersShopingListC_MVC.Data;
using GamersShopingListC_MVC.Models;
using GamersShopingListC_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GamersShopingListC_MVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDBContext dBContext;

        public GamesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(AddGameViewModel viewModel)
        {
            var game = new Game
            {
                Name = viewModel.Name,
                Value = viewModel.Value
            };

            await dBContext.Games.AddAsync(game);

            await  dBContext.SaveChangesAsync();

            return View();
        }
    }
}
