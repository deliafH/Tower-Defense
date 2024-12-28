using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UI
{
    class CanvasShop : UICanvas
    {
        [SerializeField] TextMeshProUGUI goldText;
        [SerializeField] Transform holder;
        [SerializeField] TowerDisplay towerDisplayPrefab;
        private List<TowerDisplay> slots = new List<TowerDisplay>();
        private void Start()
        {
            Addressables.LoadAssetAsync<TowerListData>("TowerList").Completed += (op) =>
            {
                SetView(op.Result);
            };
            GameManager.Instance.OnGoldValueChanged += UpdateGoldDisplay;

        }

        private void UpdateGoldDisplay(int newGoldValue)
        {
            goldText.text = newGoldValue.ToString();
        }

        public void OpenMenu()
        {
            CloseDirectly();
        }
        public void SetView(TowerListData towerList)
        {
            foreach (TowerData tower in towerList.TowerDatas)
            {
                if(tower.isUnlock)GetView().SetUp(tower);
            }
        }

        public TowerDisplay GetView()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (!slots[i].gameObject.activeSelf)
                {
                    return slots[i];
                }
            }
            TowerDisplay slot = Instantiate(towerDisplayPrefab, holder);
            slots.Add(slot);
            return slot;
        }
    }

    
}