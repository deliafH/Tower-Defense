using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMoving : MonoBehaviour
{
    Vector3 destPos;
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    [SerializeField] Transform spriteTransform;

    private void Start()
    {
        //destPos = GameController.Instance.FirstDest;
    }

    public void SetDest(Vector3 dest)
    {
        this.destPos = dest;



        if (Mathf.Abs(destPos.y - transform.position.y) > Mathf.Abs(destPos.x - transform.position.x))
        {
            animator.SetBool("isForward", true);
            animator.SetFloat("velocity", (destPos.y - transform.position.y));
        }
        else
        {
            animator.SetBool("isForward", false);
            animator.SetFloat("velocity", (destPos.x - transform.position.x));
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destPos, speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        animator.SetFloat("velocity", 0);
    }
}