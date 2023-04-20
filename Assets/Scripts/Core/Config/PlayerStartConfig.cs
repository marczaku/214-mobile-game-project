using Shared.Config;
using UnityEngine;

namespace Core.Config
{
    /// <summary>
    /// Very safe to add mew values to this class.
    /// Also easy to merge, even if there's conflicts.
    /// </summary>
    [CreateAssetMenu]
    public class PlayerStartConfig : ConfigBase
    {
        // private, so no other class can see these
        [SerializeField] int maxHealth = 1000; // Change during Runtime. Should not be serialized.
        [SerializeField] int health = 50; // MODEL what is the current state of information?
        private int blah;
        public int Health => health; // READ-ONLY Access {get}
        public int MaxHealth => maxHealth; // READ-ONLY Access {get}
        public int something;
        public int anotherThing;
    }
}
