using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UI {
    public class CanvasMainMenu : UICanvas
    {
        public void OpenShop()
        {
            UIManager.Instance.CloseAll();
            GameManager.Instance.OpenShop();
            UIManager.Instance.OpenUI<CanvasShop>();
        }

        public void OpenMoving()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasMoving>();
        }

        public void PlayGame()
        {
            WakeUpBots.Instance.WakeUp();
                UIManager.Instance.CloseAll();
                UIManager.Instance.OpenUI<CanvasGamePlay>();
                EventManager.Instance.TriggerEvent("PlayGame");
        }


        public void OpenHome()
        {
            Addressables.LoadSceneAsync("MainMenu");
        }

    }
}
