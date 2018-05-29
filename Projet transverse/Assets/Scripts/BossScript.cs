using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Transform[] spots;
    public Transform[] shoot;
    private float speed = 0.1f;
    public Transform player;
    public GameObject projectile;
    public GameObject UltimateShot;
    public int Maxnumbershots;
    public float dashRange;
    public float dashNerf;
    public float dashFreq;
    public float Hadoken = 1f;
    private int i = 0;
    private int spottogo = 0;
    private int dashAttack;
    private Vector3 temp;
    private float distance0 = 0f;
    private float distance1 = 0f;
    private float distance2 = 0f;
    private float distance3 = 0f;
    private float distance4 = 0f;
    private float angle;
    private float playerx;
    private float playery;
    public AudioClip SoundHadoken;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Boss");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Boss()
    {
        while (true)
        {
            angle = 0;
            dashAttack = (int)Random.Range(0, Maxnumbershots/dashFreq);
            while (transform.position.x != spots[spottogo].position.x && transform.position.y != spots[spottogo].position.y)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[spottogo].position.x, spots[spottogo].position.y), speed);
                yield return null;
            }
            if (transform.position.x > player.position.x)
                transform.localScale = new Vector2(1, 1);
            else
                transform.localScale = new Vector2(-1, 1);
            yield return new WaitForSeconds(1f);
            i = 0;
            if(Vector2.Distance(transform.position,player.position)<= Hadoken)
            {
                GetComponent<AudioSource>().PlayOneShot(SoundHadoken);
                angle =(float) System.Math.Acos((float) (player.transform.position.x - transform.position.x)/ (float) (System.Math.Sqrt(System.Math.Pow(System.Math.Abs(player.transform.position.y -transform.position.y),2)+ System.Math.Pow(player.transform.position.x - transform.position.x, 2))));
                angle = angle * (float) 360/(float) (2*System.Math.PI) ;
                if (player.transform.position.y < transform.position.y)
                    angle = -angle;
                GameObject Ultimate = (GameObject)Instantiate(UltimateShot, transform.position, Quaternion.identity);
                temp = new Vector3(0,0,angle);
                Ultimate.transform.rotation = Quaternion.Euler(temp);
                Ultimate.transform.localScale = new Vector2(-10, 10);
                Ultimate.GetComponent<Rigidbody2D>().velocity = new Vector2(player.position.x - transform.position.x,player.position.y - transform.position.y) * 2;
                yield return null;
            }
            while (i < Maxnumbershots)
            {
                if(i == dashAttack)
                {
                    if(Vector2.Distance(player.position, transform.position) < dashRange)
                    {
                        playerx = player.position.x;
                        playery = player.position.y;

                        while (transform.position.x != playerx && transform.position.y != playery)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerx, playery), speed);
                            yield return null;
                        }
                        yield return new WaitForSeconds(0.5f);

                        distance0 = Vector2.Distance(player.position, spots[0].position);
                        distance1 = Vector2.Distance(player.position, spots[1].position);
                        distance2 = Vector2.Distance(player.position, spots[2].position);
                        distance3 = Vector2.Distance(player.position, spots[3].position);
                        distance4 = Vector2.Distance(player.position, spots[4].position);
                        if (distance0 < distance1 && distance0 < distance2 && distance0 < distance3 && distance0 < distance4)
                            spottogo = 0;
                        if (distance1 < distance0 && distance1 < distance2 && distance1 < distance3 && distance1 < distance4)
                            spottogo = 1;
                        if (distance2 < distance1 && distance2 < distance0 && distance2 < distance3 && distance2 < distance4)
                            spottogo = 2;
                        if (distance3 < distance1 && distance3 < distance2 && distance3 < distance0 && distance3 < distance4)
                            spottogo = 3;
                        if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && distance4 < distance0)
                            spottogo = 4;

                        while (transform.position.x != spots[spottogo].position.x && transform.position.y != spots[spottogo].position.y)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(spots[spottogo].position.x, spots[spottogo].position.y), speed / dashNerf);
                            yield return null;
                        }
                    }
                }
                if(transform.localScale.x<0)
                {
                    GameObject bullet1 = (GameObject)Instantiate(projectile, shoot[7].position, Quaternion.identity);
                    bullet1.GetComponent<Rigidbody2D>().velocity = Vector2.one * 3;
                    GameObject bullet2 = (GameObject)Instantiate(projectile, shoot[6].position, Quaternion.identity);
                    bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.right * 3;
                    GameObject bullet3 = (GameObject)Instantiate(projectile, shoot[5].position, Quaternion.identity);
                    bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * 3;
                    GameObject bullet5 = (GameObject)Instantiate(projectile, shoot[3].position, Quaternion.identity);
                    bullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * 3;
                    GameObject bullet6 = (GameObject)Instantiate(projectile, shoot[2].position, Quaternion.identity);
                    bullet6.GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
                    GameObject bullet7 = (GameObject)Instantiate(projectile, shoot[1].position, Quaternion.identity);
                    bullet7.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * 3;
                }
                else
                {
                    GameObject bullet1 = (GameObject)Instantiate(projectile, shoot[1].position, Quaternion.identity);
                    bullet1.GetComponent<Rigidbody2D>().velocity = Vector2.one * 3;
                    GameObject bullet2 = (GameObject)Instantiate(projectile, shoot[2].position, Quaternion.identity);
                    bullet2.GetComponent<Rigidbody2D>().velocity = Vector2.right * 3;
                    GameObject bullet3 = (GameObject)Instantiate(projectile, shoot[3].position, Quaternion.identity);
                    bullet3.GetComponent<Rigidbody2D>().velocity = new Vector2(1, -1) * 3;
                    GameObject bullet5 = (GameObject)Instantiate(projectile, shoot[5].position, Quaternion.identity);
                    bullet5.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -1) * 3;
                    GameObject bullet6 = (GameObject)Instantiate(projectile, shoot[6].position, Quaternion.identity);
                    bullet6.GetComponent<Rigidbody2D>().velocity = Vector2.left * 3;
                    GameObject bullet7 = (GameObject)Instantiate(projectile, shoot[7].position, Quaternion.identity);
                    bullet7.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 1) * 3;
                }
                GameObject bullet = (GameObject)Instantiate(projectile, shoot[0].position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * 3;
                GameObject bullet4 = (GameObject)Instantiate(projectile, shoot[4].position, Quaternion.identity);
                bullet4.GetComponent<Rigidbody2D>().velocity = Vector2.down * 3;
                i++;
                yield return new WaitForSeconds(0.5f);
            }
            distance0 = Vector2.Distance(player.position, spots[0].position);
            distance1 = Vector2.Distance(player.position, spots[1].position);
            distance2 = Vector2.Distance(player.position, spots[2].position);
            distance3 = Vector2.Distance(player.position, spots[3].position);
            distance4 = Vector2.Distance(player.position, spots[4].position);
            if (distance0 < distance1 && distance0 < distance2 && distance0 < distance3 && distance0 < distance4)
                spottogo = 0;
            if (distance1 < distance0 && distance1 < distance2 && distance1 < distance3 && distance1 < distance4)
                spottogo = 1;
            if (distance2 < distance1 && distance2 < distance0 && distance2 < distance3 && distance2 < distance4)
                spottogo = 2;
            if (distance3 < distance1 && distance3 < distance2 && distance3 < distance0 && distance3 < distance4)
                spottogo = 3;
            if (distance4 < distance1 && distance4 < distance2 && distance4 < distance3 && distance4 < distance0)
                spottogo = 4;
            yield return null;
        }
    }
}
