using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using SimpleJSON;

public class PanelMovie : BasePanel
{
    public AudioClip SuccessClip;
    public AudioClip FailureClip;

    public InputField TitleField;
    public InputField YearMinField;
    public InputField YearMaxField;
    public InputField GenreField;
    public InputField LangField;
    public InputField CountryField;

    public InputField ActorField;
    public InputField RealisatorField;

    public void Search()
    {
        RestHelper.Instance.MovieSearch(
            TitleField.text,
            YearMinField.text,
            YearMaxField.text,
            GenreField.text,
            LangField.text,
            CountryField.text,
            ActorField.text,
            RealisatorField.text,
            ShowSearchResult);
    }

    public void ShowSearchResult(RestResponse response)
    {
        if (string.IsNullOrEmpty(response.Error))
        {
            var results = JSON.Parse(response.Value);
            List<Movie> movies = new List<Movie>();
            
            for(int i = 0; i < results.Count; i++)
            {
                int id = -1;
                int duree = 0;
                Int32.TryParse(results[i]["id_film"], out id);
                Int32.TryParse(results[i]["duree"], out duree);
                movies.Add(new Movie(id, results[i]["titre"], results[i]["duree"], new DateTime(), duree, "", -1 ));
            }
            
            /*
            List<Movie> movies = new List<Movie>() {
                new Movie(1, "Test Movie 1", "Spooky", new DateTime(), 300, "some resume", 1),
                new Movie(2, "Test Movie 2", "Spooky", new DateTime(), 200, "some resume", 1),
                new Movie(3, "Test Movie 3", "Spooky", new DateTime(), 700, "some resume", 1),
                new Movie(7, "Test Movie 7", "Spooky", new DateTime(), 75, "some resume", 1),
                new Movie(4, "Test Movie 4", "Spooky", new DateTime(), 69, "some resume", 1),
                new Movie(5, "Test Movie 5", "Spooky", new DateTime(), 75, "some resume", 1),
                new Movie(6, "Test Movie 6", "Spooky", new DateTime(), 75, "some resume", 1),
                new Movie(8, "Test Movie 8", "Spooky", new DateTime(), 75, "some resume", 1)
            };*/

            Utility.Modal.ShowMovieResults(movies, Rental);
        }
        else
        {
            Debug.Log(response.Error);
        }
    }

    public void Rental(Movie movie)
    {
        RestHelper.Instance.RentalMovie(Parent.CurrentUser, movie, RentalConfirm);
    }

    public void RentalConfirm(RestResponse response)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (string.IsNullOrEmpty(response.Error))
        {
            if (audio != null) audio.PlayOneShot(SuccessClip);
            Utility.Modal.ShowConfirmDialog("New Item Acquired", "Congratulation\nYou got " + response.Value);
        }
        else
        {
            if (audio != null) audio.PlayOneShot(FailureClip);
            Utility.Modal.ShowConfirmDialog("Movie Rental Failure", response.Error);

        }
    }

    override public void Reset()
    {
        TitleField.text = "";
        YearMinField.text = "";
        YearMaxField.text = "";
        GenreField.text = "";
        LangField.text = "";
        CountryField.text = "";
        ActorField.text = "";
        RealisatorField.text = "";
    }
}
