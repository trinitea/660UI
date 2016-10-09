using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {

    private User user;
    private Config config;

	// Use this for initialization
	void Start () {

        config = Config.LoadConfig("test.config");
        Debug.Log(config.ToString());
        StartCoroutine(RestHelper.ExecuteCommand());
    }
	
}
