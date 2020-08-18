
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Models;
using RestSharp;

namespace PizzaStore.Client.HttpClient
{
      public class GetMoviesClient
    {
      public MovieViewModel GetMovies(string searchString)
      {
              var url = "https://movies-tvshows-data-imdb.p.rapidapi.com/?title=" + searchString.Replace(" ", "%20") + "&type=get-movies-by-title";
      var client = new RestClient(url);
      var request = new RestRequest(Method.GET);
      request.AddHeader("x-rapidapi-host", "movies-tvshows-data-imdb.p.rapidapi.com");
      request.AddHeader("x-rapidapi-key", "971bf2ac6fmsh604c84512ded1eap16b86fjsn950b74fe77a7");
      IRestResponse response = client.Execute(request); 

      try
      {
        MovieQByTitleModel mvList = new MovieQByTitleModel();
        mvList = JsonSerializer.Deserialize<MovieQByTitleModel>(response.Content);
        
        //map movie search results here
        var mvListM = new MovieViewModel();
        var mvListR = new List<MovieImdbModel>();
        mvListM.MovieResults = mvListR;

        foreach (var m in mvList.movie_results.ToList())
        {
          mvListM.MovieResults.Add(new MovieImdbModel() {title = m.title, year = m.year, imdb_id = m.imdb_id});
        }
        mvListM.Results = mvList.search_results.ToString();
        return mvListM;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
      return new MovieViewModel();
      }

    }
  }