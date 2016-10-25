using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PanelMovie : BasePanel
{
    public InputField TitleField;
    public InputField YearField;
    public InputField GenreField;

    public InputField ActorField;
    public InputField ScenaristField;
    public InputField RealisatorField;

    public void Search()
    {
        RestHelper.Instance.MovieSearch(
            TitleField.text,
            YearField.text,
            GenreField.text,
            ActorField.text,
            ScenaristField.text,
            RealisatorField.text,
            ShowSearchResult);
    }

    public void ShowSearchResult(RestResponse response)
    {
        if (response.Error == string.Empty || true)
        {
            List<Movie> movies = new List<Movie>() {
                new Movie(1, "Test Movie 1", "Spooky", new DateTime(), 300, "some resume", 1),
                new Movie(2, "Test Movie 2", "Spooky", new DateTime(), 200, "some resume", 1),
                new Movie(3, "Test Movie 3", "Spooky", new DateTime(), 700, "some resume", 1),
                new Movie(7, "Test Movie 7", "Spooky", new DateTime(), 75, "some resume", 1),
                new Movie(4, "Test Movie 4", "Spooky", new DateTime(), 69, "some resume", 1),
                new Movie(5, "Test Movie 5", "Spooky", new DateTime(), 75, "some resume", 1),
                new Movie(6, "Test Movie 6", "Spooky", new DateTime(), 75, "some resume", 1),
                new Movie(8, "Test Movie 8", "Spooky", new DateTime(), 75, "some resume", 1)
            };

            Utility.Modal.ShowMovieResults(movies, Rental);
        }
        else
        {
            Debug.Log(response.Error);
        }
    }

    public void Rental(Movie movie)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null) audio.Play();
        Utility.Modal.ShowConfirmDialog("New Item Acquired", "Congratulation\nYou got " + movie.Title);
    }

    override public void Reset()
    {
        TitleField.text = "";
        YearField.text = "";
        GenreField.text = "";

        ActorField.text = "";
        ScenaristField.text = "";
        RealisatorField.text = "";
    }
}
