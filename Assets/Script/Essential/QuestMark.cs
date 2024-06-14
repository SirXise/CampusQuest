using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMark : MonoBehaviour
{
    public GameObject questMark;

    public string currentScene;

    public int set;

    int storeData1 = 0;
    int storeData2 = 0;
    int storeData3 = 0;
    int storeData4 = 0;
    int storeData5 = 0;

    string dataStoreName1 = "RoommateQuest";
    string dataStoreName2 = "CafeQuest";
    string dataStoreName3 = "LibraryQuest";
    string dataStoreName4 = "Maze1Quest";
    string dataStoreName5 = "Maze2Quest";
    private void Awake()
    {
        
        if (currentScene == "room")
        {
            storeData1 = PlayerPrefs.GetInt(dataStoreName1, 0);
            questMark.SetActive(storeData1 == 0);
        }
        else if (currentScene == "cafe")
        {
            storeData2 = PlayerPrefs.GetInt(dataStoreName2, 0);
            questMark.SetActive(storeData2 == 0);
        }
        else if (currentScene == "library")
        {
            storeData3 = PlayerPrefs.GetInt(dataStoreName3, 0);
            questMark.SetActive(storeData3 == 0);
        }
        else if (currentScene == "maze1")
        {
            storeData4 = PlayerPrefs.GetInt(dataStoreName4, 0);
            questMark.SetActive(storeData4 == 0);
        }
        else if (currentScene == "maze2")
        {
            storeData5 = PlayerPrefs.GetInt(dataStoreName5, 0);
            questMark.SetActive(storeData5 == 0);
        }
    }

    public void Change()
    {
        if (set == 0)
        {
            PlayerPrefs.SetInt(dataStoreName1, 1);
        }
        else if (set == 1)
        {
            PlayerPrefs.SetInt(dataStoreName2, 1);
        }
        else if (set == 2)
        {
            PlayerPrefs.SetInt(dataStoreName3, 1);
        }
        else if (set == 3)
        {
            PlayerPrefs.SetInt(dataStoreName4, 1);
        }
        else if (set == 4)
        {
            PlayerPrefs.SetInt(dataStoreName5, 1);
        }
    }
}
