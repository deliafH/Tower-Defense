using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnenmyToTowerSight : MonoBehaviour
{
    [SerializeField] Tower tower;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tower.AddBotsToSights(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tower.RemoveBotsFromSights(collision.transform);
    }
}
