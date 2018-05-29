using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroMinion : MonoBehaviour {

    bool ready;

	// Use this for initialization
	void Start () {
        ready = false;
        StartCoroutine(Rup());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ready)
            Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (ready)
            Destroy(gameObject);
    }

    IEnumerator Rup()
    {
        yield return new WaitForSeconds(0.1f);
        ready = true;
    }

}
