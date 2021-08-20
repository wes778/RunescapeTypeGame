using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRegen : MonoBehaviour
{
    public GameObject resourceToRemake;
    public int waitForSeconds;

    private void Start()
    {
        StartCoroutine(ResourceRegeneration());
    }

    IEnumerator ResourceRegeneration()
    {
        yield return new WaitForSeconds(waitForSeconds);
        Instantiate(resourceToRemake, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}
