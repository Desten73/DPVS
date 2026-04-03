using DIALOGUE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{
    public class TestDialogueFiles : MonoBehaviour
    {
        void Start()
        {
            StartConversation();
        }


        void StartConversation()
        {
            List<string> lines = FileManager.ReadTextAsset("testFile");

            DialogueSystem.instance.Say(lines);
        }
    }
}