using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob1 : MonoBehaviour
{

    private Vector2 velocity;
    public float distance = 5;
    public float Speed = 2f;

    private Vector2 Pointdepart;
    private float DistanceParcourue;
    private bool Isgoingdown = true;


    void Start()
    {

        velocity = new Vector2(0, Speed);
        Pointdepart = gameObject.transform.position;
    }

    void Update()
    {

        DistanceParcourue = transform.position.y - Pointdepart.y;

        if (Isgoingdown)
        {
            transform.Translate(0, velocity.y * Time.deltaTime, 0);

            if (DistanceParcourue > distance)
            {
                transform.eulerAngles = new Vector2(180, 0);
                Isgoingdown = false;
            }


        }

        else
        {
            transform.Translate(0, velocity.y * Time.deltaTime, 0);

            if (DistanceParcourue < 0)
            {
                transform.eulerAngles = new Vector2(360, 0);
                Isgoingdown = true;
            }

        }
    }
}