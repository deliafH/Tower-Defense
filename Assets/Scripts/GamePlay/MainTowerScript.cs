using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerScript : MonoBehaviour
{
    [SerializeField] int maxHp;
    int hp;
    private void Start()
    {
        hp = maxHp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy e))
            {
                hp -= e.getMaxHp();
                EventManager.Instance.TriggerEvent("Dameage", 1f * hp / maxHp);
                if (hp < 0) GameManager.Instance.SetLose();
            }
        }
    }
}
