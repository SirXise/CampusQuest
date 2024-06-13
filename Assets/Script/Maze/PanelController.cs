using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject tutorialPanel;

    public void OnHelpButtonClick()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true); // Open the tutorial panel
        }
    }
}
