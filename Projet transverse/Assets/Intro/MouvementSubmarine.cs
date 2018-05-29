using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouvementSubmarine : MonoBehaviour
{

    private Vector2 velocity;
    public float distance = 5;
    public float Speed = 2f;
    public Vector2 Pointdepart;

    private float DistanceParcourue;
    private bool Isgoingright = true;


    void Start()
    {

        velocity = new Vector2(Speed, 0);
        Pointdepart = gameObject.transform.position;

        StartCoroutine(Restart());
    }


    void Update()
    {

        DistanceParcourue = transform.position.x - Pointdepart.x;

        if (Isgoingright)
        {
            transform.Translate(velocity.x * Time.deltaTime, 0, 0);

            if (DistanceParcourue > distance)
            {
                transform.eulerAngles = new Vector2(0, 180);
                Isgoingright = false;
            }


        }

        else
        {
            transform.Translate(velocity.x * Time.deltaTime, 0, 0);

            if (DistanceParcourue < 0)
            {
                transform.eulerAngles = new Vector2(0, 360);
                Isgoingright = true;
            }

        }
        
    }

    

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(18f);
        SceneManager.LoadScene("Menu");
    }
}