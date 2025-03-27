using System;
using UnityEngine;

using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Seed> seeds = new List<Seed>();
    public GameObject seedIconPrefab; // Reference to the seed icon prefab
    public Transform inventoryPanel; // Panel where seed icons will be displayed

    public Color defaultColor;
    public Color selectedColor;

    public UIManager ui_manager;

    private int selectedSeedIndex = 0; 

    void Start()
    {
        seeds.Add(new Seed(Tree.treeTypes.oak));
        seeds.Add(new Seed(Tree.treeTypes.pine));
        seeds.Add(new Seed(Tree.treeTypes.pine));

        // Initialize UI to display seeds
        UpdateSeedUI();
    }

    // Method to update the seed icons in the UI
    void UpdateSeedUI()
    {
        // Clear any existing icons first
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        // Create an icon for each seed in the list
        foreach (var seed in seeds)
        {
            // Instantiate the UI prefab for each seed
            GameObject seedIcon = Instantiate(seedIconPrefab, inventoryPanel);

            // change the text (should be in ui manager)
            TextMeshProUGUI seedText = seedIcon.GetComponentInChildren<TextMeshProUGUI>();
            seedText.text = seed.seedType.ToString();

            // Get the Image component or Background component of the seed icon
            Image seedIconImage = seedIcon.GetComponent<Image>();

            // Set the default background color for all seeds
            seedIconImage.color = defaultColor;

            // Add a method to highlight the selected seed
            if (seeds.IndexOf(seed) == selectedSeedIndex)
            {
                // Highlight the selected seed
                seedIconImage.color = selectedColor;
            }
        }


    }

    public void selectUp()
    {
        selectedSeedIndex = (selectedSeedIndex + 1) % seeds.Count;
        if (seeds.Count >1)
        {
            selectedSeedIndex = (selectedSeedIndex + 1 + seeds.Count) % seeds.Count;
            UpdateSeedUI();
        }
        Debug.Log("Graine sélectionnée : " + seeds[selectedSeedIndex].seedType);
    }

    public void selectDown()
    {
        if (seeds.Count > 1)
        {
            selectedSeedIndex = (selectedSeedIndex - 1 + seeds.Count) % seeds.Count;
            UpdateSeedUI();
        }
        Debug.Log("Graine sélectionnée : " + seeds[selectedSeedIndex].seedType);
    }

    // Obtenir la graine actuellement sélectionnée
    public Seed GetSelectedSeed()
    {
        if (seeds.Count > 0)
        {
            return seeds[selectedSeedIndex];
        }
        return null;
    }

    // Supprimer une graine après plantation
    public void RemoveSelectedSeed()
    {
        if (seeds.Count > 0)
        {
            seeds.RemoveAt(selectedSeedIndex);
            selectedSeedIndex = Mathf.Clamp(selectedSeedIndex, 0, seeds.Count - 1);
            UpdateSeedUI();
        }
    }

    // Ajouter une seed à l'inventaire
    public void AddSeed(Seed seed)
    {
        selectedSeedIndex = 0;
        seeds.Add(seed);
        UpdateSeedUI();
    }

    public bool canGrabSeed()
    {
        if (seeds.Count < 10)
        {
            return true;
        }
        else
        {
            ui_manager.showTip("You can\'t carry more seeds !");
            return false;
        }
    }

    public bool canPlantSeed()
    {
        if (seeds.Count > 0)
        {
            return true;
        }
        else
        {
            ui_manager.showTip("You don\'t have any more seeds to plant !");
            return false;
        }
    }


}
