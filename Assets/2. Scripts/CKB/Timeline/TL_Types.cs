using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timeline
{
    namespace Types
    {
        public class CDTSortedSet : SortedSet<TL_Types.Key>
        {
            public CDTSortedSet() : base(new KeyComparer()) {}
        }

        class KeyComparer : IComparer<TL_Types.Key>
        {
            public int Compare(TL_Types.Key x, TL_Types.Key y)
            {
                return x.frame.CompareTo(y.frame);
            }
        }

        public enum TL_ENUM_Types
        {
            Object,
            Effect,
            Light
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
