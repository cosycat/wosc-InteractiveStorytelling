

using UnityEngine;
using UnityEngine.Serialization;

namespace WorldState {
    public class Player : Character
    {
        [SerializeField] private string playerName = "PlayerName";

        public override string CharacterName => playerName;
    }
}
