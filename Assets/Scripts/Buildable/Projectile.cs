using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float explosionRadius = 0f;
    //public GameObject impactEffect;
    public float damage = 5f;
    Vector3 offset = new Vector3(0, 1, 0);

    public void Seek(Transform target)
    {
        this.target = target;
    }



    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }


        float threshHold = 1f;
        float sqrDistToTarg = (target.position + offset - this.transform.position).sqrMagnitude; //this is how you get distance from target
        if (sqrDistToTarg < threshHold) //use this instead of Vector3.Distance its more optimized
        {
            HitTarget();
            return;
        }

        //this detects if we hit something
/*        if (Vector3.Distance(this.transform.position, target.position) <= 0.35f) //if Bullet gets withing 0.35f of target it goes into HitTarget()
        {
            HitTarget();
            return;
        }*/
        //this moves the bullet
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, target.position + offset, step);
        this.transform.LookAt(target.position + offset);
    }

    void HitTarget()
    {
        //GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        {
           /* if (explosionRadius > 0)
            {
                //print("explosionRadius");
                Explode();
            }
            else
            {

                //IDamagable damageableObject = target.GetComponent<IDamagable>();
                if (damageableObject != null)
                    damageableObject.TakeDamage(damage);
            }*/

        }
        IDamageable damageable = target.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.TakeHit(damage);
        }

        //this.transform.parent = target;
        Destroy(this.gameObject);
        //Destroy(target.gameObject);
       // Destroy(effectIns, 2f);


    }

/*    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);
        //print(colliders.Length);
        foreach (Collider collider in colliders)
        {
            if (collider.tag.CompareTo("Enemy") == 0)
            {
                IDamagable damageable = collider.GetComponent<IDamagable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damage);
                }

            }
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
