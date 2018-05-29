using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : MonoBehaviour {

    GameObject player;

    public float speed;
    public float addedSpeed;

    // Use this for initialization
    void Start () {
        gameObject.tag = "Untagged";
        player = GameObject.Find("Player");
        speed += addedSpeed / 100f;
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.tag = "Missile";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "Missile")
            Destroy(gameObject, 0.1f);
    }
}
