using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDestinationScript : MonoBehaviour
{
    [SerializeField] Transform[] nextDest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(nextDest.Length > 0)
            collision.GetComponent<BotMoving>().SetDest(nextDest[Random.Range(0, nextDest.Length)].position);
    }
}
