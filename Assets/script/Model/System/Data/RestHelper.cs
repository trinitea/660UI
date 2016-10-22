using System;
using UnityEngine; // for WWWform
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RestHelper : MonoBehaviour
{
    const string URL_SERVER = "localhost:8080/entry-point";

    const string URL_CAT_GENRES = "movie_genres";
    const string URL_CAT_LANGS = "movie_langs";
    const string URL_CAT_COUNTRIES = "sys_countries";
    const string URL_CAT_PACKAGES = "user_packages";

    const string URL_LOGIN = "user";
    const string URL_MOVIE_SEARCH = "movie";


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

    public void MovieSearch(string titles, string years, string genres, string actors, string scenarists, string realisator, Action<RestResponse> callback)
    {
        Dictionary<string, string> param = new Dictionary<string, string>() {
            { "title", titles },
            { "years", years },
            { "genres", genres },
            { "actors", actors },
            { "scenarist", scenarists },
            { "realisator", realisator }
        };

        Debug.Log("in MovieSearch");
        StartCoroutine( ExecutePost( URL_SERVER + "/" + URL_MOVIE_SEARCH, param, callback ) );
    }

    /*public void MovieSearch(string titles, string years, string genres, string actors, string scenarists, string realisator, Action<RestResponse> callback)
    {
        Dictionary<string, string> param = new Dictionary<string, string>() {
            { "title", titles },
            { "years", years },
            { "genres", genres },
            { "actors", actors },
            { "scenarist", scenarists },
            { "realisator", realisator }
        };

        StartCoroutine(ExecutePost(URL_MOVIE_SEARCH, param, callback));
    }*/

    // Catalog Load
    public void GetGenres(Action<RestResponse> callback)
    {
        StartCoroutine(ExecuteGet(URL_SERVER + "/" + URL_CAT_GENRES, null, callback));
    }

    public void GetLangs(Action<RestResponse> callback)
    {
        StartCoroutine(ExecuteGet(URL_SERVER + "/" + URL_CAT_LANGS, null, callback));
    }

    public void GetCountries(Action<RestResponse> callback)
    {
        StartCoroutine(ExecuteGet(URL_SERVER + "/" + URL_CAT_COUNTRIES, null, callback));
    }

    public void GetPackages(Action<RestResponse> callback)
    {
        StartCoroutine(ExecuteGet(URL_SERVER + "/" + URL_CAT_PACKAGES, null, callback));
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

        WWWForm form = new WWWForm();

        if (dict != null)
        {
            foreach (KeyValuePair<string, string> pair in dict)
            {
                form.AddField(pair.Key, pair.Value);
            }
        }

        Debug.Log("in ExecutePost");
        WWW post = new WWW(url, form);

        yield return post;

        callback(new RestResponse(post.text, post.error));
    }
}
