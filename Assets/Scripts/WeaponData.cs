using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float ammunition;
    public Color weaponColor;
    //public GameObject projectilePrefab;
   
}
