using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsiveForce : MonoBehaviour
{
    [SerializeField] private float bounceForce;
    [SerializeField] private float bounceRadius;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPos;
    [SerializeField] private EquipGun equip;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && equip.equipped == true)
        {
            Fire();
        }
    }

    private void Fire()
    {
      
        GameObject projectile = Instantiate(projectilePrefab, shootPos.position, transform.rotation);
        Rigidbody rbi = projectile.GetComponent<Rigidbody>();
        if (rbi != null)
        {
            rbi.AddForce(transform.right * 1000f);  
        }

       
        Collider[] colliders = Physics.OverlapSphere(projectile.transform.position, bounceRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
              
                Vector3 direction = collider.transform.position - projectile.transform.position;
                rb.AddForce(direction.normalized * bounceForce, ForceMode.Impulse);
            }
        }

        Destroy(projectile, 3f);
    }
}
