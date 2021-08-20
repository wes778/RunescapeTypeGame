using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInDistance : MonoBehaviour
{
    Transform playerT;
    AudioSource audioSource;
    float distance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerT = FindObjectOfType<WorldInteraction>().transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!audioSource.isPlaying)
        {
            if (Vector3.Distance(playerT.position, this.transform.position) <= distance)
            {
                audioSource.Play();
                audioSource.volume = .5f;
                
            } 
        }
        if(audioSource.isPlaying)
        {
            if(Vector3.Distance(playerT.position, this.transform.position) >= distance)
            {
                audioSource.Stop();
            }
            if(Vector3.Distance(playerT.position, this.transform.position) <= distance / 2)
            {
                audioSource.volume = 1f;
            }
        }
        
    }
}
