using System.Collections;
using TMPro;
using UnityEngine;

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

    public GameObject SettingsPanel;
    public GameObject SeedsPanel;
    public bool gameIsPaused = false;

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

    public void showOrHideSettings()
    {
        if (gameIsPaused)
        {
            SeedsPanel.SetActive(true);
            SettingsPanel.SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
            SeedsPanel.SetActive(false);
            SettingsPanel.SetActive(true);
            gameIsPaused = true;
            Time.timeScale = 0f;
        }
    }
    public void showSettings()
    {
        SettingsPanel.SetActive(true);
    }
}