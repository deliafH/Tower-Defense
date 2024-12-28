using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UI
{
    public class CanvasLibrary : UICanvas
    {
        [SerializeField] Transform holder;
        [SerializeField] LibraryDisplay libraryDisplayPrefab;
        private List<LibraryDisplay> slots = new List<LibraryDisplay>();
        private void Start()
        {
            Addressables.LoadAssetAsync<TowerListData>("TowerList").Completed += (op) =>
            {
                SetView(op.Result);
            };


        }
        private void SetView(TowerListData towerList)
        {
            foreach (TowerData tower in towerList.TowerDatas)
            {
                 GetView().SetUp(tower);
            }
        }

        public LibraryDisplay GetView()
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (!slots[i].gameObject.activeSelf)
                {
                    return slots[i];
                }
            }
            LibraryDisplay slot = Instantiate(libraryDisplayPrefab, holder);
            slots.Add(slot);
            return slot;
        }

        public void Close()
        {
            CloseDirectly();
        }
    }
}