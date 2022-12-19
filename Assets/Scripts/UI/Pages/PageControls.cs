using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Pages
{
    public class PageControls : MonoBehaviour
    {
        private RectTransform _rectTransform;

        [SerializeField] public bool _enabled = false;
        [SerializeField] public ReactiveText Title;

        public Action LeftAction;
        public Action RightAction;

        async void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            await Task.Yield();
            gameObject.SetActive(_enabled);

            Title.OnTextUpdate += async () =>
            {
                await Task.Yield();
                LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
            };
        }

        public void Switch(PageControls next)
        {
            gameObject.SetActive(false);
            next.gameObject.SetActive(true);
        }

        public void Left()
        {
            LeftAction?.Invoke();
        }

        public void Right()
        {
            RightAction?.Invoke();
        }
    }
}