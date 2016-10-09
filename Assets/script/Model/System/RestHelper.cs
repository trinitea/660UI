using System;
using UnityEngine; // for WWWform
using System.Collections;
using System.Linq;
using System.Text;

class RestHelper : MonoBehaviour
{
    private string url { get; set; }

    public void SendCommand()
    {
        StartCoroutine(ExecuteCommand());
        //WWWForm form = new WWWForm();

        
    }

    static public IEnumerator ExecuteCommand(/*int response*/)
    {
        WWW w = new WWW("http://www.perdu.com/");
        Debug.Log("Befopre sending the command");
        yield return w;
        if (string.IsNullOrEmpty(w.error))
        {
            Debug.Log(w.text);
        }
        else
        {
            Debug.Log(w.error);
        }
    }
}
