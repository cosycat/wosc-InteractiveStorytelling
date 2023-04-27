using UnityEngine;

namespace WorldState {
    public class Furniture : Thing {
        public Vector3 Position => transform.position;

        public virtual Slot CharacterSlot => null;
        public bool IsCharacterSlot => CharacterSlot != null;
    }
}