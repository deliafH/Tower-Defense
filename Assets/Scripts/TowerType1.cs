using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerType1 : Tower
{
    [SerializeField] float cycle;
    [SerializeField] Transform circle;
    [SerializeField] float maxSize;
    private float baseSize;
    private float veloc;
    private float currentSize;


    private void Start()
    {
        baseSize = circle.localScale.x;
        veloc = (maxSize - baseSize) / cycle;
        currentSize = baseSize;
    }
    protected override void Attack(Transform transform)
    {
        base.Attack(transform);
        circle.gameObject.SetActive(true);
        currentSize += Time.deltaTime * veloc;
        while (currentSize > maxSize) currentSize -= maxSize;
        circle.localScale = currentSize * new Vector3(1, 1, 1);


    }

    protected override void StopAttack()
    {
        base.StopAttack();
        circle.gameObject.SetActive(false);
    }
}
