using System;
using System.Collections.Generic;
using UnityEngine;



public class Tree : MonoBehaviour
{
    public enum treeTypes
    {
        oak,
        pine
    }

    public int age = 0;
    public int treeState = 0;
    public treeTypes treeType;
    public GameObject model1;
    public GameObject model2;
    public GameObject model3;
    public string treeBiom;
    public int growCoef;
    public float altitude;
    public int maxOptimalAlt;
    public int minOptimalAlt;
    public string optimalBiom;

    



    
    public void Start()
    {
        growCoef = 1;
        altitude = transform.position.y;
        if (treeBiom != null)
        {
            if (treeType == treeTypes.oak)
            {
                if (altitude < minOptimalAlt && altitude > maxOptimalAlt)
                {
                    growCoef /= 2;
                }
                if (treeBiom != optimalBiom)
                {
                    growCoef /= 2;
                }
            }
        }

        InvokeRepeating("grow", 10, 10);
    }

    private void grow()
    {
        age += 10;
        if (UnityEngine.Random.Range(0, 100) * growCoef + (age / 10) > 20)
        {
            treeState += 1;
            if (treeState == 1)
            {
                model1.SetActive(false);
                model2.SetActive(true);
                // update the model of the tree
            }
            if (treeState == 2)
            {
                model2.SetActive(false);
                model3.SetActive(true);
                // update the model of the tree
            }
            // Debug.Log(treeState);

        }
        else
        {
            // Debug.Log("not growing");
        }
    }
}
