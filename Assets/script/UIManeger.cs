using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManeger Instance;
    [SerializeField] private Canvas homeScrean;
    [SerializeField] private Canvas levelScrean;
    [SerializeField] private Canvas SettingbScrean;
    [SerializeField] private Canvas soundSettingScrean;
    [SerializeField] private Canvas mainMenuWinScrean;
    [SerializeField] private Canvas mainMenuLoseScrean;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        homeScrean.enabled = false;
        levelScrean.enabled = false;
        SettingbScrean.enabled = false;
        soundSettingScrean.enabled = false;
        mainMenuLoseScrean.enabled = false;
        mainMenuWinScrean.enabled = false;
    }
    void Start()
    {
        homeScrean.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelScreanCanvase()
    {
        soundMangeger.Instance.playSound(soundName.click);
        homeScrean.enabled=false;
        levelScrean.enabled=true;
    }
    public void levelButtonScreanCanvase()
    {
        soundMangeger.Instance.playSound(soundName.click);      
        levelScrean.enabled = false;
        SettingbScrean.enabled = true;
    }
  
    public void SettingbScreanCanvas()
    {
        SettingbScrean.enabled = true;
    }
    public void mainMenuScreanWinCanvas()
    {
        SettingbScrean.enabled = false;
        mainMenuWinScrean.enabled = true;
    }
    public void mainMenuScreanLoseCanvas()
    {
        SettingbScrean.enabled = false;
        mainMenuLoseScrean.enabled = true;
    }
    public void mainMenuScreanWinCanvasoff()
    {       
        mainMenuWinScrean.enabled = false;
    }
    public void soundSettingScreanCanvas()
    {
        SettingbScrean.enabled = false;
        soundSettingScrean.enabled = true;    
    }
    public void nextLevel()
    {
        mainMenuWinScrean.enabled = false;
        SettingbScrean.enabled=true;
        gameManeger.Instance.levelUp();
       
    }
    public void LevelScrean()
    {
        mainMenuLoseScrean.enabled = false;
        mainMenuWinScrean.enabled = false;
       
        levelScrean.enabled = true;
    }
    public void reloadSamescene()
    {
        SettingbScrean.enabled=true;    
        mainMenuWinScrean.enabled = false;
        mainMenuLoseScrean.enabled=false;
        collisionDetection.Instance.reloadscene();
      
    }
    public void removeMainMenuScrean()
    {
        mainMenuLoseScrean.enabled = false;
        mainMenuWinScrean.enabled = false;
    }
    public void RemoveSoundSettingCanvas()
    {
        SettingbScrean.enabled = true;
        soundSettingScrean.enabled = false;
    }
    public void pouse()
    {
        Time.timeScale = 0.0f;
    }
    public void unpouse()
    {
        Time.timeScale = 1.0f;
    }
    public void applicationQuit()
    {
        Application.Quit();
    }
}
