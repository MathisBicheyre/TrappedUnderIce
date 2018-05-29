using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRules : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 5f);
        if (transform.position.y < 179.54)
            Destroy(gameObject);
          
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
