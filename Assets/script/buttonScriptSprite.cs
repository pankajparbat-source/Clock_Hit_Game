using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buttonScriptSprite : MonoBehaviour
{
    // Start is called before the first frame update
    private Sprite activeSprite;
    [SerializeField]  private Sprite unactiveSprite;
    private Image image;
    private bool isoff = true;
   private bool ispause= true;
    void Start()
    {
        image=GetComponent<Image>();
        activeSprite = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeSprite()
    {
        if (isoff)
        {
            image.sprite = unactiveSprite;
            isoff = false;

        }
        else
        {
            image.sprite = activeSprite;
            isoff = true;

        }
    }
    public void pauseunpause()
    {
        if (isoff)
        {
            Time.timeScale = 1;
            ispause = false;
        }
        else
        {
            Time.timeScale = 0;
            ispause = true;

        }
    }
}
