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
            Parent.LoginSuccess(new User(response.Value));
            Parent.Logger.Message("Welcome " + Parent.CurrentUser.Name + " " + Parent.CurrentUser.LastName);
        }
        else
        {
            Parent.Logger.Message(response.Error + "\n" + response.Value);
            Reset();
        }
    }

    override public void Reset()
    {
        UsernameField.text = "";
        PasswordField.text = "";
    }
}
