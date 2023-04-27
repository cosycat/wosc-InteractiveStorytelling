using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace WorldState {
    public class Slot : Furniture
    {
        public enum SlotType {
            Sitting,
            Standing,
        }
        [SerializeField] private SlotType slotType;

        [SerializeField] private Vector2 dimensions = new(1f, 1f);
        
        
        /// <summary>
        /// Whether the slot is a sitting or standing slot.
        /// </summary>
        public SlotType Type => slotType;

        /// <summary>
        /// The center position of the slot.
        /// </summary>
        public Vector3 Position => transform.position;
        
        /// <summary>
        /// The direction, in world space, that the slot is facing.
        /// </summary>
        public Vector3 Forward => transform.forward;

        /// <summary>
        /// The dimensions of the slot.
        /// </summary>
        public Vector2 Dimensions {
            get => dimensions;
            private set => dimensions = value;
        }

        /// <summary>
        /// The character currently occupying the slot.
        /// </summary>
        public Character CurrentCharacter { get; private set; }

        /// <summary>
        /// Whether the slot is occupied by a character.
        /// </summary>
        public bool IsOccupied => CurrentCharacter != null;
        
        /// <summary>
        /// Occupy the slot with a character.
        /// </summary>
        /// <param name="character"> The character to occupy the slot. </param>
        /// <returns> False if the slot is already occupied, true otherwise. </returns>
        public bool Occupy(Character character) {
            if (CurrentCharacter != null) {
                return false;
            }
            CurrentCharacter = character;
            return true;
        }
        
        /// <summary>
        /// Vacate the slot.
        /// </summary>
        /// <returns> False if the slot is already vacant, true otherwise. </returns>
        public bool Vacate() {
            if (CurrentCharacter == null) {
                return false;
            }
            CurrentCharacter = null;
            return true;
        }

        private void OnDrawGizmos() {
            // draw a flat square at the center of the slot
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Position, new Vector3(Dimensions.x, 0.01f, Dimensions.y));

            // slot indicator
            // draw an arrow from the center of the slot to the center of the slot + 1 unit in the forward direction
            Gizmos.color = Color.green;
            Gizmos.DrawLine(Position, Position + Forward);
            Gizmos.DrawWireSphere(Position, 0.05f);
            
            // character indicator
            // draw a line from the center of the slot to the center of the character occupying the slot
            if (CurrentCharacter != null) {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(Position, CurrentCharacter.transform.position);
            }
            
        }
    }
}
