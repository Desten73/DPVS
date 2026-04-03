using UnityEngine;
using TMPro;

namespace DIALOGUE
{
    [System.Serializable]
    public class DialogueContainer
    {
        // содержит текст названия и диалога
        public GameObject root;
        // имя активного персонажа
        public NameContainer nameContainer;
        // текст диалога персонажа
        public TextMeshProUGUI dialogueText;
    }
}