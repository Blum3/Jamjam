using System;
using UnityEngine;

using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Linq;
using static Tree;

public class Inventory : MonoBehaviour
{
    public Dictionary<Tree.treeTypes, int> seeds = new Dictionary<Tree.treeTypes, int>();
    public GameObject seedIconPrefab; // Reference to the seed icon prefab
    public Transform inventoryPanel; // Panel where seed icons will be displayed

    public Color defaultColor;
    public Color selectedColor;

    public UIManager ui_manager;

    private int selectedSeedIndex = 0; 

    void Start()
    {
        seeds[Tree.treeTypes.Ash] = 5;
        seeds[Tree.treeTypes.Birch] = 5;
        seeds[Tree.treeTypes.Spruce] = 5;
        seeds[Tree.treeTypes.WippingWillow] = 5;

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
            seedText.text = seed.Key.ToString() + seed.Value.ToString();

            // Get the Image component or Background component of the seed icon
            Image seedIconImage = seedIcon.GetComponent<Image>();

            // Set the default background color for all seeds
            seedIconImage.color = defaultColor;

            // Add a method to highlight the selected see
            List<Tree.treeTypes> keysList = seeds.Keys.ToList();
            if (keysList.IndexOf(seed.Key) == selectedSeedIndex)
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
        Debug.Log("Graine sélectionnée : " + this.GetSelectedSeed());
    }

    public void selectDown()
    {
        if (seeds.Count > 1)
        {
            selectedSeedIndex = (selectedSeedIndex - 1 + seeds.Count) % seeds.Count;
            UpdateSeedUI();
        }
        Debug.Log("Graine sélectionnée : " + this.GetSelectedSeed());
    }

    // Obtenir la graine actuellement sélectionnée
    public treeTypes GetSelectedSeed()
    {
        return seeds.ElementAt(selectedSeedIndex).Key;
    }

    public int GetSelectedNumber()
    {
        if (seeds.Count > 0)
        {
            return seeds.ElementAt(selectedSeedIndex).Value;
        }
        return 0;
    }



    // Supprimer une graine après plantation
    public void RemoveSelectedSeed()
    {
        if (seeds.Count > 0)
        {
            treeTypes selectedSeed = this.GetSelectedSeed();

            if (this.GetSelectedNumber() > 0)
            {
                seeds[selectedSeed] -= 1;
            }
            
           selectedSeedIndex = Mathf.Clamp(selectedSeedIndex, 0, seeds.Count - 1);
           UpdateSeedUI();
        }
    }

        // Ajouter une seed à l'inventaire
    public void AddSeed(Seed seed)
    {
        treeTypes newSeed = seed.seedType;
        if (seeds.ContainsKey(newSeed))
        {
            selectedSeedIndex = 0;

            seeds[newSeed] += 1;
            UpdateSeedUI();
        }
        else 
        {
            ui_manager.ShowError("You can\'t carry more seeds !");            
            Debug.Log("NEW SEED !!!");
            seeds.Add(newSeed, 1);
            UpdateSeedUI();
        }
    }

    public bool canPlantSeed()
    {
        if (seeds.Count > 0 && this.GetSelectedNumber() > 0)
        {
            return true;
        }
        else
        {
            ui_manager.ShowError("You don\'t have any more seeds to plant !");
            return false;
        }
    }


}
