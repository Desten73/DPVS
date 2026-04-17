using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;
using TMPro;

namespace TESTING
{
    public class TestCharacters : MonoBehaviour
    {
        // Start is called before the first frame update
        public TMP_FontAsset tempFont;

        private Character CreateCharacter(string name) => CharacterManager.instance.CreateCharacter(name);
        void Start()
        {
            //Character Stella = CharacterManager.instance.CreateCharacter("Generic");
            //Character Elen = CharacterManager.instance.CreateCharacter("Эллен");
            //Character Stella2 = CharacterManager.instance.CreateCharacter("Стелла");
            //Character Adam = CharacterManager.instance.CreateCharacter("Адам");

            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            Character_Sprite guard1 = CreateCharacter("Guard1 as Generic") as Character_Sprite;
            Character_Sprite guard2 = CreateCharacter("Raelin") as Character_Sprite;
            Character guard3 = CreateCharacter("Generic");

            guard1.Show();
            guard2.Show();
            guard3.Show();

            guard1.SetPosition(Vector2.zero);
            guard2.SetPosition(new Vector2(0.5f, 0.5f));
            guard3.SetPosition(Vector2.one);

            yield return guard1.MoveToPosition(Vector2.one, smooth: true);

            Sprite s1 = guard2.GetSprite("Default-Raelin_1");
            Sprite s2 = guard2.GetSprite("Default-Raelin_6");
            guard2.TransitionSprite(s1, 0);
            guard2.TransitionSprite(s2, 1);
            yield return guard2.TransitionColor(Color.red, 0.3f);
            yield return guard2.TransitionColor(Color.blue, 0.3f);
            yield return guard2.TransitionColor(Color.white);
            yield return new WaitForSeconds(1);


            yield return guard1.MoveToPosition(Vector2.zero, smooth: true);



            yield return null;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}