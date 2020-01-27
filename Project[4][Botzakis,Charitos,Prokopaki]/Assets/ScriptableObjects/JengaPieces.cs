using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JengaData", menuName = "Pieces/List")]
public class JengaPieces : ScriptableObject
{
    // public GameObject[] jengaPieces = new GameObject[36];
    public Material[] selectedMaterialsArray = new Material[2];
    public Material[] defaultMaterialsArray = new Material[2];
}
