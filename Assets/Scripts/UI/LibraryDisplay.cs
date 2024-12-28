using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryDisplay : MonoBehaviour
{
    [SerializeField] Text nameText, desText, priceText;
    [SerializeField] Image icon, unKnownIcon;
    public void SetUp(TowerData tower)
    {
        if (tower.isUnlock)
        {
            icon.sprite = tower.towerSprite;
            icon.color = Color.white;
            unKnownIcon.gameObject.SetActive(false);
            nameText.text = tower.Name;
            desText.text = tower.information;
            priceText.text = "Price: " + tower.price;
        }
        else
        {
            icon.sprite = tower.towerSprite;
            icon.color = Color.black;
            unKnownIcon.gameObject.SetActive(true);
            nameText.text = "???";
            desText.text = "Unlock on Level " + (tower.unlockLevel + 1);
            priceText.text = "";
        }
    }
}
