using System;
using System.Collections;
using System.Collections.Generic;

namespace Timeline
{
    namespace Utility
    {
        public class TL_Utility
        {
            static List<string> guids = new List<string>();

            // 새로운 GUID 생성
            public static string NewGuid()
            {
                string guid;

                while (isGuidExist(guid = Guid.NewGuid().ToString()));

                return guid;
            }

            // 같은 GUID 가 존재하는지 확인
            static bool isGuidExist(string guid)
            {
                return guids.Contains(guid);
            }
        }
    }
}
