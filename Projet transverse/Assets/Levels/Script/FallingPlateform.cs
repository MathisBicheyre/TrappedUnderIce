using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlateform : MonoBehaviour {

    public AudioClip sound;
    public GameObject plateform;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            if(hasPlayed == false)
            {
                GetComponent<AudioSource>().PlayOneShot(sound);
                hasPlayed = true;
            }

            plateform.GetComponent<Rigidbody>().isKinematic = false;
        }

    }


}
