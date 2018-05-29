using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour {
    private Rigidbody2D rb;
    //A toi de jouer clem, le fist se pète automatiquement au bout de 5 sec
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.y <= 178.0722)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
            
        Destroy(gameObject, 5f);
	}
}
