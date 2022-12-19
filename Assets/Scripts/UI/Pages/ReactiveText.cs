using System;
using TMPro;
using UnityEngine;

namespace UI.Pages
{
    [Serializable]
    public class ReactiveText
    {
        public event Action OnTextUpdate;

        public string Value
        {
            get => _tmpText?.text;
            set
            {
                if (_tmpText != null)
                {
                    _tmpText.text = value;
                    OnTextUpdate?.Invoke();
                }
            }
        }
        [SerializeField] private TMP_Text _tmpText;
    }
}