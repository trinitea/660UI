using UnityEngine;
using System.Collections;
using System.Runtime;
using SimpleJSON;

public class GameMode : MonoBehaviour {

    private User user;
    private Config config;

    public Logger Logger;
    public PanelLogin PanelLogin;
    public PanelUser PanelUser;
    public PanelMovie PanelMovie;

    // Use this for initialization
    void Start () {
        Logger.parent = this;
        PanelLogin.parent = this;
        //PanelUser.parent = this;
        //PanelMovie.parent = this;
    }

    public void LoginSuccess(User newUser)
    {
        user = newUser;
        PanelLogin.Reset();
        PanelLogin.gameObject.SetActive(false);
    }

    public void ExitApplication()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
