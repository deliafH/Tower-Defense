using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    int dmg;
    public void SetDmg(int dmg)
    {
        this.dmg = dmg;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy e))
            {
                e.Damemage(dmg);
            }
        }
    }
}
