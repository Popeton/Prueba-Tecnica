using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicShoot : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;
    [SerializeField] private Transform shootPos;
    [SerializeField] private EquipGun equip;
    private float initalVelocity =10f;
    private float angle = 45f;
    //private float g = 9.8f;

    private float radAngle;
   

    Rigidbody rb;

    void Start()
    {
        radAngle = Mathf.Deg2Rad * angle;
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && equip.equipped == true)
        {
            GameObject projectile = Instantiate(proyectilePrefab, shootPos.position, Quaternion.identity);
            rb = projectile.GetComponent<Rigidbody>();


            float v0x = initalVelocity * Mathf.Cos(radAngle);
            float v0y = initalVelocity * Mathf.Sin(radAngle);

            rb.velocity = new Vector3(v0x,v0y, 0);

            Destroy(projectile, 5f);

        }
        
    }

    
}
