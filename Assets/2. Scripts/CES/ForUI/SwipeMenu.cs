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
        // pos �迭�� ������ = ��� �������� �ڽ� ����
        pos = new float[transform.childCount];
        // canvass �迭�� ������ = pos�� ������
        canvass = new Canvas[pos.Length];
        // �ѱ� �Ÿ�? �Ѱ��� �� �ν��ϴ� �Ÿ�
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            // ù��° ���� ��ġ = �Ÿ� * i
            pos[i] = distance * i;
            // i�� ĵ���� - sortLayer �ٲ��ַ���
            canvass[i] = transform.GetChild(i).GetComponent<Canvas>();
        }

        // ���� ���콺 ��������
        if (Input.GetMouseButton(0))
        {
            // ��ũ�� ���� = ��ũ�ѹ� ��
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        // �׷��� ������
        else
        {
            // �ݺ�
            for (int i = 0; i < pos.Length; i++)
            {
                // ����  ��ũ�� ���� ����    i��° ���� ��ġ + ( ��ư �ϳ��� ���� / 2) ���� �۰ų�
                //            ��ũ�� ���� ����    i��° ���� ��ġ - (��ư �ϳ��� ���� / 2) ���� ũ��
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    // ��ũ�ѹ� �� = ���� ������ i��° ���� ��ġ���� Lerp
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }



        // �� �ݺ�
        for (int i = 0; i < pos.Length; i++)
        {
            // ����  ��ũ�� ���� ����    i��° ���� ��ġ + ( ��ư �ϳ��� ���� / 2) ���� �۰ų�
            //            ��ũ�� ���� ����    i��° ���� ��ġ - (��ư �ϳ��� ���� / 2) ���� ũ��
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                // ����Ʈ�� i��° �ڽ��� ������ = ���� �����Ͽ��� ū �����ϱ��� Lerp�� Ű��
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(bigScale, bigScale), 0.1f);
                // sortLayer�� 20���� ���� - �տ��� ���̰�
                canvass[i].sortingOrder = 20;
                // �� �ݺ�
                for (int a = 0; a < pos.Length; a++)
                {
                    // ���� a�� i�� �ٸ��ٸ�
                    if (a != i)
                    {
                        // i��°�� �ƴϸ� ������ �۰�, sortLayer�� 19�� �ڿ� ��������
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(smallScale, smallScale), 0.1f);
                        canvass[a].sortingOrder = 19;   
                    }
                }

                // 4��° �ְ� ����� �ִ� ���¿��� �������� �и� 1��° �ְ� 7���� �ž� ��
                // 4��° �ְ� ����� �ִ� ���¿��� ���������� �и� 7��° �ְ� 1���� �ž� ��
                // �ϱ�Ⱦ� �׳�

                // �迭�� �ڽ� �� ������ ������ i == 4��° �ְ� �´��� Ȯ���ϼ�

            }
        }





    }
}
