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
                public bool active;
                public Vector3 position;
                public Quaternion rotation;

                public Key(int frame, bool active, Vector3 position, Quaternion rotation)
                {
                    this.frame = frame;
                    this.active = active;
                    this.position = position;
                    this.rotation = rotation;
                }
            }

            [Serializable]
            public class Object : Key
            {
                public Object(int _frame, bool _active, Vector3 _position, Quaternion _rotation) : base(_frame, _active, _position, _rotation) { }
            }

            [Serializable]
            public class Effect : Key
            {
                public Effect(int _frame, bool _active, Vector3 _position, Quaternion _rotation) : base(_frame, _active, _position, _rotation) { }
            }

            [Serializable]
            public class Light : Key
            {
                public Light(int _frame, bool _active, Vector3 _position, Quaternion _rotation) : base(_frame, _active, _position, _rotation) { }
            }
        }
    }
}
