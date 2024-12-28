using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] Slider hpSlider;
    [SerializeField] GoldSpawn goldPrebs;
    int currentHp;
    [SerializeField]int goldDrop;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public int getMaxHp()
    {
        return maxHp;
    }
    public void Damemage(int hp)
    {
        currentHp -= hp;
        hpSlider.value = 1f * currentHp / maxHp;
        if (currentHp <= 0)
        {
            OnDied();
            WakeUpBots.Instance.CheckIsWin();
        }
    }

    public void OnDied()
    {
        if(goldDrop > 0)
        {
            GoldSpawn goldIns = Instantiate(goldPrebs, transform.position, Quaternion.identity);
            goldIns.Init(goldDrop);
        }
        gameObject.SetActive(false);

    }
}
