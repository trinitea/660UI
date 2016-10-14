using UnityEngine;


public abstract class BasePanel : MonoBehaviour
{
    public GameMode parent { get; set; }
    abstract public void Reset();
}
