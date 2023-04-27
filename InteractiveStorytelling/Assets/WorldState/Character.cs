using JetBrains.Annotations;
using UnityEngine;

namespace WorldState {
    public abstract class Character : MonoBehaviour
    {
        
        /// <summary>
        /// "pose indicates the character’s pose in this event (e.g., standing, sitting)." Section 5.2
        /// </summary>
        public PoseType PoseType { get; protected set; } = PoseType.Standing;
        
        /// <summary>
        /// "Verb indicates the character’s interaction with a real furniture or a virtual item" Section 5.2
        /// </summary>
        public VerbType VerbType { get; protected set; } = VerbType.None;
        
        /// <summary>
        /// "Interactee refers to the furniture object or virtual item that the character is interacting with." Section 5.2
        /// </summary>
        public Thing Interactee { get; protected set; }
        
        [CanBeNull]
        public Slot CurrentSlot { get; private set; }

        public Room CurrentRoom { get; private set; }

        public abstract string CharacterName { get; }

        public virtual Vector3 Position => transform.position;
        
        public virtual Vector3 ForwardBody => transform.forward;

        public virtual Vector3 ForwardHead { get; protected set; }
        
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


    public enum PoseType {
        Standing,
        Sitting,
    }
    
    public enum VerbType {
        Watching,
        Reading,
        Using,
        None
    }

}
