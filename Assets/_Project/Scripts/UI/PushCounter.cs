using _Project.Scripts.MainButton.Data;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class PushCounter : MonoBehaviour
    {
        [SerializeField] 
        private MainButtonModel _mainButtonModel = null!;

        private TextMeshProUGUI _counterText = null!;

        private void Awake()
        {
            _counterText = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            CounterText = _mainButtonModel.PushCount.ToString();
        }

        private string CounterText
        {
            set { _counterText.text = value; }
        }
    }
}