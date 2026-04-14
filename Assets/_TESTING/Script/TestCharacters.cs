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
            yield return new WaitForSeconds(1f);
            Character Raelin = CharacterManager.instance.CreateCharacter("Raelin");

            //yield return new WaitForSeconds(1f);
            //yield return Raelin.Hide();

            yield return new WaitForSeconds(0.5f);
            yield return Raelin.Show();

            yield return Raelin.Say("Привет!");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}