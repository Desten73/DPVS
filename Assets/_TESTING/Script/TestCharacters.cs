using System.Collections;
using UnityEngine;
using CHARACTERS;
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
            //Character_Sprite guard2 = CreateCharacter("Raelin") as Character_Sprite;
            Character_Sprite guard2 = CreateCharacter("Guard2 as Generic") as Character_Sprite;
            //Character guard3 = CreateCharacter("Generic");

            guard1.Show();
            guard2.Show();
            //guard3.Show();
            Character_Sprite guard4 = CreateCharacter("Raelin") as Character_Sprite;
            Character_Sprite guard3 = CreateCharacter("Guard3 as Generic") as Character_Sprite;
            guard1.SetPriority(1);
            guard2.SetPriority(2);
            guard3.SetPriority(3);
            guard4.SetPriority(4);
            guard3.Show();
            guard4.Show();
            yield return new WaitForSeconds(1);
            CharacterManager.instance.SortCharacters(new string[] { "Guard2", "Guard3", "Raelin" });
            yield return new WaitForSeconds(1);

            CharacterManager.instance.SortCharacters();

            guard1.SetPosition(Vector2.zero);
            guard2.SetPosition(new Vector2(0.5f, 0.5f));
            //guard3.SetPosition(Vector2.one);
            yield return new WaitForSeconds(1);

            Sprite s3 = guard1.GetSprite("Sergant-Sergant");
            yield return guard2.TransitionSprite(s3);

            Sprite s1 = guard1.GetSprite("Roga-Roga");
            yield return guard1.TransitionSprite(s1);
            yield return guard1.FaceRight(0.3f);
            yield return guard1.MoveToPosition(Vector2.one, smooth: true);

            guard2.Animate("Hop");

            yield return new WaitForSeconds(1);
            yield return guard2.UnHighlight();
            yield return new WaitForSeconds(1);
            Sprite s2 = guard1.GetSprite("Priest-Priest");
            yield return guard1.TransitionSprite(s2);
            yield return guard1.UnHighlight();
            yield return guard1.Say("Тестовое сообщение");

            yield return new WaitForSeconds(1);
            yield return guard2.TransitionColor(Color.red);
            yield return new WaitForSeconds(1);
            yield return guard2.Highlight();
            yield return new WaitForSeconds(1);
            yield return guard2.TransitionColor(Color.white);

            //Sprite s1 = guard2.GetSprite("Default-Raelin_1");
            //Sprite s2 = guard2.GetSprite("Default-Raelin_6");
            //yield return guard2.TransitionSprite(s1, 0);
            //yield return guard2.TransitionSprite(s2, 1);
            //yield return guard2.TransitionColor(Color.red, 0.3f);
            //yield return guard2.TransitionColor(Color.blue, 0.3f);
            //yield return guard2.TransitionColor(Color.white);
            //yield return new WaitForSeconds(1);


            guard1.Animate("Shiver", true);
            yield return guard1.MoveToPosition(Vector2.zero, smooth: true);
            yield return guard1.Flip(0.5f);
            yield return guard1.TransitionColor(Color.gray);
            guard1.Animate("Shiver", false);



            yield return null;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}