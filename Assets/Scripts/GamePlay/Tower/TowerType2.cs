using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerType2 : Tower
{
    [SerializeField] LineRenderer line;
    [SerializeField] float cycle;
    [SerializeField] LayerMask layer;
    [SerializeField] GameObject startLight, endLight;
    [SerializeField] ParticleSystem endPar;
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
            startLight.SetActive(true);
            endLight.SetActive(true);
            endPar.gameObject.SetActive(true);
            line.SetPosition(1, transform.position);

            Vector3 start = line.GetPosition(0);
            Vector3 end = line.GetPosition(1);
            Vector3 direction = end - start;
            float distance = direction.magnitude;


            startLight.transform.position = start;
            endLight.transform.position = end;
            endPar.transform.position = end;
            if (direction.magnitude > 0)
            {
                // Calculate angle in degrees
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg * -1;

                // Apply the rotation to endPar
                endPar.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
            if (!isDmged)
            {
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
            startLight.SetActive(false);
            endLight.SetActive(false);
            endPar.gameObject.SetActive(false);
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
        startLight.SetActive(false);
        endLight.SetActive(false);
        endPar.gameObject.SetActive(false);
    }
}
