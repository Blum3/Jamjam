using System;
using UnityEngine;

using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Seed> seeds = new List<Seed>(); 
    private int selectedSeedIndex = 0; 

    void Start()
    {
        seeds.Add(new Seed(Tree.treeTypes.oak));
        seeds.Add(new Seed(Tree.treeTypes.pine));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("LEFT");
            selectedSeedIndex = (selectedSeedIndex - 1 + seeds.Count) % seeds.Count;
            Debug.Log("Graine s�lectionn�e : " + seeds[selectedSeedIndex].seedType);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("RIGHT");
            selectedSeedIndex = (selectedSeedIndex + 1) % seeds.Count;
            Debug.Log("Graine s�lectionn�e : " + seeds[selectedSeedIndex].seedType);
        }

        // Afficher la graine s�lectionn�e
        if (seeds.Count > 0)
        {
            // Debug.Log("Graine s�lectionn�e : " + seeds[selectedSeedIndex].seedType);
        }
    }

    // Obtenir la graine actuellement s�lectionn�e
    public Seed GetSelectedSeed()
    {
        if (seeds.Count > 0)
        {
            return seeds[selectedSeedIndex];
        }
        return null;
    }

    // Supprimer une graine apr�s plantation
    public void RemoveSelectedSeed()
    {
        if (seeds.Count > 0)
        {
            seeds.RemoveAt(selectedSeedIndex);
            selectedSeedIndex = Mathf.Clamp(selectedSeedIndex, 0, seeds.Count - 1);
        }
    }
}
