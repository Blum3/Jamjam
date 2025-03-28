using UnityEngine;

using System;

public class Seed : MonoBehaviour
{
    public Tree.treeTypes seedType;

    public Seed(Tree.treeTypes tree)
    {
        seedType = tree;
    }

}
