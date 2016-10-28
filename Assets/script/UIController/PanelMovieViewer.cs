using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PanelMovieViewer : MonoBehaviour {

    public Text TitleField;

    public Text YearField;
    public Text GenreField;
    public Text DurationField;
    public Text PreviewField;

    public Text CountryField;
    public Text LanguageField;
    public Text RealisatorField;
    public Text ResumeField;

    public Text ActorField;

    public Button ActionButton;

    public Action<Movie> Callback;
    public Movie CurrentMovie;

    public void Init(Movie movie, Action<Movie> callback)
    {
        CurrentMovie = movie;
        Callback = callback;
        Reset();
    }

    public void ActionPressed()
    {
        Utility.Modal.ShowConfirmDialog("Rental Confirmation", "Do you want to rent\n" + CurrentMovie.Title + " ?", ActionConfirm);
    }

    public void ActionConfirm(bool confirm)
    {

        if (confirm && Callback != null) Callback(CurrentMovie);
    }

    public void Reset()
    {
        if (CurrentMovie == null) return;

        TitleField.text = CurrentMovie.Title;

        YearField.text = CurrentMovie.ReleaseDate.ToString("yyyy");
        GenreField.text = CurrentMovie.Genre;
        DurationField.text = CurrentMovie.Duration.ToString();
        PreviewField.text = CurrentMovie.Preview;

        CountryField.text = CurrentMovie.Country;
        LanguageField.text = CurrentMovie.Lang;
        RealisatorField.text = CurrentMovie.Realisator.Name + " " + CurrentMovie.Realisator.LastName;
        ResumeField.text = CurrentMovie.Resume;

        string builder = "";

        foreach(PartTaker actor in CurrentMovie.Actors)
        {
            builder += actor.Name + " " + actor.LastName + " - ";
        }

        ActorField.text = builder;

        if(Callback == null) ActionButton.gameObject.SetActive(false);
        else ActionButton.gameObject.SetActive(false);
    }



}
