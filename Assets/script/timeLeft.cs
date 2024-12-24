using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeLeft : MonoBehaviour
{
    // Start is called before the first frame update
    //private float[] timeForLevel = {0,7,15,20,25,30,35,30,35,40 };
    [SerializeField] private GUIStyle ui;
    int levelIndex;
    private string stringToEdit;
    void Start()
    {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        //timeForLevel[levelIndex] -= Time.deltaTime;
        //int timeLeftInt = Mathf.RoundToInt(timeForLevel[levelIndex]);
        //stringToEdit="Time Left : "+timeLeftInt.ToString();
        //if (timeLeftInt < 1)
        //{
        //    SceneManager.LoadScene(levelIndex);
        //}
       

    }
    void OnGUI()
    {
        // Make a multiline text area that modifies stringToEdit.
      //  GUI.backgroundColor = Color.white;
     //   stringToEdit = GUI.TextArea(new Rect(20, 30, 300, 150), stringToEdit, 200,ui);
    }
}
