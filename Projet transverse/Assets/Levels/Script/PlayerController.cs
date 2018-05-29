using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    public float Speed = 10f;
    public float Jump = 20f;
    public float Gravite = 7;
    public bool aDroite = true;
    public AudioClip SoundJump;

    public int curHealth;
    public int maxHealth = 5;

    private Vector2 DirectionDeplacement = Vector2.zero;
    private CharacterController Player;
    private Animator Anim;

    void Start () {

        Player = GetComponent<CharacterController>();
        curHealth = maxHealth;
        Anim = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            PlayerDead();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "ZoneDead")
        {
            PlayerDead();
        }
    }

    public void PlayerDead()
    {
        if (curHealth > 1)
        {
            curHealth -= 1;
            transform.position = GameObject.Find("ZoneDepart").GetComponent<Transform>().transform.position;
        }
        else
        {
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Dead");
    }

    void Update () {

        DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
        DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);

        Player.Move(DirectionDeplacement * Speed * Time.deltaTime);

        if (!Player.isGrounded)
        {
            DirectionDeplacement.y -= Gravite * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Player.isGrounded)
        {
            DirectionDeplacement.y = Jump;
            GetComponent<AudioSource>().PlayOneShot(SoundJump);
        }

        if (DirectionDeplacement.x > 0 && !aDroite)
        {
            ChangerDirection();   
        }

        if (DirectionDeplacement.x < 0 && aDroite)
        {
            ChangerDirection();           
        }

        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

            Anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

    }

    void ChangerDirection()
    {
        aDroite = !aDroite;
        Vector2 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    } 
        
}
