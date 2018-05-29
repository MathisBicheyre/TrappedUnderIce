using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDestroyed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fist")
            StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
