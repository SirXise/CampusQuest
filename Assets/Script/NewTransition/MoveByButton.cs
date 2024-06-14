using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveByButton : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    int storeData = 0;
    int storeData1 = 0;
    int storeData2 = 0;
    int storeData3 = 0;
    int storeData4 = 0;
    int storeData5 = 0;
    string dataStoreName = "TutorialCanvas";
    string dataStoreName1 = "RoommateQuest";
    string dataStoreName2 = "CafeQuest";
    string dataStoreName3 = "LibraryQuest";
    string dataStoreName4 = "Maze1Quest";
    string dataStoreName5 = "Maze2Quest";

    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject Panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(Panel, 1);
        }
    }

    public void MoveToGame(string sceneName)
    {
        playerStorage.initialValue = playerPosition;
        if (sceneToLoad == "scene1")
        {
            storeData = PlayerPrefs.GetInt(dataStoreName, 0);
            storeData1 = PlayerPrefs.GetInt(dataStoreName, 0);
            storeData2 = PlayerPrefs.GetInt(dataStoreName, 0);
            storeData3 = PlayerPrefs.GetInt(dataStoreName, 0);
            storeData4 = PlayerPrefs.GetInt(dataStoreName, 0);
            storeData5 = PlayerPrefs.GetInt(dataStoreName, 0);

            PlayerPrefs.SetInt(dataStoreName, 0);
            PlayerPrefs.SetInt(dataStoreName1, 0);
            PlayerPrefs.SetInt(dataStoreName2, 0);
            PlayerPrefs.SetInt(dataStoreName3, 0);
            PlayerPrefs.SetInt(dataStoreName4, 0);
            PlayerPrefs.SetInt(dataStoreName5, 0);
        }
        StartCoroutine(FadeCoroutine());
    }

    public IEnumerator FadeCoroutine()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
