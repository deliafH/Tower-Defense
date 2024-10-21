using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerType2 : Tower
{
    [SerializeField] LineRenderer line;

    private void Start()
    {
        line.SetPosition(0, this.transform.position);
    }
    protected override void Attack(Transform transform)
    {
        base.Attack(transform);
        line.gameObject.SetActive(true);
        line.SetPosition(1, transform.position);

    }

    protected override void StopAttack()
    {
        base.StopAttack();
        line.gameObject.SetActive(false);
    }
}
