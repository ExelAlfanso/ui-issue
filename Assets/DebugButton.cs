using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugButton : MonoBehaviour
{
    public Button debugButton;
    public bool sceneDestinationIsActive = false;
    public TextMeshProUGUI buttonText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonText.text = "Go to Scene 1";
        debugButton.onClick.AddListener(OnDebugButtonClicked);
    }

    void OnDebugButtonClicked()
    {
        if (sceneDestinationIsActive)
        {
            SceneManager.LoadScene("Scene1");
        }
        else
        {
            SceneManager.LoadScene("Scene2");
        }
        buttonText.text = sceneDestinationIsActive ? "Go to Scene 1" : "Go to Scene 2";
        sceneDestinationIsActive = !sceneDestinationIsActive;
    }
}
