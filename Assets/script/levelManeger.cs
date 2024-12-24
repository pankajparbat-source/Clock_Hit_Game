using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelManeger : MonoBehaviour
{
    // Start is called before the first frame update
  [SerializeField] private  Button[] buttons;
    private void Awake()
    {
        int unlocade = PlayerPrefs.GetInt("UnLockedLevel",1);
        for(int index=0;index<buttons.Length;index++)
        {
            buttons[index].interactable = false;
        }
        for (int index = 0; index < unlocade; index++)
        {
            buttons[index].interactable = true;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelButton(int val)
    {
        UIManeger.Instance.levelButtonScreanCanvase();
        soundMangeger.Instance.playSound(soundName.click);
        SceneManager.LoadScene(val);
    }
}
