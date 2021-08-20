using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotate : MonoBehaviour
{
    public Transform target;
    Quaternion startRotation;
    // Start is called before the first frame update

    private void Start()
    {
        startRotation = transform.rotation;
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void RemoveTarget()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            Vector3 offset = new Vector3(0, 1, 0);
            Vector3 lookDir = target.position + offset - transform.position;
            Debug.DrawRay(transform.position, lookDir, Color.green);
            Quaternion directionToLook = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, directionToLook, Time.deltaTime * 3);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, startRotation, Time.deltaTime * 3);
        }
        
    }
}
