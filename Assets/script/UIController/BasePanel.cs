using UnityEngine;


abstract public class BasePanel : MonoBehaviour
{
    public GameMode parent { get; set; }
    abstract public void Reset();
}
