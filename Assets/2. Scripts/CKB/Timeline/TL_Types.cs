using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timeline
{
    namespace Types
    {
        public class TL_Types
        {
            [Serializable]
            public class Item
            {
                public string guid;
                public int objectId;
            }

            [Serializable]
            public class Object : Item
            {
                public Vector3 position;
                public Quaternion rotation;
            }

            [Serializable]
            public class Effect : Item
            {
                public Vector3 position;
                public Quaternion rotation;
            }

            [Serializable]
            public class Light : Item
            {
                public Vector3 position;
                public Quaternion rotation;
                public float intensity;
                public Color color;
            }
        }
    }
}
