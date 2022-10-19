using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timeline
{
    namespace Types
    {
        public enum TL_ENUM_Types
        {
            Object,
            Effect,
            Light
        }

        public enum TL_ENUM_Types_Object
        {
            Tree1,
            Tree2,
            Mic1,
            Chair1
        }

        public enum TL_ENUM_Types_Effect
        {
            Bomb1,
            Bomb2,
            Snow1
        }

        public enum TL_ENUM_Types_Light
        {
            Directional,
            Point,
            Spot
        }

        public class TL_Types
        {
            [Serializable]
            public class Key
            {
                public int frame;
            }

            [Serializable]
            public class Object : Key
            {
                public Vector3 position;
                public Quaternion rotation;
            }

            [Serializable]
            public class Effect : Key
            {
                public Vector3 position;
                public Quaternion rotation;
            }

            [Serializable]
            public class Light : Key
            {
                public Vector3 position;
                public Quaternion rotation;
                public float intensity;
                public Color color;
            }
        }
    }
}
