using FSM.Attributes;
using UnityEngine;

namespace _Project.Scripts.MainButton.Data
{
    [CreateAssetMenu(fileName = "MainButtonModel", menuName = "Data/MainButton/Model", order = 0)]
    public class MainButtonModel : ScriptableObject, ISerializationCallbackReceiver
    {
        [ReadOnlyInspector]
        public int PushCount;

        public void OnAfterDeserialize()
        {
            PushCount = 0;
        }
        
        public void OnBeforeSerialize()
        {
            
        }
    }
}