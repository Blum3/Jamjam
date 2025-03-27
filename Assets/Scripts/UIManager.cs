using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI tipText;

    public void showTip(string text)
    {
        Debug.Log(text);
        tipText.text = text;
        tipText.enabled = true;
    }
}
