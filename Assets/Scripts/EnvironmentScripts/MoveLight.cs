using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    public float min = .3f;
    public float max = .5f;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {


        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time / 5, max - min) + min, transform.position.z);

    }
}

