using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PanelModal : MonoBehaviour
{
    // Address
    public PanelAddress PanAddress;

    // Confirm / Message Dialog
    public GameObject PanConfirm;
    public Button BtnConfirm;
    public Button BtnCancel;
    public Text PanTitle;
    public Text PanMessage;

    private Action<bool> Callback;

    // Movies
    public GameObject PanMovies;
    public GameObject PanMovieContent;
    public GameObject MovieTemplate;
    public List<GameObject> MovieElements;

    // Movie Viewer
    public PanelMovieViewer PanMovieViewer;

    void Start()
    {
        PanAddress.Parent = this;
    }

    #region Address

    public void ShowAddressDialog(Address address, Action<Address> callback)
    {
        gameObject.SetActive(true);
        PanAddress.gameObject.SetActive(true);
        PanAddress.SetAddress(address, callback);
    }

    public void CloseAddress()
    {
        PanAddress.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    #endregion

    #region Movies
    // Moview

    public void CloseMovieSelection()
    {
        foreach(GameObject obj in MovieElements) Destroy(obj);
        PanMovies.SetActive(false);
        gameObject.SetActive(false);
    }

    public void ShowMovieResults(List<Movie> movies, Action<Movie> callback)
    {
        gameObject.SetActive(true);
        PanMovies.gameObject.SetActive(true);

        int index = 0;
        GameObject element;
        MovieElement movieComponent;
        foreach (Movie movie in movies)
        {
            element = Instantiate(MovieTemplate);
            movieComponent = element.GetComponent<MovieElement>();
            movieComponent.Init(movie, callback);
            element.transform.SetParent(PanMovieContent.transform, false);

            element.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(index + 0.5f) * MovieElement.HEIGHT);
            index++;
        }
    }

    public void ShowMovieDetails(Movie movies, Action<Movie> callback)
    {
        gameObject.SetActive(true);
        PanMovieViewer.gameObject.SetActive(true);

        int index = 0;
        GameObject element;
        MovieElement movieComponent;
        /*
        foreach (Movie movie in movies)
        {
            element = Instantiate(MovieTemplate);
            movieComponent = element.GetComponent<MovieElement>();
            movieComponent.Init(movie, callback);
            element.transform.SetParent(PanMovieContent.transform, false);

            element.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(index + 0.5f) * MovieElement.HEIGHT);
            index++;
        }*/
    }

    #endregion

    #region Confirm / Message

    public void CloseConfirm()
    {
        PanConfirm.SetActive(false);
        if (!PanMovies.activeSelf) gameObject.SetActive(false);
    }

    public void ShowConfirmDialog(string title, string message, Action<bool> callback = null)
    {
        Callback = callback;

        if (callback == null) BtnCancel.gameObject.SetActive(false);
        else BtnCancel.gameObject.SetActive(true);

        gameObject.SetActive(true);
        PanConfirm.gameObject.SetActive(true);

        PanTitle.text = title;
        PanMessage.text = message;

    }

    public void ReceiveConfirm(bool response)
    {
        CloseConfirm();
        if (Callback != null)
        {
            Callback(response);
            Callback = null;
        }
    }
    #endregion
}
