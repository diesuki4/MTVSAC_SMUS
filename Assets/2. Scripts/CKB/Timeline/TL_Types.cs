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
                public Vector3 position;
                public Quaternion rotation;

                public Key(int frame, Vector3 position, Quaternion rotation)
                {
                    this.frame = frame;
                    this.position = position;
                    this.rotation = rotation;
                }
            }

            [Serializable]
            public class Object : Key
            {
                public Object(int _frame, Vector3 _position, Quaternion _rotation) : base(_frame, _position, _rotation) { }
            }

            [Serializable]
            public class Effect : Key
            {
                public Effect(int _frame, Vector3 _position, Quaternion _rotation) : base(_frame, _position, _rotation) { }
            }

            [Serializable]
            public class Light : Key
            {
                public float intensity;
                public Color color;

                public Light(int _frame, Vector3 _position, Quaternion _rotation, float intensity, Color color) : base(_frame, _position, _rotation)
                {
                    this.intensity = intensity;
                    this.color = color;
                }
            }
        }
    }
}
