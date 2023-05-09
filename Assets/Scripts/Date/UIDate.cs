using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Date
{
    [CreateAssetMenu(fileName = "UIDate", menuName = "ScriptableObjects/UIDate", order = 3)]
    public class UIDate : ScriptableObject
    {
        public Color accentColor;
        public Color correctColor;
        public Color wrongColor;
    }
}