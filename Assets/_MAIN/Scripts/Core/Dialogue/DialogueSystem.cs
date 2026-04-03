using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class DialogueSystem : MonoBehaviour
    {
        public DialogueContainer dialogueContainer = new DialogueContainer();
        private ConversationManager conversationManager;
        private TextArchitect architect;

        public static DialogueSystem instance { get; private set; }

        public delegate void DialogueSystemEvent();
        public event DialogueSystemEvent onUserPromt_Next;

        public bool isRunningConversation => conversationManager.isRunning;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                Initialized();
            }
            else
                DestroyImmediate(gameObject);
        }

        bool _initialized = false;

        private void Initialized()
        {
            if (_initialized)
                return;

            architect = new TextArchitect(dialogueContainer.dialogueText);
            conversationManager = new ConversationManager(architect);
        }

        public void OnUserPromt_Next()
        {
            onUserPromt_Next?.Invoke();
        }

        public void ShowSpeakerName(string speakerName = "")
        {
            if (speakerName.ToLower() != ("рассказчик"))
                dialogueContainer.nameContainer.Show(speakerName);
            else
                HideSpeakerName();
        }
        public void HideSpeakerName() => dialogueContainer.nameContainer.Hide();

        public void Say(string speaker, string dialogue)
        {
            List<string>  conversation = new List<string>() { $"{speaker} \"{dialogue}\"" };
            Say(conversation);
        }
        public void Say(List<string> conversation)
        {
            conversationManager.StartConversation(conversation);
        }
    }
}