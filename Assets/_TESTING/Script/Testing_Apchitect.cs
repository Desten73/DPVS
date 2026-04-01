using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

namespace TESTING
{
    public class NewBehaviourScript : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;

        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;

        string[] lines = new string[5]
        {
            " ewrew вавч  апчсчмвewr  вапвап ыва r",
            " кеуке вапвапвапав ролр о рорпо  пачп ",
            " fdgfdgf  f gdfgfdgdfgdfg  dfgd",
            " gjhjfgh g fghgfjfjfyj  fghdf",
            " ара  ке нгнеггнрв аыуауыау"
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
        }

        // Update is called once per frame
        void Update()
        {
            if (bm != architect.buildMethod)
            {
                architect.buildMethod = bm;
                architect.Stop();
            }

            if (Input.GetKeyDown(KeyCode.S))
                architect.Stop();

            string longLine = "weqweqw wqeqweqwewresf  sdfsd f sf sdfsdjfklsjfeo efjdsofjdskf авповадлаовыдлао ыовдаловыдлаоываы длыва, ывдалвы? двыоадвыпаьвдпкпплжд ыждлва!! лпывп";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (architect.isBuilding)
                {
                    if (!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();
                }
                else
                    architect.Build(longLine);
                    //architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(longLine);
                //architect.Append(lines[Random.Range(0, lines.Length)]);

            }
        }
    }
}