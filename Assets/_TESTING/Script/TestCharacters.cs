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
            Character guard1 = CreateCharacter("Guard1 as Generic");
            Character guard2 = CreateCharacter("Guard2 as Generic");
            Character guard3 = CreateCharacter("Guard3 as Generic");

            guard1.Show();
            guard2.Show();
            guard3.Show();

            yield return null;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}