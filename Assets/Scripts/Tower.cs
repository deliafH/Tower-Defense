using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower: MonoBehaviour
{
    protected List<Transform> bots;
    [SerializeField]protected int damage;
    [SerializeField] BulletCollider bullet;
    private void Awake()
    {
        bots = new List<Transform>();
        bullet.SetDmg(damage);
    }
    public void AddBotsToSights(Transform transform)
    {
        bots.Add(transform);
    }

    public void RemoveBotsFromSights(Transform transform)
    {
        bots.Remove(transform);
    }
    private void Update()
    {
        if (bots.Count > 0) Attack(bots[0]);
        else StopAttack();
    }
    protected virtual void Attack(Transform bot) { }
    protected virtual void StopAttack() { }

}
