using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class img_manager : MonoBehaviour
{

   // public List<Texture2D> allTex2d = new List<Texture2D>();

    public List<GameObject> rawImages = new List<GameObject>();
    public List<AudioClip> a_clip = new List<AudioClip>();
    public List<string> texts = new List<string>();
    public List<GameObject> ani = new List<GameObject>();


    public AudioSource audioSource;
    public AudioSource bgm_audioSource;

    public Text zimu_text;
    public float zoomSpeed = 0.4f; // 缩放速度


    public RawImage img;
    int i = 0;
    public void bgm_()
    {
        if (bgm_audioSource.isPlaying)
        {
            bgm_audioSource.Pause();
        }
        else
        {
            bgm_audioSource.Play();
        }
    }
    public void next_img()
    {
        if (i >= rawImages.Count - 1)
        {
            
        }
        else
        {
            hide();
          
            audioSource.Stop();
            rawImages[i + 1].SetActive(true);
            audioSource.PlayOneShot(a_clip[i + 1]);
            zimu_text.text = texts[i + 1];
           
            i++;
        }
    }
    public void pre_img()
    {
        if (i ==0)
        {
           
        }
        else
        {
            hide();
           
            audioSource.Stop();
            rawImages[i - 1].SetActive(true);
            audioSource.PlayOneShot(a_clip[i -1]);
            zimu_text.text = texts[i - 1];
          
            i--;
        }
    }
    public void to_home()
    {
        hide();
      
        audioSource.Stop();
        rawImages[0].SetActive(true);
        audioSource.PlayOneShot(a_clip[0]);
        zimu_text.text = texts[0];
       

        i = 0;
    }
    private void Start()
    {
        hide();
        rawImages[0].SetActive(true);
        audioSource.PlayOneShot(a_clip[i]);
        zimu_text.text = texts[i];
      
      

    }
    public float min_scale=0.3f;
    void hide()
    {
        foreach(GameObject gameObject in rawImages)
        {
            gameObject.SetActive(false);  
            foreach(Transform child in gameObject.transform)
            {
                child.localScale = new Vector3(min_scale, min_scale, 1);
            }
            
        }
       
    }
    private IEnumerator ZoomIn( int i)
    {

        // 逐渐放大图片
        while (ani[i].transform.localScale.x < 1)
        {
            ani[i].transform.localScale += new Vector3(zoomSpeed, zoomSpeed, 0f) * Time.deltaTime;
            yield return null;
        }
    }

}
