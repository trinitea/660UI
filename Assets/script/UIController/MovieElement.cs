using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovieElement : MonoBehaviour
{
    public const int HEIGHT = 80;

    private Movie TheMovie;

    public Text Title;
    public Text GenreContent;
    public Text DurationContent;
    //public Button botton;

    Action<Movie> Callback;

    public void Init(Movie movie, Action<Movie> callback)
    {
        TheMovie = movie;
        Title.text = movie.Title;
        GenreContent.text = movie.Genre;
        DurationContent.text = movie.Title;

        Callback = callback;
    }

    public void Rental()
    {
        Utility.Modal.ShowConfirmDialog("Movie Rental", "Do you want to rent " + Title.text + " ?", ConfirmRental);
    }

    public void ConfirmRental(bool response)
    {
        if(response) Callback(TheMovie);
    }
}
