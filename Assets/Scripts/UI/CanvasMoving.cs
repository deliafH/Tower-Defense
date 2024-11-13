using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UI
{
    class CanvasMoving : UICanvas
    {
        public void OpenMenu()
        {
            UIManager.Instance.CloseAll();
            if (GameManager.Instance.GetGameState() == GameState.GAMEPLAY)
            {
                UIManager.Instance.OpenUI<CanvasGamePlay>();
            }
            else
            {
                UIManager.Instance.OpenUI<CanvasMainMenu>();
            }
        }
    }
}