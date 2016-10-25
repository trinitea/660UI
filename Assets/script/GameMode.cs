using UnityEngine;
using System.Collections;
using System.Runtime;
using SimpleJSON;

public class GameMode : MonoBehaviour {

    public User CurrentUser { get; set; }
    private Config SystemConfig;

    public Logger Logger;
    public PanelLogin PanLogin;
    public PanelUser PanUser;
    public PanelMovie PanMovie;

    public GameObject PanMain;
    public PanelModal PanModal;

    // Use this for initialization
    void Start () {
        Logger.Parent = this;
        PanLogin.Parent = this;
        PanUser.Parent = this;
        PanMovie.Parent = this;

        Utility.Init(PanModal);

        //Lang.LoadCatalog(false);
        //Package.LoadCatalog(false);
        //Country.LoadCatalog(false);
        //Genre.LoadCatalog(false);
    }

    public void Navigate(int page)
    {
        switch(page)
        {
            case 0:
                PanLogin.gameObject.SetActive(false);
                PanUser.gameObject.SetActive(true);
                PanMovie.gameObject.SetActive(false);
                PanMain.gameObject.SetActive(false);

                PanUser.Reset();
                break;

            case 1:
                PanUser.gameObject.SetActive(false);
                PanMovie.gameObject.SetActive(true);
                PanMain.SetActive(false);

                PanMovie.Reset();
                break;

            case 2:
                Utility.Modal.ShowConfirmDialog("Test","Another Test", null);
                break;

            default:
                PanUser.gameObject.SetActive(false);
                PanMovie.gameObject.SetActive(false);
                PanMain.SetActive(true);
                break;
        }
    }

    public void GoBack()
    {
        PanUser.gameObject.SetActive(false);
        PanMovie.gameObject.SetActive(false);

        if (CurrentUser == null) PanLogin.gameObject.SetActive(true);
        else PanMain.gameObject.SetActive(true);
    }

    public User GetCurrentUser()
    {
        return CurrentUser;
    }

    public void LoginSuccess(User newUser)
    {
        CurrentUser = newUser;
        PanLogin.Reset();
        PanLogin.gameObject.SetActive(false);
        PanMain.gameObject.SetActive(true);
    }

    public void ExitApplication()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
