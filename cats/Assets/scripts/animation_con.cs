using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animation_con : MonoBehaviour
{

    public float zoomSpeed = 0.4f; // �����ٶ�


    private Image image; // ͼƬ���
    private Vector3 initialScale; // ��ʼ���ű���

    private void Start()
    {
        // ��ȡͼƬ���
        image = GetComponent<Image>();

        // ��¼��ʼ���ű���
        initialScale = transform.localScale;
        StartCoroutine(ZoomIn());
    }

  

    private IEnumerator ZoomIn()
    {
        print(2222);
        yield return new WaitForSeconds(0.4f);
        // �𽥷Ŵ�ͼƬ
        while (transform.localScale.x<1)
        {
           
            // ����ͼƬ����
           
            transform.localScale += new Vector3(zoomSpeed, zoomSpeed, 0f) * Time.deltaTime;
            yield return null;
        }
    }
}