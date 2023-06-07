using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{

    [SerializeField] private float attractionForce;
    [SerializeField] private float attractionRadius;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootPos;
    [SerializeField] private EquipGun equip;
    private GameObject currentProjectile;  

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentProjectile == null && equip.equipped == true)
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        
        currentProjectile = Instantiate(projectilePrefab, shootPos.position, Quaternion.identity);

        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.right * 1000f);
        }
    }

    private void FixedUpdate()
    {
        if (currentProjectile != null)
        {
            
            Collider[] colliders = Physics.OverlapSphere(currentProjectile.transform.position, attractionRadius);

            foreach (Collider collider in colliders)
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();

                if (rb != null && rb != currentProjectile.GetComponent<Rigidbody>())
                {
                    
                    Vector3 direction = currentProjectile.transform.position - collider.transform.position;
                    rb.AddForce(direction.normalized * attractionForce);
                }
            }

            Destroy(currentProjectile, 3f);
        }
    }

}
