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
          return View(return_view, new PizzaStore.Client.Models.MovieViewModel());
        case 2:          // display Store Sales History
          return View(return_view);
        case 3:          // display Store Order History
          return View(return_view);
        case 4:          // display Search Movies by Title
          // return_view = "SearchByTitle";
          return View(return_view);
        default:
          return View(return_view);
      };

    }

    [HttpPost]
    public IActionResult Post(PizzaStore.Client.Models.MovieViewModel movieViewModel, int id)
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
        return View(return_view, movies.GetMovies(searchString));
      }
      else
      {
        return View(return_view, movieViewModel);
      }
      
    }
    // public MovieViewModel GetMoviesByTitle(string searchString)
    // {
    //   var url = "https://movies-tvshows-data-imdb.p.rapidapi.com/?title=" + searchString.Replace(" ", "%20") + "&type=get-movies-by-title";
    //   var client = new RestClient(url);
    //   var request = new RestRequest(Method.GET);
    //   request.AddHeader("x-rapidapi-host", "movies-tvshows-data-imdb.p.rapidapi.com");
    //   request.AddHeader("x-rapidapi-key", "971bf2ac6fmsh604c84512ded1eap16b86fjsn950b74fe77a7");
    //   IRestResponse response = client.Execute(request); 

    //   try
    //   {
    //     MovieQByTitleModel mvList = new MovieQByTitleModel();
    //     mvList = JsonSerializer.Deserialize<MovieQByTitleModel>(response.Content);
        
    //     //map movie search results here
    //     var mvListM = new MovieViewModel();
    //     var mvListR = new List<MovieImdbModel>();
    //     mvListM.MovieResults = mvListR;

    //     foreach (var m in mvList.movie_results.ToList())
    //     {
    //       mvListM.MovieResults.Add(new MovieImdbModel() {title = m.title, year = m.year, imdb_id = m.imdb_id});
    //     }
    //     mvListM.Results = mvList.search_results.ToString();
    //     return mvListM;
    //   }
    //   catch (Exception e)
    //   {
    //     Console.WriteLine(e);
    //   }
    //   return new MovieViewModel();
    }
  }

