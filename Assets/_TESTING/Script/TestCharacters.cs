using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CHARACTERS;
using DIALOGUE;

namespace TESTING
{
    public class TestCharacters : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Character Stella = CharacterManager.instance.CreateCharacter("Стелла");
            //Character Elen = CharacterManager.instance.CreateCharacter("Эллен");
            //Character Stella2 = CharacterManager.instance.CreateCharacter("Стелла");
            //Character Adam = CharacterManager.instance.CreateCharacter("Адам");

            StartCoroutine(Test());
        }

        IEnumerator Test()
        {
            Character Elen = CharacterManager.instance.CreateCharacter("Elen");
            Character Stella = CharacterManager.instance.CreateCharacter("Стелла");
            Character Ben = CharacterManager.instance.CreateCharacter("Бэнджамин");
            List<string> lines = new List<string>()
            {
                "Hi",
                "My name Elen",
                "What are you name",
                "Oyy,{wa 1} nice to meet you"
            };
            yield return Elen.Say(lines);

            lines = new List<string>()
            {
                "Меня зовут Адам.",
                "Проверим еще пару строк{c} Здесь.",
                "Вроде бы все окей..."
            };

            yield return Ben.Say(lines);

            yield return Stella.Say("Это строка, которую я хочу сказать.{a} Всего лишь обычная фраза.");

            Debug.Log("Filished");

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}