using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuItem : MonoBehaviour
{
    [HideInInspector] public Image img;
    [HideInInspector] public RectTransform rectTrans;

    //SettingsMenu reference
    settingMenu settingsMenu;

    //item button
    Button button;

    //index of the item in the hierarchy
    int index;

    void Awake()
    {
        img = GetComponent<Image>();
        rectTrans = GetComponent<RectTransform>();

        settingsMenu = rectTrans.parent.GetComponent<settingMenu>();

        ////-1 to ignore the main button
        //index = rectTrans.GetSiblingIndex() - 1;

        ////add click listener
        //button = GetComponent<Button>();

    }

    
}
