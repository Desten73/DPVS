using DIALOGUE;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestDialogueFiles : MonoBehaviour
    {
        [SerializeField] private TextAsset fileToRead = null;

        void Start()
        {
            StartConversation();
        }


        void StartConversation()
        {
            List<string> lines = FileManager.ReadTextAsset(fileToRead);

            //for (int i = 0; i < lines.Count; i++)
            //{
            //    string line = lines[i];

            //    if (string.IsNullOrWhiteSpace(line))
            //        continue;

            //    DIALOGUE_LINE dl = DialogueParser.Parse(line);
            //    for (int c = 0; c < dl.commandsData.commands.Count; c++)
            //    {
            //        DL_COMMAND_DATA.Command command = dl.commandsData.commands[c];
            //        Debug.Log($"Command [{c}] '{command.name}' has arguments [{string.Join(", ", command.arguments)}]");
            //    }
            //}

            DialogueSystem.instance.Say(lines);
        }
    }
}