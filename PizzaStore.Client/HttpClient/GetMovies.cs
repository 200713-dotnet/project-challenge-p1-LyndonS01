
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Models;
using RestSharp;

namespace PizzaStore.Client.HttpClient
{
    public class GetMoviesClient
    {
      public string ImdbHost { get; set; }
      public string ImdbKey { get; set; }
      public string UtellyHost { get; set; }
      public string UtellyKey { get; set; }
      public MovieViewIntModel GetMoviesImdb(string endpoint, string searchString)
      {
        var endptType = "";
        var url = ImdbHost;
        url += "/?title=" + searchString.Replace(" ", "%20");

        switch(endpoint)
        {
          case "by_title":
            endptType = "&type=get-movies-by-title";
            break;
          default:
            break;  
        }

        url = "https://" + url;
        url += endptType;
        var client = new RestClient(url);
        var request = new RestRequest(Method.GET);
        request.AddHeader("x-rapidapi-host", ImdbHost);
        request.AddHeader("x-rapidapi-key", ImdbKey);
        IRestResponse response = client.Execute(request); 

        try
        {
          var options = new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          };
          
          MovieQByTitleIntModel mvList = new MovieQByTitleIntModel();
          mvList = JsonSerializer.Deserialize<MovieQByTitleIntModel>(response.Content, options);
         
          //map movie search results here
          var mvListM = new MovieViewIntModel();
          var mvListRint = new List<MovieImdbIntModel>();
          mvListM.MovieResults = mvListRint;

          foreach (var m in mvList.Movie_Results.ToList())
          {
            mvListM.MovieResults.Add(new MovieImdbIntModel() {Title = m.Title, Year = m.Year, Imdb_id = m.Imdb_id});
          }  
          mvListM.Results = mvList.Search_Results.ToString();
          return mvListM;
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          return new MovieViewIntModel();
        }
        
      }

      public MovieViewModel GetMoviesImdb(string endpoint)
      {
        var endptType = "";
        var url = ImdbHost;
        var page = "1";
        Int32.TryParse(page, out int pagestring);

        switch(endpoint)
        {
          case "popular":
            var year = DateTime.Today.Year;
            endptType = "/?type=get-popular-movies" + "&page=" + page + "&year=" + year; 
            break;
          case "trending":
            endptType = "/?type=get-trending-movies" + "&page=" + pagestring;
            break;  
          case "recently_added":
            endptType = "/?type=get-recently-added-movies" + "&page=" + pagestring;
            break;  
          default:
            break;  
        }

        url = "https://" + url;
        url += endptType;
        var client = new RestClient(url);
        var request = new RestRequest(Method.GET);
        request.AddHeader("x-rapidapi-host", ImdbHost);
        request.AddHeader("x-rapidapi-key", ImdbKey);
        IRestResponse response = client.Execute(request); 

        try
        {
          var options = new JsonSerializerOptions
          {
              PropertyNameCaseInsensitive = true,
          };
          
          MovieQByTitleModel mvList = new MovieQByTitleModel();
          mvList = JsonSerializer.Deserialize<MovieQByTitleModel>(response.Content, options);
         
          //map movie search results here
          var mvListM = new MovieViewModel();
          var mvListRint = new List<MovieImdbModel>();
          mvListM.MovieResults = mvListRint;

          foreach (var m in mvList.Movie_Results.ToList())
          {
            mvListM.MovieResults.Add(new MovieImdbModel() {Title = m.Title, Year = m.Year, Imdb_id = m.Imdb_id});
          }  
          mvListM.Results = mvList.Search_Results.ToString();
          return mvListM;
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          return new MovieViewModel();
        }
        
      }
      // public MovieViewModel GetMoviesUtelly(string endpoint)
      // {
      //   var url = "";
      //   var host = "";
      //   var key = "";
      //   var endptType = "";
      //   var page = "1";
      //   Int32.TryParse(page, out int pagestring);

      //   switch(api)
      //   {
      //     case "imdb":
      //       host = ImdbHost;
      //       url = host;

      //       if (searchString != null)
      //       {
      //         url += "/?title=" + searchString.Replace(" ", "%20");
      //       }

      //       key = ImdbKey;

      //       switch(endpoint)
      //       {
      //         case "by_title":
      //           endptType = "&type=get-movies-by-title";
      //           break;
      //         case "popular":
      //           var year = DateTime.Today.Year;
      //           endptType = "/?type=get-popular-movies" + "&page=" + page + "&year=" + year; 
      //           break;
      //         case "trending":
      //           endptType = "/?type=get-trending-movies" + "&page=" + pagestring;
      //           break;  
      //         case "recently_added":
      //           endptType = "/?type=get-recently-added-movies" + "&page=" + pagestring;
      //           break;                
      //         default:
      //           break;  
      //       }
      //       break;
      //     case "utelly":
      //       host = UtellyHost;
      //       url = host + "/?title=" + searchString.Replace(" ", "%20");
      //       key = UtellyKey;

      //       switch(endpoint)
      //       {
      //         case "idlookup":
      //           endptType = "idlookup?";
      //           break;
      //         default:
      //           break;  
      //       }
      //       break;
      //     default:
      //       break;
      //   }

      //   url = "https://" + url;
      //   url += endptType;
      //   var client = new RestClient(url);
      //   var request = new RestRequest(Method.GET);
      //   request.AddHeader("x-rapidapi-host", host);
      //   request.AddHeader("x-rapidapi-key", key);
      //   IRestResponse response = client.Execute(request); 

      //   try
      //   {
      //     var options = new JsonSerializerOptions
      //     {
      //         PropertyNameCaseInsensitive = true,
      //     };
          
      //     if (searchString != null)   // Imdb API, Search by Title
      //       {
      //         MovieQByTitleIntModel mvList = new MovieQByTitleIntModel();
      //         mvList = JsonSerializer.Deserialize<MovieQByTitleIntModel>(response.Content, options);
      //       }
      //       else
      //       {
      //         MovieQByTitleModel mvList = new MovieQByTitleModel();
      //         mvList = JsonSerializer.Deserialize<MovieQByTitleModel>(response.Content, options);
      //       }          
          
      //     //map movie search results here
      //     var mvListM = new MovieViewModel();

      //     if (searchString != null)   // Imdb API, Search by Title
      //       {
      //         var mvListRint = new List<MovieImdbIntModel>();
      //         mvListM.MovieResults = mvListRint;
      //       }
      //       else
      //       {
      //         var mvListR = new List<MovieImdbModel>();
      //         mvListM.MovieResults = mvListRint;
      //       }
          
          

      //     foreach (var m in mvList.Movie_Results.ToList())
      //     {
      //       if (searchString != null)   // Imdb API, Search by Title
      //       {
      //         Int32.TryParse(m.Year, out int year2);
      //         mvListM.MovieResults.Add(new MovieImdbIntModel() {Title = m.Title, Year = year2, Imdb_id = m.Imdb_id});
      //       }
      //       mvListM.MovieResults.Add(new MovieImdbModel() {Title = m.Title, Year = m.Year, Imdb_id = m.Imdb_id});
      //     }
      //     mvListM.Results = mvList.Search_Results.ToString();
      //     return mvListM;
      //   }
      //   catch (Exception e)
      //   {
      //     Console.WriteLine(e);
      //     return new MovieViewModel();
      //   }
        
      // }
      public GetMoviesClient()
      {
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true,true).Build();

        ImdbHost = configuration["ApiParams:ImdbHost"];
        ImdbKey = configuration["ApiParams:ImdbKey"];
        UtellyHost = configuration["ApiParams:UtellyHost"];
        UtellyKey = configuration["ApiParams:UtellyKey"];
      }

    }
}