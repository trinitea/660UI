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
        if (
            string.IsNullOrEmpty(TitleField.text) &&
            string.IsNullOrEmpty(YearMinField.text) &&
            string.IsNullOrEmpty(YearMaxField.text) &&
            string.IsNullOrEmpty(GenreField.text) &&
            string.IsNullOrEmpty(LangField.text) &&
            string.IsNullOrEmpty(CountryField.text) &&
            string.IsNullOrEmpty(ActorField.text) &&
            string.IsNullOrEmpty(RealisatorField.text)
            )
        {
            Parent.Logger.Message("Please, fill at least one row");
        }

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
            List<Movie> movies = Movie.MoviesFromJson(response.Value);

            Utility.Modal.ShowMovieResults(movies, MovieDetails);
        }
        else
        {
            Debug.Log(response.Error);
        }
    }

    public void MovieDetails(Movie movie)
    {
        Utility.Modal.ShowMovieDetails(movie, Rental);
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
            Utility.Modal.ShowConfirmDialog("New Item Acquired", response.Value);
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

        Parent.Logger.Message("Use pipe '|' to seperate multiple search criteras\n" +
            "(Use pipe '|' instead of space to seperate first name and last name)");
    }
}
