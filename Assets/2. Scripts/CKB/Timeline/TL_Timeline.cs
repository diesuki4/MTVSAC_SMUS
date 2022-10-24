using System;
using System.Collections;
using System.Collections.Generic;
using Timeline.Types;

namespace Timeline
{
    namespace Timeline
    {
        [Serializable]
        public class TL_Timeline
        {
            TL_ENUM_Types tlType;
            int itemIdx;

            List<TL_Types.Key> keys = new List<TL_Types.Key>();

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
        }
    }
}
