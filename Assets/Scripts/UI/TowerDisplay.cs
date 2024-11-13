using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerDisplay : MonoBehaviour
{
    [SerializeField] TowerData tower;
    [SerializeField] Image icon, button;
    private int id;
    [SerializeField]TextMeshProUGUI priceText;

    private void Start()
    {
        SetUp(tower);
    }
    public void SetUp(TowerData tower)
    {
        icon.sprite = tower.towerSprite;
        priceText.text = tower.price.ToString();
        this.id = tower.id;
    }
    public void UpdateChosen(int id)
    {
        //button.sprite = this.id == id ? selectedButton : normButton;
    }
    public void Select()
    {
        if (GameManager.Instance.GetGoldVal() > tower.price)
        {
            UI.UIManager.Instance.CloseAll();
            UI.UIManager.Instance.OpenUI<UI.CanvasMainMenu>();
            GameManager.Instance.ChooseTower(tower);
        }
    }
}
