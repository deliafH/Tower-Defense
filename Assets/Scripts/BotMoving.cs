using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMoving : MonoBehaviour
{
    Vector3 destPos;
    [SerializeField] float speed;

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

       /* if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
        }*/
    }
}
