using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipGun : MonoBehaviour
{
    public bool equipped = false;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Transform weaponSlot;
    [SerializeField] private WeaponData[] weaponDataArray;
    [SerializeField] private TMP_Text [] weaponDatas;
    private WeaponData currentWeaponData;
    private GameObject currentWeapon;
    private int currentWeaponIndex;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchToNextWeapon();
        }
    }

    private void SwitchToNextWeapon()
    {
        UnequipCurrentWeapon();
        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        EquipWeapon(currentWeaponIndex);
    }

    private void EquipWeapon(int index)
    {
        currentWeapon = Instantiate(weapons[index], weaponSlot);
        currentWeapon.gameObject.SetActive(true);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
        currentWeapon.transform.position = weaponSlot.transform.position;
        currentWeapon.transform.rotation = weaponSlot.transform.rotation;
        currentWeapon.transform.SetParent(weaponSlot);

        Renderer weaponRenderer = currentWeapon.GetComponentInChildren<Renderer>();
        weaponRenderer.material.color = weaponDataArray[index].weaponColor;

        weaponDatas[2].text = weaponDataArray[index].weaponName;
        weaponDatas[1].text = weaponDataArray[index].damage.ToString();
        weaponDatas[0].text = weaponDataArray[index].ammunition.ToString();
        equipped = true;
    }

    private void UnequipCurrentWeapon()
    {
        if (currentWeapon != null)
        {
        
            Destroy(currentWeapon);
        }
    }
}
