using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerType2 : Tower
{
    [SerializeField] LineRenderer line;
    [SerializeField] float cycle;
    [SerializeField] LayerMask layer;
    float time;
    bool isDmged;
    private void Start()
    {
        time = 0f;
        isDmged = false;
        line.SetPosition(0, this.transform.position);
    }
    protected override void Attack(Transform transform)
    {
        base.Attack(transform);
        time += Time.deltaTime;
        if(time < cycle / 2f)
        {
            line.gameObject.SetActive(true);
            line.SetPosition(1, transform.position);
            if (!isDmged)
            {
                Vector3 start = line.GetPosition(0);
                Vector3 end = line.GetPosition(1);
                Vector3 direction = end - start;
                float distance = direction.magnitude;
                RaycastHit2D hit = Physics2D.Raycast(start, direction.normalized, distance, layer);
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    if (hit.collider.gameObject.TryGetComponent<Enemy>(out Enemy e))
                    {
                        e.Damemage(damage);
                    }
                }
                isDmged = true;
                Debug.DrawLine(start, end, Color.green);
            }
        }
        else if(time < cycle)
        {
            line.gameObject.SetActive(false);
        }
        else
        {
            isDmged = false;
            time -= cycle;
        }

    }

    protected override void StopAttack()
    {
        base.StopAttack();
        line.gameObject.SetActive(false);
    }
}
