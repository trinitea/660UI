using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelLogin : BasePanel
{
    public InputField UsernameField;
    public InputField PasswordField;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Login()
    {
        RestHelper.Instance.Test(something);
    }

    public void something(RestResponse response)
    {
        Debug.Log(response.Value);
        parent.LoginSuccess(new User(-1));
    }

    override public void Reset()
    {
        UsernameField.text = "";
        PasswordField.text = "";
    }
}
