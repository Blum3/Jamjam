using TMPro;
using UnityEngine;

public class SeedIconManager : MonoBehaviour
{

    public string seedName;
    public string count;
    public TextMeshProUGUI seedNameText;
    public TextMeshProUGUI seedCountText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void updateIcon(string seedName, string seedCount)
    {
        seedNameText.text = seedName;
        seedCountText.text = seedCount;
    }

}
