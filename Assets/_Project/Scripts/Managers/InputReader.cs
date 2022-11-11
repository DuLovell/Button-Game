using _Project.Scripts.Managers.Logger;
using _Project.Scripts.Utilities;
using UnityEngine;

namespace _Project.Scripts.Managers
{
    public class InputReader : Singleton<InputReader>
    {
        private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<InputReader>();

        private void Update()
        {
            if (Input.touches.Length == 0) {
                return;
            }

            TouchPhase touchPhase = Input.GetTouch(0).phase;
            switch (touchPhase)
            {
                case TouchPhase.Began:
                    _logger.Debug("Touch began");
                    break;
                case TouchPhase.Canceled or TouchPhase.Ended:
                    _logger.Debug("Touch ended or cancelled");
                    break;
            }
        }

        public bool TryGetTouch(out Touch touch)
        {
            if (Input.touches.Length == 0) {
                touch = default;
                return false;
            }

            touch = Input.GetTouch(0);
            return true;
        }
    }
}
