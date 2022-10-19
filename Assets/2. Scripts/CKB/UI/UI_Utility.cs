using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UI
{
    namespace Utility
    {
        public class UI_Utility
        {
            // UI 레이캐스트
            public static bool GraphicRaycast(Canvas canvas, Vector2 position)
            {
                EventSystem evtSystem = canvas.GetComponent<EventSystem>();
                GraphicRaycaster grpRaycaster = canvas.GetComponent<GraphicRaycaster>();

                PointerEventData evtData = new PointerEventData(evtSystem);
                evtData.position = position;

                List<RaycastResult> rayResults = new List<RaycastResult>();

                grpRaycaster.Raycast(evtData, rayResults);

                if (0 < rayResults.Count)
                    return true;
                else
                    return false;
            }

            // 해당 카메라의 스크린 좌표계 좌표에서 레이캐스트
            public static bool ScreenPointRaycast(Camera camera, Vector3 screenPoint, out RaycastHit hit, int layerMask = -1)
            {
                Ray ray = camera.ScreenPointToRay(screenPoint);

                return Physics.Raycast(ray, out hit, float.MaxValue, layerMask);
            }    
        }
    }
}
