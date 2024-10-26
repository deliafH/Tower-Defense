using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMoving : MonoBehaviour
{
    Vector3 destPos;
    [SerializeField] float speed;
    [SerializeField] Animator animator;

    private void Start()
    {
        destPos = GameController.Instance.FirstDest;
    }

    public void SetDest(Vector3 dest)
    {
        this.destPos = dest;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destPos, speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, destPos);

        if (Mathf.Abs(destPos.y - transform.position.y) > Mathf.Abs(destPos.x - transform.position.x))
        {
            if (destPos.y < transform.position.y)
            {
                animator.SetBool("isForward", true);
                transform.rotation = Quaternion.Euler(180, 0, 0);
            }
            else
            {
                animator.SetBool("isForward", true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (destPos.x > transform.position.x)
            {
                animator.SetBool("isForward", false);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                animator.SetBool("isForward", false);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}