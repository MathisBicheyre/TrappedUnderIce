using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss1 : MonoBehaviour
{
    BossHealth BarreDeVie = new BossHealth();

    public Animator anim;

    public int curHealth;
    public int maxHealth = 8;

    public GameObject Door;
    public GameObject Boss;

    private bool _isHit;
    private bool regen = true;

    private Collider2D _currTrig = null;

    // Use this for initialization
    void Start()
    {
        curHealth = maxHealth;
        BarreDeVie.max = 8;
        BarreDeVie.valeur = 8;
        Door.SetActive(false);
    }

    void Update()
    {

        if (_currTrig && _currTrig.gameObject.tag == "Bullet" && !_isHit)
        {
            anim.SetBool("BossTouché", true);
            _isHit = true;
            BarreDeVie.valeur -= 1;
            BossDeath();
            StartCoroutine(bossHit());
            Destroy(_currTrig.gameObject);
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth < (maxHealth / 2) && regen == true)
        {
            curHealth += 2;
            BarreDeVie.valeur += 2;
            regen = false;
            anim.SetBool("Regen", true);
            StartCoroutine(RegenB());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            _currTrig = collision;
        }
        else if (collision.gameObject.tag == "fist")
        {
            _currTrig = collision;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "fist")
        {
            _currTrig = collision;
            Destroy(_currTrig.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _currTrig = null;
    }

    public void BossDeath()
    {
        if (curHealth >= 1)
        {
            Debug.Log(curHealth);
            curHealth -= 1;
        }
        else
        {
            StartCoroutine(Win());
            anim.SetBool("BossDie", true);
        }
    }

    IEnumerator RegenB()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("Regen", false);
    }

    IEnumerator bossHit()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("BossTouché", false);
        _isHit = false;
    }


    public Save script_Save;

    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.9f);
        script_Save.Update_The_Save(0);

        Door.SetActive(true);
        anim.SetBool("BossDie", false);
        Boss.SetActive(false);
    }
}