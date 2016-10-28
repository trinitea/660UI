using System;
using UnityEngine;
using UnityEngine.UI;

public class MovieElement : MonoBehaviour
{
    public const int HEIGHT = 80;

    private Movie TheMovie;

    public Text Title;
    public Text GenreContent;
    public Text YearContent;
    public Text DurationContent;

    Action<Movie> Callback;

    public void Init(Movie movie, Action<Movie> callback)
    {
        TheMovie = movie;
        Title.text = movie.Title;
        YearContent.text = movie.ReleaseDate.ToString("yyyy");
        GenreContent.text = movie.Genre;
        DurationContent.text = movie.Duration.ToString();

        Callback = callback;
    }

    public void ActionButton()
    {
        if (Callback != null) Callback(TheMovie);
    }
}
