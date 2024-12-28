using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UI
{
    class CanvasWin : UICanvas
    {
        private void OnEnable()
        {
            if (!PlayerPrefs.HasKey("PlayerLevel") || GameManager.Instance.Level > PlayerPrefs.GetInt("PlayerLevel"))
            {
                Debug.Log(1);
                PlayerPrefs.SetInt("PlayerLevel", GameManager.Instance.Level);
                LoadTowerListAsync();
            }
        }

        private async void LoadTowerListAsync()
        {
            var op = Addressables.LoadAssetAsync<TowerListData>("TowerList");
            await op.Task; // Await the loading operation

            List<TowerData> towers = op.Result.TowerDatas;
            List<DisplayData> datas = new List<DisplayData>();

            foreach (TowerData tower in towers)
            {
                if (tower.unlockLevel == GameManager.Instance.Level)
                {
                    datas.Add(new DisplayData( tower.towerSprite, tower.Name));
                }
            }

            if (datas.Count > 0)
            {
                CanvasAchivemen canvasAchivemen = await UIManager.Instance.GetUI<CanvasAchivemen>();
                canvasAchivemen.SetUp(datas);
            }
        }

        public void Replay()
        {
            Addressables.LoadSceneAsync("Level" + GameManager.Instance.Level);
        }

        public void NextLevel()
        {
            Addressables.LoadSceneAsync("Level" + (GameManager.Instance.Level + 1));
        }

        public void OpenHome()
        {
            Addressables.LoadSceneAsync("MainMenu");
        }
    }
}