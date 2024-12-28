using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerList")]
class TowerListData:ScriptableObject
{
    [SerializeField] List<TowerData> towerDatas;
    public List<TowerData> TowerDatas => towerDatas;
}