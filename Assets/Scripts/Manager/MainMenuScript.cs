using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    void Start()
    {
        UI.UIManager.Instance.CloseAll();
        UI.UIManager.Instance.OpenUI<UI.CanvasHome>();
    }
}
