using _Project.Scripts.Services.Logger;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.Services
{
    [UsedImplicitly]
    public class InputReader
    {
        private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<InputReader>();

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
