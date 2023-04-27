using System;
using TMPro;
using UnityEngine;

namespace WorldState {
    // ReSharper disable once InconsistentNaming
    public class NPC : Character {

        public override string CharacterName => gameObject.name;

        [SerializeField] private GameObject head;

        public override Vector3 ForwardHead {
            get {
                if (head == null) {
                    throw new Exception("NPC head is not set");
                }
                return head.transform.forward;
            }
            protected set => head.transform.forward = value;
        }


        private void Awake() {
            CreateNameTextField();
        }

        private void CreateNameTextField() { // create a text field above the NPC to display their name
            var go = new GameObject($"NameText ({CharacterName})", typeof(TextMeshPro));
            go.transform.SetParent(transform);
            var text =  go.GetComponent<TextMeshPro>();
            text.text = CharacterName;
            text.fontSize = 2f;
            text.alignment = TextAlignmentOptions.Center;
            text.color = Color.black;
            text.transform.localPosition = new Vector3(0f, 1.5f, 0f);
            // text.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
        }
        
    }
}
