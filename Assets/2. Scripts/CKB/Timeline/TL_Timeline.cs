﻿using System;
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
            public string itemName;

            CDTSortedSet keys;

            public TL_Timeline(TL_ENUM_Types tlType, string itemName)
            {
                this.tlType = tlType;
                this.itemName = itemName;

                keys = new CDTSortedSet();
            }

            public List<TL_Types.Key> GetKeys()
            {
                return keys.ToList();
            }

            public void SetKeys(CDTSortedSet keys)
            {
                DeleteAllKeys();

                this.keys = keys;
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

            public bool UpdateKey(TL_Types.Key key)
            {
                bool result = 0 < keys.RemoveWhere(x => x.frame == key.frame);

                if (result)
                    keys.Add(key);

                return result;
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
