using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace UI
{
    class CanvasShop : UICanvas
    {
        [SerializeField] TextMeshProUGUI goldText;
        private void OnEnable()
        {
            goldText.text = GameManager.Instance.GetGoldVal().ToString();
        }
        public void OpenMenu()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasMainMenu>();
        }
    }
}