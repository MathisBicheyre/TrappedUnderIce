using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteract1 : MonoBehaviour {

    HealthBar BarreDeVie;
    public Animator anim;
    public ControlsManuals other;
 

    public int curHealth;
    public int maxHealth = 5;

    public bool isHealth;
    
    public GameObject poing;

    private bool _isHit;

    private Collider2D _currTrig = null;

    // Use this for initialization
    void Start () {

        if (isHealth)
        {
            BarreDeVie = new HealthBar();
            BarreDeVie.max = 100;
            BarreDeVie.valeur = 100;
        }
        
        poing.SetActive(false);     
    }

    void Update()
    {

        if (Input.GetButtonDown("Fist"))
        {
            anim.SetBool("CoupPoing", true);
            poing.SetActive(true);
        }
        if (Input.GetButtonUp("Fist"))
        {
            anim.SetBool("CoupPoing", false);
            StartCoroutine(StopBreak());
        }
        if (_currTrig && (_currTrig.gameObject.tag == "Ennemi" || _currTrig.gameObject.tag == "Missile") && !_isHit)
        {
            anim.SetBool("Touché", true);
            _isHit = true;
            BarreDeVie.valeur -= 17;
            PlayerDead();
            StartCoroutine(HitCD());
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi" || collision.gameObject.tag == "Missile")
        {
            _currTrig = collision;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi" || collision.gameObject.tag == "Missile")
        {
            //PlayerDead();
            _currTrig = collision;
            //anim.SetBool("Touché", true);
            //StartCoroutine(FinAnimation());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _currTrig = null;
    }

    public void PlayerDead()
    {
        if (curHealth >= 1)
        {
            //Debug.Log("ziziiiiiiiiiiiiiiiiiiiiiiii");
           // Debug.Log(curHealth);
            curHealth -= 1;
        }
        else
        {
            StartCoroutine(Restart());
        }
    }


    IEnumerator HitCD()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Touché", false);
        _isHit = false;
    }

    IEnumerator StopBreak()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("CoupPoing", false);
        poing.SetActive(false);
    }

    
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Dead");
    }




    /* OLD FUNCTIONS
     * 
     IEnumerator FinAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Touché", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemi")
        {
            //PlayerDead();
            _currTrig = collision;
            //anim.SetBool("Touché", true);
            //StartCoroutine(FinAnimation());

        }
    }
    */

}
