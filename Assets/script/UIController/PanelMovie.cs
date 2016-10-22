using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelMovie : BasePanel
{
    public InputField TitleField;
    public InputField YearField;
    public InputField GenreField;

    public InputField ActorField;
    public InputField ScenaristField;
    public InputField RealisatorField;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

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
        if (response.Error == string.Empty)
        {
            Debug.Log(response.Value);
        }
        else
        {
            Debug.Log(response.Error);
        }
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
