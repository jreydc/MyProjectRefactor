using System;
using UnityEngine;

namespace UI.Pages
{
    [RequireComponent(typeof(PageControls))]
    internal class BasePage : MonoBehaviour
    {
        public bool IsOpen { get; private set; }

        public event Action<BasePage> OnOpen;
        public event Action<BasePage> OnClose;

        [HideInInspector] public PageControls Page;

        protected virtual void Awake()
        {
            Page = this.GetComponent<PageControls>();

            OnOpen += (x) => IsOpen = true;
            OnClose += (x) => IsOpen = false;
        }

        public void Switch(BasePage next)
        {
            Page.Switch(next.Page);
            next.Page.LeftAction = () => Back(next);

            this.OnClose?.Invoke(next);
            next.OnOpen?.Invoke(this);
        }

        private void Back(BasePage next)
        {
            next.Page.Switch(Page);

            next.OnClose?.Invoke(this);
            this.OnOpen?.Invoke(next);
        }
    }
 }
