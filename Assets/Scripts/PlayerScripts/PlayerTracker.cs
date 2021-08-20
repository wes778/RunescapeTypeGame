using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    public Transform playerTransform;
    public static PlayerTracker instance;

    private void Awake()
    {
        instance = this;
    }
}
