using UnityEngine;

using System;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public Tree.treeTypes seedType;

    public Seed(Tree.treeTypes tree)
    {
        seedType = tree;
    }

}
