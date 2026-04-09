using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTERS
{
    [CreateAssetMenu(fileName = "Character Configuration Asset", menuName = "Dialogue System/Character Configuration Asset")]
    public class CharacterConfigSO : ScriptableObject
    {
        public CharacterConfigData[] characters;
    }
}