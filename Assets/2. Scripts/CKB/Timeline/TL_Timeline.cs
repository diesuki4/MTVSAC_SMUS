using System;
using System.Collections;
using System.Collections.Generic;
using Timeline.Types;
using Timeline.Utility;

namespace Timeline
{
    namespace Timeline
    {
        [Serializable]
        public class TL_Timeline
        {
            public TL_ENUM_Types tlType;
            string itemName;

            List<TL_Types.Key> keys;

            public TL_Timeline(TL_ENUM_Types tlType, string itemName)
            {
                this.tlType = tlType;
                this.itemName = itemName;

                keys = new List<TL_Types.Key>();
            }

            public List<TL_Types.Key> GetKeys()
            {
                return keys;
            }

            public bool AddKey(TL_Types.Key key)
            {
                keys.Add(key);

                return keys.Contains(key);
            }

            public bool DeleteKey(TL_Types.Key key)
            {
                return keys.Remove(key);
            }

            public bool DeleteKey(int frame)
            {
                foreach (TL_Types.Key key in keys)
                    if (key.frame == frame)
                        return DeleteKey(key);

                return false;
            }

            public bool DeleteAllKeys()
            {
                keys.Clear();

                return keys.Count == 0;                
            }

            ~TL_Timeline()
            {
                DeleteAllKeys();
            }
        }
    }
}
