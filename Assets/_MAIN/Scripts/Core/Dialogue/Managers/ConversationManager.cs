using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class ConversationManager
    {
        private DialogueSystem dialogueSystem => DialogueSystem.instance;
        private Coroutine process = null;
        public bool isRunning => process != null;

        private TextArchitect architect = null;
        private bool userPromt = false;

        public ConversationManager(TextArchitect architect)
        {
            this.architect = architect;
            dialogueSystem.onUserPromt_Next += OnUserPromt_Next;
        }

        private void OnUserPromt_Next()
        {
            userPromt = true;
        }

        public void StartConversation(List<string> conversation)
        {
            StopConversation();

            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));
        }

        public void StopConversation()
        {
            if (!isRunning)
                return;

            dialogueSystem.StopCoroutine(process);
            process = null;
        }

        IEnumerator RunningConversation(List<string> conversation)
        {
            for(int i = 0; i< conversation.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(conversation[i]))
                    continue;

                DIALOGUE_LINE line = DialogueParser.Parse(conversation[i]);

                // Показ самого диалога
                if (line.hasDialogue)
                    yield return Line_RunDialogue(line);

                // Отработка команд
                if (line.hasCommands)
                    yield return Line_RunCommands(line);
            }
        }

        IEnumerator Line_RunDialogue(DIALOGUE_LINE line)
        {
            if (line.hasSpeaker)
                dialogueSystem.ShowSpeakerName(line.speaker);

            // создаем диалог
            yield return BuildLineSegments(line.dialogue);

            // Ждем ввод данных от пользователя
            yield return WaitForUserInput();
        }
        IEnumerator Line_RunCommands(DIALOGUE_LINE line)
        {
            Debug.Log(line.commands);
            yield return null;
        }

        IEnumerator BuildLineSegments(DL_DIALOGUE_DATA line)
        {
            for (int i = 0; i < line.segments.Count; i++)
            {
                DL_DIALOGUE_DATA.DIALOGUE_SEGMENT segment = line.segments[i];

                yield return WaitForDialogueSegmentSignalToBeTriggered(segment);

                yield return BuildDialogue(segment.dialogue, segment.appendText);
            }
        }

        IEnumerator WaitForDialogueSegmentSignalToBeTriggered(DL_DIALOGUE_DATA.DIALOGUE_SEGMENT segment)
        {
            switch (segment.startSignal)
            {
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.C:
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.A:
                    yield return WaitForUserInput();
                    break;
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.WC:
                case DL_DIALOGUE_DATA.DIALOGUE_SEGMENT.StartSignal.WA:
                    yield return new WaitForSeconds(segment.signalDelay);
                    break;
                default:
                    break;
            }
        }

        IEnumerator BuildDialogue(string dialogue, bool append = false)
        {
            // построение диалога
            if (!append)
                architect.Build(dialogue);
            else
                architect.Append(dialogue);

            // ожидание пока диалог закончится
            while (architect.isBuilding)
            {
                if (userPromt)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();

                    userPromt = false;
                }
                yield return null;
            }
        }
        IEnumerator WaitForUserInput()
        {
            while (!userPromt)
                yield return null;

            userPromt = false;
        }
    }
}
