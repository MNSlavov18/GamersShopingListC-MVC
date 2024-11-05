using GamersShopingListC_MVC.Data;
using GamersShopingListC_MVC.Models;
using GamersShopingListC_MVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

            await dBContext.SaveChangesAsync();

            return RedirectToAction("List", "Games");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var games = await dBContext.Games.ToListAsync();

            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var game = await dBContext.Games.FindAsync(id);

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game viewModel)
        {
            var game = await dBContext.Games.FindAsync(viewModel.Id);

            if (game is not null)
            {
                game.Name = viewModel.Name;
                game.Value = viewModel.Value;

                await dBContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Games");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Game viewModel)
        {
            var game = await dBContext.Games
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (game is not null)
            {
                dBContext.Games.Remove(viewModel);
                await dBContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Games");
        }
    }
}
