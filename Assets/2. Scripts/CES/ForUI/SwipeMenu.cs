using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;
    Canvas[] canvass;

    public float bigScale = 1.2f;
    public float smallScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pos 배열의 사이즈 = 배너 콘텐츠의 자식 개수
        pos = new float[transform.childCount];
        // canvass 배열의 사이즈 = pos의 사이즈
        canvass = new Canvas[pos.Length];
        // 넘길 거리? 넘겼을 때 인식하는 거리
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            // 첫번째 애의 위치 = 거리 * i
            pos[i] = distance * i;
            // i의 캔버스 - sortLayer 바꿔주려고
            canvass[i] = transform.GetChild(i).GetComponent<Canvas>();
        }

        // 만약 마우스 눌렀으면
        if (Input.GetMouseButton(0))
        {
            // 스크롤 포스 = 스크롤바 값
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        // 그렇지 않으면
        else
        {
            // 반복
            for (int i = 0; i < pos.Length; i++)
            {
                // 만약  스크롤 포스 값이    i번째 애의 위치 + ( 버튼 하나의 범위 / 2) 보다 작거나
                //            스크롤 포스 값이    i번째 애의 위치 - (버튼 하나의 범위 / 2) 보다 크면
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    // 스크롤바 값 = 지금 값부터 i번째 애의 위치까지 Lerp
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }



        // 또 반복
        for (int i = 0; i < pos.Length; i++)
        {
            // 만약  스크롤 포스 값이    i번째 애의 위치 + ( 버튼 하나의 범위 / 2) 보다 작거나
            //            스크롤 포스 값이    i번째 애의 위치 - (버튼 하나의 범위 / 2) 보다 크면
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                // 콘텐트의 i번째 자식의 스케일 = 지금 스케일에서 큰 스케일까지 Lerp로 키워
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(bigScale, bigScale), 0.1f);
                // sortLayer은 20으로 맞춰 - 앞에서 보이게
                canvass[i].sortingOrder = 20;
                // 또 반복
                for (int a = 0; a < pos.Length; a++)
                {
                    // 만약 a가 i와 다르다면
                    if (a != i)
                    {
                        // i번째가 아니면 스케일 작게, sortLayer는 19로 뒤에 가려지게
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(smallScale, smallScale), 0.1f);
                        canvass[a].sortingOrder = 19;   
                    }
                }

                // 4번째 애가 가운데에 있는 상태에서 왼쪽으로 밀면 1번째 애가 7번이 돼야 함
                // 4번째 애가 가운데에 있는 상태에서 오른쪽으로 밀면 7번째 애가 1번이 돼야 함
                // 하기싫어 그냥

                // 배열로 자식 싹 가져온 다음에 i == 4번째 애가 맞는지 확인하셈

            }
        }





    }
}
