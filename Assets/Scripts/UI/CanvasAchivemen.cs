using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



namespace UI
{
    public class DisplayData
    {
        public string name;
        public Sprite towerSprite;

        public DisplayData(Sprite towerSprite, string name)
        {
            this.towerSprite = towerSprite;
            this.name = name;
        }
    }
    public class CanvasAchivemen : UICanvas
    {
        [SerializeField] Image icon;
        [SerializeField] TextMeshProUGUI title;
        private List<DisplayData> achiveItems;
        private int id;

        public void SetUp(List<DisplayData> achiveItems)
        {
            this.achiveItems = achiveItems;
            id = 0;
            if (achiveItems != null && id < this.achiveItems.Count)
            {
                DisplayNextAchivement();
            }
            else
            {
                Debug.LogWarning("achiveItems is null or empty.");
                this.CloseDirectly();
            }
        }

        public void Exit()
        {
            if (achiveItems != null && id < this.achiveItems.Count)
            {
                DisplayNextAchivement();
            }
            else
            {
                UIManager.Instance.CloseUI <CanvasAchivemen>();
            }
        }

        private void DisplayNextAchivement()
        {
            Debug.Log(achiveItems.Count);
            DisplayData enumerator = achiveItems[id];
            Display(enumerator.towerSprite, enumerator.name);
            id += 1;
        }

        public void Display(Sprite sprite, string title)
        {
            icon.sprite = sprite;
            this.title.text = title;
        }
    }
}
