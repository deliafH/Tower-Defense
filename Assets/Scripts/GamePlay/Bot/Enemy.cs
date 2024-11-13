using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] Slider hpSlider;
    int currentHp;

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
            gameObject.SetActive(false);
            WakeUpBots.Instance.CheckIsWin();
        }
    }
}
