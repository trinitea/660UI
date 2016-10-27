using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelMovieViewer : MonoBehaviour {

    public Text TitleField;
    public Text YearField;
    public Text DurationField;
    public Text PreviewField;

    public Text CountryField;
    public Text LanguageField;
    public Text RealisatorField;
    public Text DescriptionField;

    public Text ActorField;

    public Action<Movie> Callback;
    public Movie CurrentMovie;

    public void Reset()
    {

        TitleField.text = "";
        YearField.text = "";
        DurationField.text = "";
        PreviewField.text = "";

        CountryField.text = "";
        LanguageField.text = "";
        RealisatorField.text = "";
        DescriptionField.text = "";

        ActorField.text = "";


}



}
