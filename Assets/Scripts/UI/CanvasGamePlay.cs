using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace UI
{
    class CanvasGamePlay : UICanvas
    {
        [SerializeField] Slider slider; 

        
        public void Replay()
        {
            Addressables.LoadSceneAsync("GamePlay");
        }

        private void OnEnable()
        {
            slider.value = 1;
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
                if((float)parameters[0] == 0)
                {
                    UIManager.Instance.CloseAll();
                    UIManager.Instance.OpenUI<CanvasLose>();
                }
                else slider.value = (float)parameters[0];

            }
        }

    }
}