using UnityEngine;
using System.Collections;
using System.Runtime;
using SimpleJSON;

public class GameMode : MonoBehaviour {

    public User CurrentUser { get; set; }
    private Config SystemConfig;

    public Logger Logger;
    public PanelLogin PanelLogin;
    public PanelUser PanelUser;
    public PanelMovie PanelMovie;

    // Use this for initialization
    void Start () {
        Logger.parent = this;
        PanelLogin.parent = this;
        //PanelUser.parent = this;
        PanelMovie.parent = this;

        //Lang.LoadCatalog(false);
        //Lang.LoadCatalog(false);
        //Lang.LoadCatalog(false);
        //Lang.LoadCatalog(false);
    }

    public User GetCurrentUser()
    {
        return CurrentUser;
    }

    public void LoginSuccess(User newUser)
    {
        CurrentUser = newUser;
        PanelLogin.Reset();
        PanelLogin.gameObject.SetActive(false);
    }

    public void ExitApplication()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
