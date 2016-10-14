using System;
using UnityEngine; // for WWWform
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RestHelper : MonoBehaviour
{
    const string URL_SERVER = "";
    const string URL_LOGIN = "";


    private static RestHelper instance = null;

    public static RestHelper Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (RestHelper)FindObjectOfType(typeof(RestHelper));
                if (instance == null)
                    instance = (new GameObject("RestHelper")).AddComponent<RestHelper>();
            }
            return instance;

        }
    }

    


    // Commands
    public void Test(Action<RestResponse> callback)
    {
        StartCoroutine(ExecuteGet("http://www.perdu.com/", null, callback));
    }

    public void Login(string username, string password, Action<RestResponse> callback)
    {
        Dictionary<string, string> param = new Dictionary<string, string>() { { "username", username }, { "password", password } };
        StartCoroutine( ExecutePost( URL_LOGIN, param, callback ) );
    }

    // Rest Actions
    private IEnumerator ExecuteGet(string url, Dictionary<string, string> dict, Action<RestResponse> callback)
    {
        if (dict != null)
        {

        }

        WWW get = new WWW(url);

        yield return get;

        callback(new RestResponse(get.text, get.error));
    }

    public IEnumerator ExecutePost(string url, Dictionary<string, string> dict, Action<RestResponse> callback)
    {
        WWW post = new WWW("http://www.perdu.com/");

        if (dict != null)
        {
            WWWForm form = new WWWForm();

            foreach (KeyValuePair<string, string> pair in dict)
            {
                form.AddField(pair.Key, pair.Value);
            }
        }
        
        
        yield return post;

        callback(new RestResponse(post.text, post.error));
    }
}
