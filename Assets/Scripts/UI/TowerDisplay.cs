using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerDisplay : MonoBehaviour
{
    TowerData tower;
    [SerializeField] Image icon, button;
    private int id;
    [SerializeField]TextMeshProUGUI priceText;
    public void SetUp(TowerData tower)
    {
        this.tower = tower;
        icon.sprite = tower.towerSprite;
        priceText.text = tower.price.ToString();
        this.id = tower.id;
    }
    public void Select()
    {
        if (GameManager.Instance.GetGoldVal() >= tower.price)
        {
            UI.UIManager.Instance.CloseUI<UI.CanvasShop>();
            GameManager.Instance.ChooseTower(tower);
        }
    }
}
