using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace UI
{
    class CanvasGamePlay : UICanvas
    {
        [SerializeField] Image image;
        [SerializeField] Sprite[] hpSprites;
        [SerializeField] TextMeshProUGUI goldText;

        public void OpenShop()
        {
            GameManager.Instance.OpenShop();
            UIManager.Instance.OpenUI<CanvasShop>();
        }

        private void UpdateGoldDisplay(int newGoldValue)
        {
            goldText.text = newGoldValue.ToString();
        }
        public void Replay()
        {
            Addressables.LoadSceneAsync("Level" + GameManager.Instance.Level);
        }
        private void Start()
        {
            goldText.text = GameManager.Instance.GetGoldVal().ToString();
            GameManager.Instance.OnGoldValueChanged += UpdateGoldDisplay;
        }
        private void OnEnable()
        {
            image.sprite = hpSprites[hpSprites.Length - 1];
            EventManager.Instance.StartListening("Dameage", SetHp);
        }

        private void OnDisable()
        {
            EventManager.Instance.StopListening("Dameage", SetHp);
        }

        private void SetHp(object[] parameters)
        {
            if(parameters[0] is float)
            {
                if ((float)parameters[0] <= 0)
                {
                    UIManager.Instance.CloseAll();
                    UIManager.Instance.OpenUI<CanvasLose>();
                    WakeUpBots.Instance.LoseGame();
                }
                else
                {
                    image.sprite = hpSprites[(int)(hpSprites.Length * (float)parameters[0])];
                }

            }
        }

    }
}