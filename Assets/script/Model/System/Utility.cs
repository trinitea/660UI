using System;
using UnityEngine;
using System.Collections.Generic;

class Utility : MonoBehaviour
{
    static public PanelModal Modal { get; private set; }

    static public void Init(PanelModal panelModal)
    {
        Modal = panelModal;
    }
}

