using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tipText;

    [SerializeField]
    private TextMeshProUGUI messageText;

    [SerializeField]
    private float messageDuration = 3f; // Duration in seconds

    [Tooltip("The Crosshair to activate when the player can plant")]
    public GameObject PlantCrosshair;
    [Tooltip("The Crosshair to activate when the player can grab")]
    public GameObject GrabCrosshair;

    public GameObject PauseMenuPanel;
    public GameObject SeedsPanel;
    public GameObject ControlsPanel;
    public Button ResumeButton;
    public bool gameIsPaused = true;

    public FirstPersonController FirstPersonController;

    private Coroutine messageCoroutine; // Store coroutine to stop if needed



    public void ShowTip(string text)
    {
        tipText.text = text;
        tipText.enabled = true;
    }

    public void HideTip()
    {
        tipText.enabled = false;
    }

    public void showGrabElements()
    {
        //ShowTip("[E]");
        GrabCrosshair.SetActive(true);
        PlantCrosshair.SetActive(false);
    }

    public void showPlantElements()
    {
        //ShowTip("[Left Mouse Button]");
        GrabCrosshair.SetActive(false);
        PlantCrosshair.SetActive(true);
    }
    public void hideAllElements()
    {
        HideTip();
        GrabCrosshair.SetActive(false);
        PlantCrosshair.SetActive(false);
    }

    public void ShowMessage(string text)
    {
        Debug.Log(text);

        // If a tip is already showing, restart the coroutine
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messageCoroutine = StartCoroutine(ShowMessageCoroutine(text));
    }

    private IEnumerator ShowMessageCoroutine(string text)
    {
        messageText.text = text;
        messageText.enabled = true;

        yield return new WaitForSeconds(messageDuration);

        messageText.enabled = false;
    }

    public void PausingOrResumingGame()
    {
        if (gameIsPaused)
        {
            Debug.Log("resuming game");
            SeedsPanel.SetActive(true);
            PauseMenuPanel.SetActive(false);
            ControlsPanel.SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Debug.Log("pausing game");
            Cursor.lockState = CursorLockMode.Confined;  
            SeedsPanel.SetActive(false);
            PauseMenuPanel.SetActive(true);
            ResumeButton.Select();
            gameIsPaused = true;
            Time.timeScale = 0f;
        }
    }
    public void showSettings()
    {
        PauseMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting the game");
    }
}