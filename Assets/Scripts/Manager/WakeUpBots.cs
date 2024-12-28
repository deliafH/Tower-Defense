using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WakeUpBots : Singleton<WakeUpBots>
{
    float time;
    int curBotsDied, curBotSpawn;
    [System.Serializable]
    private class EnemySpawnData
    {
        public GameObject enemy;
        public float timeSpawn;
    }
    [SerializeField] EnemySpawnData[] enemies; 
    private void Start()
    {
        time = 0;
        curBotsDied = 0;
        curBotSpawn = 0;
        enemies = enemies.OrderBy(e => e.timeSpawn).ToArray();
    }
    public void WakeUp()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        while(curBotSpawn < enemies.Length && time > enemies[curBotSpawn].timeSpawn)
        {
            enemies[curBotSpawn].enemy.SetActive(true);
            curBotSpawn += 1;
        }
    }
    public void CheckIsWin()
    {
        curBotsDied += 1;
        if (transform.childCount == curBotsDied)
        {
            UI.UIManager.Instance.CloseAll();
            UI.UIManager.Instance.OpenUI<UI.CanvasWin>();
            enabled = false;
        }
    }
}
