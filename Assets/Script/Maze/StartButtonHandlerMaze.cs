using UnityEngine;

public class StartButtonHandlerMaze : MonoBehaviour
{
    public GameObject panel;

    public void OnStartButtonClick()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}
