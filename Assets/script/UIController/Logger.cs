using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Logger : BasePanel
{
    public float StayTime = 1.0f;
    private float CurentTime = 0.0f;
    
    public float FadeOutTime = 1.0f;
    private float CurrentFadeOutTime = 0.0f;

    public Text LoggerText;
    

    // every 2 seconds perform the print()
    public void Message(string message)
    {
        LoggerText.text = message;
    }

    private void fadeOutMessage(string message)
    {
        //Text.color.a =  float. Color.Lerp();
    }

    // 
    override public void Reset()
    {
        Debug.Log("Do something");
        //LoggerText.text = "";
    }
}


