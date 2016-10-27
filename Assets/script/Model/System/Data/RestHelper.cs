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

    const string URL_LOGIN = "login";
    const string URL_USER = "user";
    const string URL_RENTAL = "location";
    const string URL_MOVIE_SEARCH = "movies";


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
    public string Test()
    {
        return "{roger:young,bob:{{bobby:1},{bobby:2}}";
    }

    public void Login(string username, string password, Action<RestResponse> callback)
    {
        Dictionary<string, string> param = new Dictionary<string, string>() { { "courriel", username }, { "motDePasse", password } };
        Debug.Log(username + "<>" + password);
        StartCoroutine( ExecutePost( URL_SERVER + "/" + URL_LOGIN, param, callback ) );
    }

    public void MovieSearch(string titles, string years, string genres, string actors, string scenarists, string realisator, Action<RestResponse> callback)
    {
        Dictionary<string, string> param = new Dictionary<string, string>() {
            { "titres", titles },
            { "annees", years },
            { "genres", genres },
            { "acteurs", actors },
            { "scenaristes", scenarists },
            { "realisateur", realisator }
        };
        
        StartCoroutine( ExecutePost( URL_SERVER + "/" + URL_MOVIE_SEARCH, param, callback ) );
    }


    public void UserCommit(User user, Action<RestResponse> callback)
    {
        Dictionary<string, string> param = new Dictionary<string, string>() {
            { "nom", user.LastName },
            { "prenom", user.Name },
            { "telephone", user.Telephone },

            { "carte_numero", user.Card.Number.ToString() },
            { "carte_type", user.Card.Type },
            { "carte_expiration", user.Card.ExpirationDate.ToString("MM/yy") },
            { "carte_ccv", user.Card.CCV.ToString() },

            { "adresse_numeroCivic", user.ShippingAddress.CivicNumber },
            { "adresse_rue", user.ShippingAddress.Street },
            { "adresse_ville", user.ShippingAddress.Town },
            { "adresse_province", user.ShippingAddress.Province },
            { "adresse_codePostal", user.ShippingAddress.PostalCode }
        };

        if (user.ID == User.NEW_USER_ID)
        {
            param.Add("courriel", user.Email);
            param.Add("motDePasse", user.Password);
            param.Add("anniversaire", user.Birthday.ToString("yyyy/MM/dd"));
        }
        else
        {
            param.Add("id_client", user.ID.ToString());
        }

        StartCoroutine(ExecutePost(URL_SERVER + "/" + URL_USER, param, callback));
    }

    public void RentalMovie(User user, Movie movie, Action<RestResponse> callback)
    {
        Dictionary<string, string> param = new Dictionary<string, string>() {
            { "id_client", user.ID.ToString() },
            { "id_film", movie.ID.ToString() }
        };

        StartCoroutine(ExecutePost(URL_SERVER + "/" + URL_RENTAL, param, callback));
    }

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

        //Debug.Log("in ExecutePost");
        WWW post = new WWW(url, form);

        yield return post;

        callback(new RestResponse(post.text, post.error));
    }
}
