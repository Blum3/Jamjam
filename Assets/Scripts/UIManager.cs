using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tipText;

    [SerializeField]
    private TextMeshProUGUI errorText;

    [SerializeField]
    private float errorDuration = 3f; // Duration in seconds

    [Tooltip("The Crosshair to activate when the player can plant")]
    public GameObject PlantCrosshair;
    [Tooltip("The Crosshair to activate when the player can grab")]
    public GameObject GrabCrosshair;

    public GameObject SettingsPanel;
    public bool gameIsPaused = false;

    private Coroutine errorCoroutine; // Store coroutine to stop if needed

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
        ShowTip("[E]");
        GrabCrosshair.SetActive(true);
        PlantCrosshair.SetActive(false);
    }

    public void showPlantElements()
    {
        ShowTip("[Left Mouse Button]");
        GrabCrosshair.SetActive(false);
        PlantCrosshair.SetActive(true);
    }
    public void hideAllElements()
    {
        HideTip();
        GrabCrosshair.SetActive(false);
        PlantCrosshair.SetActive(false);
    }

    public void ShowError(string text)
    {
        Debug.Log(text);

        // If a tip is already showing, restart the coroutine
        if (errorCoroutine != null)
        {
            StopCoroutine(errorCoroutine);
        }

        errorCoroutine = StartCoroutine(ShowErrorCoroutine(text));
    }

    private IEnumerator ShowErrorCoroutine(string text)
    {
        errorText.text = text;
        errorText.enabled = true;

        yield return new WaitForSeconds(errorDuration);

        errorText.enabled = false;
    }

    public void showOrHideSettings()
    {
        if (gameIsPaused)
        {
            SettingsPanel.SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
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