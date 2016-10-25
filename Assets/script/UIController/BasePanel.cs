using UnityEngine;


abstract public class BasePanel : MonoBehaviour
{
    public GameMode Parent { get; set; }
    abstract public void Reset();
}
