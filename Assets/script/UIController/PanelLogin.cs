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
            User user = new User(response.Value);

            Parent.LoginSuccess(user);
            Debug.Log(response.Value);
        }
        else
        {
            Debug.Log(response.Error);
            Reset();
        }
    }

    override public void Reset()
    {
        UsernameField.text = "";
        PasswordField.text = "";
    }
}
