using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpBots : Singleton<WakeUpBots>
{
    bool isStarted;
    int curBotsDied;
    private void Start()
    {
        isStarted = false;
    }
    public void WakeUp()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        curBotsDied = 0;
        isStarted = true;
    }

    public void CheckIsWin()
    {
        curBotsDied += 1;
        if (transform.childCount == curBotsDied)
        {
            UI.UIManager.Instance.CloseAll();
            UI.UIManager.Instance.OpenUI<UI.CanvasWin>();
        }
    }
}
