using JetBrains.Annotations;
using UnityEngine;

namespace WorldState {
    public abstract class Character : MonoBehaviour
    {
        [CanBeNull]
        public Slot CurrentSlot { get; private set; }

        public Room CurrentRoom { get; private set; }

        

        public virtual Vector3 Position => transform.position;
        
        public virtual Vector3 ForwardBody => transform.forward;

        public virtual Vector3 ForwardHead { get; private set; }
        
        private bool SitOn(Slot slot) {
            if (slot == null || slot.IsOccupied || slot == CurrentSlot || CurrentSlot != null) {
                return false;
            }

            if (slot != null && slot.Occupy(this)) {
                CurrentSlot = slot;
                return true;
            }

            return false;

        }
        
    }
}
