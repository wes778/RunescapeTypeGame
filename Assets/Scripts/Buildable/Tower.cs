using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;
    [Header("Attributes")]
    public float range = 15f;

    public float fireFate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public Transform partToRotate;

    public GameObject projectilePrefab;
    public Transform firePoint;
    TowerRotate towerRotate;
    //public GameObject crossbow;

    void Start()
    {
        towerRotate = GetComponentInChildren<TowerRotate>();
        InvokeRepeating("UpdateTarget", 0, .25f);
    }

    void UpdateTarget()
    {
        //this grabs all enemies on map puts them in an array and then locks onto the closest one
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);


        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //this will find the closest enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            
            target = nearestEnemy.transform;
            
        }
        else
        {
            target = null;
            towerRotate.RemoveTarget();
        }
    }


    void Update()
    {
        if (target == null)
            return;

        towerRotate.SetTarget(target);
        //this is to get the turret to look in the direction of enemy
        //Vector3 dir = target.position - transform.position;
        // Debug.DrawRay(transform.position, dir, Color.green);
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        // partToRotate.rotation = Quaternion.Slerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed);
        //partToRotate.transform.LookAt(target);

        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireFate;
        }
        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile bullet = projectile.GetComponent<Projectile>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
