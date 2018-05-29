using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject plateform;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ZoneDead")
        {
            plateform.GetComponent<Rigidbody>().isKinematic = true;
            transform.position = GameObject.Find("ZoneRespawn").GetComponent<Transform>().transform.position;

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
