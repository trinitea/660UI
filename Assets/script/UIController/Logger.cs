using UnityEngine;
using UnityEngine.UI;

public class Logger : BasePanel
{
    //public float StayTime = 1.0f;
    //private float CurentTime = 0.0f;
    
    //public float FadeOutTime = 1.0f;
    //private float CurrentFadeOutTime = 0.0f;

    public Text LoggerText;
    
    public void Message(string message)
    {
        LoggerText.text = message;
    }
    
    override public void Reset()
    {
        Debug.Log("Do something");
    }
}


