using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelLogin : BasePanel
{
    public InputField UsernameField;
    public InputField PasswordField;

    public void Login()
    {
        RestHelper.Instance.Login(UsernameField.text, PasswordField.text, LoginResponse);
    }

    public void LoginResponse(RestResponse response)
    {
        if (string.IsNullOrEmpty(response.Error))
        {
            //create user upon login response
            Parent.LoginSuccess(new User(User.NEW_USER_ID));
            Debug.Log(response.Value);
        }
        else
        {
            Parent.LoginSuccess(new User(User.NEW_USER_ID));
            Debug.Log(response.Value);
        }
    }

    override public void Reset()
    {
        UsernameField.text = "";
        PasswordField.text = "";
    }
}
