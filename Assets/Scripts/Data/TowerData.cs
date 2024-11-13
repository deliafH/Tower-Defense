using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower")]
public class TowerData : ScriptableObject
{
    public int id;
    public string Name, information;
    public GameObject towerType;
    public Sprite towerSprite;
    public int price;
}
