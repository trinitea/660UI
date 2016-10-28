using System;
using System.Collections.Generic;
using SimpleJSON;

public class Movie
{
    public int ID { get; private set; }
    public string Title { get; private set; }
    public string Genre { get; private set; }
    public string Lang { get; private set; }
    public string Country { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public int Duration { get; private set; }
    public string Resume { get; private set; }
    public string Preview { get; private set; }
    public PartTaker Realisator { get; private set; }
    public List<PartTaker> Actors { get; private set; }
    public List<PartTaker> Scenarists { get; private set; }

    public static List<Movie> MoviesFromJson(string json)
    {
        List<Movie> movies = new List<Movie>();
        var results = JSON.Parse(json);

        for (int i = 0; i < results.Count; i++)
        {
            List<PartTaker> actors = new List<PartTaker>();
            List<PartTaker> scenarists = new List<PartTaker>();

            int id = -1;
            int duration = 0;

            Int32.TryParse(results[i]["id_film"], out id);
            Int32.TryParse(results[i]["duree"], out duration);
            
            string title = results[i]["titre"];
            string genre = results[i]["genres"];
            string lang = results[i]["langue"];
            string country = results[i]["pays"];
            DateTime releaseDate = Convert.ToDateTime(results[i]["anneeSortie"]);
            string resume = results[i]["bibliographie"];
            string preview = results[i]["lienAnnonce"];

            PartTaker realisator = new PartTaker(
                    results[i]["realisateur"]["prenom"],
                    results[i]["realisateur"]["nom"],
                    Convert.ToDateTime(results[i]["realisateur"]["anniversaire"]),
                    results[i]["realisateur"]["pays"],
                    results[i]["realisateur"]["bibliographie"]
                );

            for (int j = 0; j < results[i]["acteurs"].Count; j++)
            {
                actors.Add(new PartTaker(
                        results[i]["acteurs"][j]["prenom"],
                        results[i]["acteurs"][j]["nom"],
                        Convert.ToDateTime(results[i]["acteurs"][j]["anniversaire"]),
                        results[i]["acteurs"][j]["pays"],
                        results[i]["acteurs"][j]["bibliographie"]
                    ));
            }
            

            // could be remove by using the prior for and a list of Dictionaries
            for (int j = 0; j < results[i]["scenaristes"].Count; j++)
            {
                scenarists.Add(new PartTaker(
                        results[i]["scenaristes"][j]["prenom"],
                        results[i]["scenaristes"][j]["nom"],
                        Convert.ToDateTime(results[i]["scenaristes"][j]["anniversaire"]),
                        results[i]["scenaristes"][j]["pays"],
                        results[i]["scenaristes"][j]["bibliographie"]
                    ));
            }

            movies.Add(new Movie( id, title, genre, lang, country, releaseDate, duration, resume, preview, realisator, actors, scenarists ));
        }

        return movies;
    }

    public Movie(int id, string title, string genre, string lang, string country, DateTime releaseDate, int duration, 
        string resume, string preview, PartTaker realisator, List<PartTaker> actors, List<PartTaker> scenarists)
    {
        ID = id;
        Title = title;
        Genre = genre;
        Lang = lang;
        Country = country;
        ReleaseDate = releaseDate;
        Duration = duration;
        Resume = resume;
        Preview = preview;
        Realisator = realisator;
        Actors = actors;
        Scenarists = scenarists;
    }
}
