using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string nextScene;

    void Update()
    {
        // Check for scene transition key (Z key in this case)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
