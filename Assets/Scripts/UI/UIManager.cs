using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UI
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private UICanvas[] uiResources;
        private Dictionary<System.Type, UICanvas> uiCanvasPrefab = new Dictionary<System.Type, UICanvas>();
       
        private Dictionary<System.Type, UICanvas> uiCanvas = new Dictionary<System.Type, UICanvas>();

        public Transform CanvasParentTF;

        #region Canvas

        //open UI
        //mo UI canvas
        public async Task<T> OpenUI<T>() where T : UICanvas
        {
            var ui = await GetUI<T>();
            ui.Open();
            return ui;
        }

        //close UI directly
        //dong UI canvas ngay lap tuc
        public async Task CloseUI<T>() where T : UICanvas
        {
            if (IsOpened<T>())
            {
                var ui = await GetUI<T>();
                ui.CloseDirectly();
            }
        }

        //close UI with delay time
        //dong ui canvas sau delay time
        public async Task CloseUI<T>(float delayTime) where T : UICanvas
        {
            if (uiCanvas.ContainsKey(typeof(T)))
            {
                var ui = await GetUI<T>();
                ui.Close(delayTime);
            }
        }

        //check UI is Opened
        //kiem tra UI dang duoc mo len hay khong
        public bool IsOpened<T>() where T : UICanvas
        {
            return IsLoaded<T>() && uiCanvas[typeof(T)].gameObject.activeInHierarchy;
        }

        //check UI is loaded
        //kiem tra UI da duoc khoi tao hay chua
        public bool IsLoaded<T>() where T : UICanvas
        {
            System.Type type = typeof(T);
            return uiCanvas.ContainsKey(type) && uiCanvas[type] != null;
        }

        //Get component UI 
        //lay component cua UI hien tai
        public async Task<T> GetUI<T>() where T : UICanvas
        {
            //Debug.LogError(typeof(T));
            if (!uiCanvas.ContainsKey(typeof(T)))
            {
                var prefab = await GetUIPrefab<T>();
                uiCanvas[typeof(T)] = Instantiate(prefab, CanvasParentTF);
            }

            return uiCanvas[typeof(T)] as T;
        }

        //Close all UI
        //dong tat ca UI ngay lap tuc -> tranh truong hop dang mo UI nao dong ma bi chen 2 UI cung mot luc
        public void CloseAll()
        {
            foreach (var item in uiCanvas)
            {
                if (item.Value != null && item.Value.gameObject.activeInHierarchy)
                {
                    item.Value.CloseDirectly();
                }
            }
        }

        //Get prefab from resource
        //lay prefab tu Resources/UI 
        private async Task<T> GetUIPrefab<T>() where T : UICanvas
        {
            while (!uiCanvasPrefab.ContainsKey(typeof(T)))
            {
                var op = Addressables.LoadAssetAsync<GameObject>(typeof(T).Name.Replace("UI.", ""));
                await op.Task;
                uiCanvasPrefab[typeof(T)] = op.Result.GetComponent<T>();
            }

            return uiCanvasPrefab[typeof(T)] as T;
        }


        #endregion
    }
}