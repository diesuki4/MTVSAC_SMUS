using System;
using System.Linq;
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

            SortedSet<TL_Types.Key> keys;

            public TL_Timeline(TL_ENUM_Types tlType, string itemName)
            {
                this.tlType = tlType;
                this.itemName = itemName;

                keys = new SortedSet<TL_Types.Key>(new KeyComparer());
            }

            class KeyComparer : IComparer<TL_Types.Key>
            {
                public int Compare(TL_Types.Key x, TL_Types.Key y)
                {
                    return x.frame.CompareTo(y.frame);
                }
            }

            public List<TL_Types.Key> GetKeys()
            {
                return keys.ToList();
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

            public int IndexOf(int frame)
            {
                List<TL_Types.Key> lstKeys = keys.ToList();

                for (int i = 0; i < lstKeys.Count; ++i)
                    if (lstKeys[i].frame == frame)
                        return i;

                return -1;             
            }

            ~TL_Timeline()
            {
                DeleteAllKeys();
            }
        }
    }
}
