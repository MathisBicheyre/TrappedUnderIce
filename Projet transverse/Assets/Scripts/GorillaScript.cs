using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorillaScript : MonoBehaviour {

    BossHealth BarreDeVie = new BossHealth();
    public int curHealth;
    public int maxHealth = 8;
    private Collider2D _currTrig = null;
    private bool _isHit;

    public GameObject[] F1;
    public GameObject[] F2;
    public GameObject[] DF;
    public Transform player;
    public Transform[] MaxPos;
    public GameObject Door;

    private float speed = 2f;
    private float weakness = 4f;
    private float beforeAttack = 3f;
    private float resetAttack;
    private Animator anim;
    private bool boss = false;
    //Right( ) Left( ) Middle (-2.55; 2.55)

	// Use this for initialization
	void Start ()
    {
        resetAttack = beforeAttack;
        anim = GetComponent<Animator>();
        curHealth = maxHealth;
        BarreDeVie.max = 8;
        BarreDeVie.valeur = 8;

        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        Door.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(boss==false)
        {
            boss = true;
            StartCoroutine("Boss");
        }

        if (_currTrig && _currTrig.gameObject.tag == "Bullet" && !_isHit && gameObject.GetComponent<PolygonCollider2D>().enabled)
        {
            //anim.SetBool("BossTouché", true);
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

    }

    public void BossDeath()
    {
        if (curHealth >= 1)
        {
            //Debug.Log(curHealth);
            curHealth -= 1;
        }
        else
        {
            StartCoroutine(Win());
            //anim.SetBool("BossDie", true);
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

    public Save script_Save;

    IEnumerator Win()
    {
        yield return new WaitForSeconds(0.9f);
        script_Save.Update_The_Save(1);
        Destroy(gameObject);
        Door.SetActive(true);
        //anim.SetBool("BossDie", false);
    }

    IEnumerator bossHit()
    {
        yield return new WaitForSeconds(1f);
        //anim.SetBool("BossTouché", false);
        _isHit = false;
    }

    IEnumerator Boss()
    {
        while (true)
        {
            transform.localScale = new Vector3(1, 1);
            while (beforeAttack > 0.05f)
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                beforeAttack -= Time.deltaTime;
                if (player.position.x > F2[0].transform.position.x || player.position.x < F1[0].transform.position.x)
                {
                    if (player.position.x > transform.position.x)
                    {
                        if (!Raycastright())
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
                        }
                    }
                    else
                    {
                        if (!Raycastleft())
                        {
                            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
                        }
                    }

                }
                yield return null;
            }
            if (beforeAttack <= 0.05f)
            {
                while (beforeAttack <= 0.05f)
                {
                    gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                    if (player.position.x <= F2[0].transform.position.x-0.62f && player.position.x >= F1[0].transform.position.x+0.62f)
                    {
                        anim.SetBool("doubleattack", true);
                        DF[0].tag = "Ennemi";
                        yield return new WaitForSeconds(0.4f);
                        DF[0].tag = "Untagged";
                        DF[1].tag = "Ennemi";
                        yield return new WaitForSeconds(0.02f);
                        DF[1].tag = "Untagged";
                        DF[2].tag = "Ennemi";
                        yield return new WaitForSeconds(0.38f);
                        DF[2].tag = "Untagged";
                        DF[3].tag = "Ennemi";
                        yield return new WaitForSeconds(weakness);
                        DF[3].tag = "Untagged";
                        anim.SetBool("doubleattack", false);
                        yield return null;
                    }
                    else
                    {
                        if(player.position.x<F1[0].transform.position.x+0.62f && player.position.x>F1[0].transform.position.x-0.62f)
                        {
                            anim.SetBool("sideattack", true);
                            F1[3].tag = "Ennemi";
                            yield return new WaitForSeconds(0.4f);
                            F1[3].tag = "Untagged";
                            F1[2].tag = "Ennemi";
                            yield return new WaitForSeconds(0.02f);
                            F1[2].tag = "Untagged";
                            F1[1].tag = "Ennemi";
                            yield return new WaitForSeconds(0.38f);
                            F1[1].tag = "Untagged";
                            F1[0].tag = "Ennemi";
                            yield return new WaitForSeconds(weakness);
                            F1[0].tag = "Untagged";
                            anim.SetBool("sideattack", false);
                            yield return null;
                        }
                        else
                        {
                            if (player.position.x < F2[0].transform.position.x + 0.62f && player.position.x > F2[0].transform.position.x - 0.62f)
                            {
                                transform.localScale = new Vector3(-1, 1);
                                anim.SetBool("sideattack", true);
                                F2[3].tag = "Ennemi";
                                yield return new WaitForSeconds(0.4f);
                                F2[3].tag = "Untagged";
                                F2[2].tag = "Ennemi";
                                yield return new WaitForSeconds(0.02f);
                                F2[2].tag = "Untagged";
                                F2[1].tag = "Ennemi";
                                yield return new WaitForSeconds(0.38f);
                                F2[1].tag = "Untagged";
                                F2[0].tag = "Ennemi";
                                yield return new WaitForSeconds(weakness);
                                F2[0].tag = "Untagged";
                                anim.SetBool("sideattack", false);
                                yield return null;
                            }
                        }
                    }
                    beforeAttack = resetAttack;
                    yield return null;
                }
            }
            yield return null;
        }
    }
    private bool Raycastleft()
    {
        RaycastHit2D left = Physics2D.Raycast(new Vector2(F1[0].transform.position.x - ((F1[0].GetComponent<BoxCollider2D>().size.x) / 2), F1[0].transform.position.y), Vector2.left, 0.2f, 1 << LayerMask.NameToLayer("Ground"));
        return left;
    }
    private bool Raycastright()
    {
        RaycastHit2D right = Physics2D.Raycast(new Vector2(F2[0].transform.position.x + ((F2[0].GetComponent<BoxCollider2D>().size.x) / 2), F2[0].transform.position.y), Vector2.left, 0.2f, 1 << LayerMask.NameToLayer("Ground"));
        return right;
    }
}
