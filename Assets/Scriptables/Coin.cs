using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "New Coin", menuName = "Coin")]


public class Coin : ScriptableObject
{
    public Material coinMaterial;
    public int coinValue;
    public int coinTime;
}
