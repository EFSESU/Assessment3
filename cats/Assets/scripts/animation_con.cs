using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animation_con : MonoBehaviour
{

    public float zoomSpeed = 0.4f; // 缩放速度


    private Image image; // 图片组件
    private Vector3 initialScale; // 初始缩放比例

    private void Start()
    {
        // 获取图片组件
        image = GetComponent<Image>();

        // 记录初始缩放比例
        initialScale = transform.localScale;
        StartCoroutine(ZoomIn());
    }

  

    private IEnumerator ZoomIn()
    {
        print(2222);
        yield return new WaitForSeconds(0.4f);
        // 逐渐放大图片
        while (transform.localScale.x<1)
        {
           
            // 设置图片缩放
           
            transform.localScale += new Vector3(zoomSpeed, zoomSpeed, 0f) * Time.deltaTime;
            yield return null;
        }
    }
}