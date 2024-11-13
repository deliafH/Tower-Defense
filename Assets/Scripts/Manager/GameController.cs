using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] Transform firstDest;
    public Vector3 FirstDest => firstDest.position;
    

    
}
