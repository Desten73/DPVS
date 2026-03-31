using UnityEngine;
using TMPro;

[System.Serializable]
public class DialogueContainer
{
    // содержит текст названия и диалога
    public GameObject root;
    // имя активного персонажа
    public TextMeshProUGUI nameText;
    // текст диалога персонажа
    public TextMeshProUGUI dialogueText;
}
