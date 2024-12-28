using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class GoldSpawn: MonoBehaviour
{
    int val;
    public void Init(int val)
    {
        this.val = val;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.GainCoin(val);
            gameObject.SetActive(false);
        }
    }
}
