using System;
using System.Collections;
using System.Collections.Generic;

namespace Timeline
{
    namespace Utility
    {
        public class TL_Utility
        {
            // 새로운 GUID 생성
            public static string NewGuid()
            {
                return Guid.NewGuid().ToString();
            }
        }
    }
}
