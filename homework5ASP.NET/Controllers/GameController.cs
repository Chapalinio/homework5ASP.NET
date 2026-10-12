using homework5ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace homework5ASP.NET.Controllers;

public class GameController : Controller
{
    static List<Game> games = new List<Game>();
 
    public IActionResult Index()
    {
        return View(games);
    }

    public IActionResult Details(int? id)
    {
        foreach(var game in games)
        {
            if(game.Id == id)
            {
                return View(game);
            }
        }
        return View("GameNotFoundError");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Game game)
    {
        game.Id = FindMaxId() + 1;

        games.Add(game);
        return Redirect("/Game/Index");
    }

    public IActionResult Delete(int? id)
    {
        foreach (var game in games)
        {
            if (game.Id == id)
            {
                games.Remove(game);
                return View("GameDeleted");
            }
        }

        return View("GameNotFoundError");
    }

    public IActionResult Completed()
    {
        List<Game> completedGames = new List<Game>(games);

        foreach(var game in games)
        {
            if(game.IsCompleted == false)
            {
                completedGames.Remove(game);
            }
        }

        return View(completedGames);
    }

    private int FindMaxId()
    {
        int newId = 0;
        
        foreach(var game in games)
        {
            if(game.Id > newId)
            {
                newId = game.Id;
            }
        }

        return newId;
    }
}
