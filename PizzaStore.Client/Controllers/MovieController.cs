using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using PizzaStore.Client.HttpClient;
using RestSharp;

namespace PizzaStore.Client.Controllers
{
  [Route("/movie/{id=1}")]
  // [Route("/store/")]
  // [EnableCors("private")]  
  public class MovieController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public MovieController(PizzaStoreDbContext dbContext) // constructor dependency injection
    {
      _db = dbContext;
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
      var return_view = "index";

      switch (id)
      {
        case 1:           // display Search Movies by Title page 
          return_view = "ByTitle";
          return View(return_view, new MovieViewModel());
        case 2:          
          return View(return_view);
        case 3:          
          return View(return_view);
        case 4:          
          return View(return_view);
        default:
          return View(return_view);
      };

    }

    [HttpPost]
    public IActionResult Post(MovieViewIntModel movieViewModel, int id)
    {
      var return_view = "index";

      switch (id)
      {
        case 1:           // display Search Movie by Title results
          return_view = "ByTitle";
          break;
        case 2:
          break;
        default:
          break;
      }

      if (ModelState.IsValid) //  what is the validation? (add to viewmodel)
      {
        return_view = "MovieSearchResults";
        var searchString = movieViewModel.Title;
        // return View(return_view, GetMoviesByTitle(searchString));
        var movies = new GetMoviesClient();
        return View(return_view, movies.GetMoviesImdb("by_title", searchString));
        // return View(return_view, movies.GetMovies("imdb", "popular", null));
        // return View(return_view, movies.GetMovies("imdb", "trending", null));
        // return View(return_view, movies.GetMovies("imdb", "recently_added", null));
      }
      else
      {
        return View(return_view, movieViewModel);
      }

    }
  }
}

