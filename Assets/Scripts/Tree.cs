using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;



public class Tree : MonoBehaviour
{
    public enum treeTypes
    {
        Ash,
        Birch,
        Spruce,
        WippingWillow
    }

    public int age = 0;
    public int treeState = 0;
    public treeTypes treeType;
    public GameObject soilModel;
    public GameObject treeModel;

    public string treeBiom;
    public int growCoef = 1;
    public float altitude;
    public int maxOptimalAlt;
    public int minOptimalAlt;
    public string optimalBiom;

    [SerializeField]
    private int growInterval=10;

    [SerializeField]
    private float growSize1 = 1.2f;
    [SerializeField]
    private float growSize2 = 1.8f;

    private float randomSizeFactor;

    public void Start()
    {
        randomSizeFactor = UnityEngine.Random.Range(0.8f, 1.2f);
        altitude = transform.position.y;
        if (treeBiom != null)
        {
            if (treeType == treeTypes.Ash)
            {
                if (altitude < minOptimalAlt || altitude > maxOptimalAlt)
                {
                    growCoef /= 2;
                }
                if (treeBiom != optimalBiom)
                {
                    growCoef /= 2;
                }
            }
        }

        InvokeRepeating("grow", growInterval, growInterval);
    }

    private void grow()
    {
        age += growInterval;
        if (UnityEngine.Random.Range(0, 100) * growCoef + (age / growInterval) > 20)
        {
            treeState += 1;
            if (treeState == 1)
            {
                soilModel.SetActive(false);
                treeModel.SetActive(true);
                // update the model of the tree
            }
            if (treeState == 2)
            {
                treeModel.transform.localScale = new Vector3(growSize1*randomSizeFactor, growSize1* randomSizeFactor, growSize1 * randomSizeFactor );
                // update the model of the tree
            }
            if (treeState == 3)
            {
                treeModel.transform.localScale = new Vector3(growSize2* randomSizeFactor, growSize2 * randomSizeFactor, growSize2 * randomSizeFactor);
                // update the model of the tree
            }

        }

    }
}
