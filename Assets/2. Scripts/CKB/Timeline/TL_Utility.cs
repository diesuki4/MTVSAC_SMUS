using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timeline.Types;
using Timeline.Timeline;

namespace Timeline
{
    namespace Utility
    {
        public class TL_Utility
        {
            public static string NewGuid()
            {
                return Guid.NewGuid().ToString();
            }

// [CDATA] ㅡㅡㅡㅡㅡ
// 3 (오브젝트 개수)
//
// aaaa-bbbb-cccc-dddd (GUID)
// Object (오브젝트 종류)
// chair (오브젝트 이름)
// 2 (키 개수)
// 315 (프레임)
// false (active)
// 30, 40, 50 (position)
// 1, 2, 3, 4 (rotation)
// 420 (프레임)
// true (active)
// 10, 20, 30 (position)
// 5, 6, 7, 8 (rotation)
//
// eeee-ffff-gggg-hhhh (GUID)
// Light (오브젝트 종류)
// directional (오브젝트 이름)
// 1 (키 개수)
// 22 (프레임)
// true (active)
// 66, 430, 520 (position)
// 0, 0, 0, 1 (rotation)
//
// ...

            public static string ToCDATA(Dictionary<string, TL_Timeline> timelines)
            {
                string cdata = "";

                cdata += ToLine(timelines.Count);

                foreach (KeyValuePair<string, TL_Timeline> pair in timelines)
                {
                    string guid = pair.Key;
                    TL_Timeline timeline = pair.Value;
                    List<TL_Types.Key> keys = timeline.GetKeys();

                    cdata += ToLine(guid);
                    cdata += ToLine((int)timeline.tlType);
                    cdata += ToLine(timeline.itemName);

                    cdata += ToLine(keys.Count);

                    foreach (TL_Types.Key key in keys)
                    {
                        cdata += ToLine(key.frame);
                        cdata += ToLine(key.active);
                        cdata += ToLine(key.position);
                        cdata += ToLine(key.rotation);
                    }
                }

                return cdata;
            }

            static string ToLine(string s)     { return s + Environment.NewLine; }
            static string ToLine(int i)        { return i + Environment.NewLine; }
            static string ToLine(float f)      { return f + Environment.NewLine; }
            static string ToLine(bool b)       { return b + Environment.NewLine; }
            static string ToLine(Vector3 v)    { return v.x + "," + v.y + "," + v.z + Environment.NewLine; }
            static string ToLine(Quaternion q) { return q.x + "," + q.y + "," + q.z + "," + q.w + Environment.NewLine; }

            public static Dictionary<string, TL_Timeline> FromCDATA(string cdata)
            {
                Dictionary<string, TL_Timeline> timelines = new Dictionary<string, TL_Timeline>();
                StringReader sr = new StringReader(cdata);

                int timelinesCount = ToInt(sr.ReadLine());

                for (int i = 0; i < timelinesCount; ++i)
                {
                    string guid = sr.ReadLine();
                    TL_ENUM_Types tlType = (TL_ENUM_Types)ToInt(sr.ReadLine());
                    string itemName = sr.ReadLine();

                    timelines[guid] = new TL_Timeline(tlType, itemName);

                    int keysCount = ToInt(sr.ReadLine());

                    for (int j = 0; j < keysCount; ++j)
                    {
                        int frame = ToInt(sr.ReadLine());
                        bool active = ToBool(sr.ReadLine());
                        Vector3 position = ToVector3(sr.ReadLine());
                        Quaternion rotation = ToQuaternion(sr.ReadLine());

                        timelines[guid].AddKey(new TL_Types.Key(frame, active, position, rotation));
                    }
                }

                return timelines;
            }

            static int          ToInt(string s)     { return int.Parse(s); }
            static float        ToFloat(string s)   { return float.Parse(s); }
            static bool         ToBool(string s)    { return bool.Parse(s); }
            static Vector3      ToVector3(string s)
            {
                float[] t = s.Split(',').Select(x => ToFloat(x)).ToArray();

                return new Vector3(t[0], t[1], t[2]);
            }
            static Quaternion   ToQuaternion(string s)
            {
                float[] t = s.Split(',').Select(x => ToFloat(x)).ToArray();

                return new Quaternion(t[0], t[1], t[2], t[3]);
            }            
        }
    }
}
