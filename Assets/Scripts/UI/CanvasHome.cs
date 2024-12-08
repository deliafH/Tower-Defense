using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI
{
    public class CanvasHome : UICanvas
    {
        public void OpenLevels()
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasChooseLevel>();
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
    }
}
