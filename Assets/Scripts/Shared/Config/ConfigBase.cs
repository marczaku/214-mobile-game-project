using UnityEngine;

namespace Shared.Config
{
    [CreateAssetMenu]
    
    public class ConfigBase : ScriptableObject
    {
        public System.Guid uniqueId;
    }
}