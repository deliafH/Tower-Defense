using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UICanvas : MonoBehaviour
    {
        public bool IsDestroyOnClose = false;
        protected RectTransform m_RectTransform;
        private Animator m_Animator;
        private float m_OffsetY = 0;



        private void Start()
        {
            OnInit();
        }

        protected void OnInit()
        {
            m_RectTransform = GetComponent<RectTransform>();
            m_Animator = GetComponent<Animator>();
        }


        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void CloseDirectly()
        {
            gameObject.SetActive(false);
            if (IsDestroyOnClose)
            {
                Destroy(gameObject);
            }

        }

        public virtual void Close(float delayTime)
        {
            Debug.Log("Close");
            Invoke(nameof(CloseDirectly), delayTime);
        }

    }
}