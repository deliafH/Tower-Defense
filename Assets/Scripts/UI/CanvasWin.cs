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
    class CanvasWin : UICanvas
    {


        public void Replay()
        {
            Addressables.LoadSceneAsync("GamePlay");
        }


    }
}