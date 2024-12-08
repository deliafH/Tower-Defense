using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UI
{
    class CanvasChooseLevel:UICanvas
    {
        public void Playgame(int level)
        {
            Addressables.LoadSceneAsync("Level" + level);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            // If in the editor, stop playing the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // If in a build, quit the application
            Application.Quit();
#endif
        }

        public void OpenHome()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasHome>();
        }
    }
}
