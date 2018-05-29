using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHydro : MonoBehaviour {

    BossHealth BarreDeVie = new BossHealth();
    public int currHealth;
    public int maxHealth = 3;

    //public GameObject player;
    //public GameObject Spawn1;
    //public GameObject Spawn2;
    public GameObject player;

    public GameObject projectile;
    public GameObject minion;

    public GameObject lcannon;
    public GameObject rcannon;

    public GameObject lspawn;
    public GameObject rspawn;

    public GameObject exitdoor;

    public float cooldown;

    float angle;

    GameObject _missile;

    GameObject _mob;

    GameObject _spawn;

    Vector3 temp;


    // Use this for initialization
    void Start () {
        _missile = null;
        _mob = null;
        exitdoor.SetActive(false);
        StartCoroutine(Boss());
        currHealth = maxHealth;
        BarreDeVie.max = 3;
        BarreDeVie.valeur = 3;
    }
	
	// Update is called once per frame
	void Update () {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Missile")
        {
            currHealth--;
            BarreDeVie.valeur -= 1;
            if (currHealth == 0)
                StartCoroutine(Dead());
        }
    }

    IEnumerator Boss()
    {
        while (true)
        {
            if (_missile == null)
            {
                if(player.transform.position.x < transform.position.x)
                    _missile = (GameObject)Instantiate(projectile, lcannon.transform.position, Quaternion.identity);
                else
                    _missile = (GameObject)Instantiate(projectile, rcannon.transform.position, Quaternion.identity);
                _missile.GetComponent<GuidedMissile>().addedSpeed = maxHealth - currHealth;
                while(_missile != null)
                {
                    yield return new WaitForSeconds(cooldown);
                }
                yield return null;
            }

            if(_mob == null)
            {
                
                if (player.transform.position.x < transform.position.x)
                    _spawn = lspawn;
                else
                    _spawn = rspawn;

                angle = (float)System.Math.Acos((float)(player.transform.position.x - _spawn.transform.position.x) / (float)(System.Math.Sqrt(System.Math.Pow(System.Math.Abs(player.transform.position.y - _spawn.transform.position.y), 2) + System.Math.Pow(player.transform.position.x - _spawn.transform.position.x, 2))));
                angle = angle * (float)360 / (float)(2 * System.Math.PI);

                if (player.transform.position.y < _spawn.transform.position.y)
                    angle = -angle;

                _mob = (GameObject)Instantiate(minion, _spawn.transform.position, Quaternion.identity);

                temp = new Vector3(0, 0, angle);
                _mob.transform.rotation = Quaternion.Euler(temp);
                _mob.transform.localScale = new Vector2(-1, 1);
                _mob.GetComponent<Rigidbody2D>().velocity = new Vector2(player.transform.position.x - _spawn.transform.position.x, player.transform.position.y - _spawn.transform.position.y) * 2;

                while (_mob != null)
                {
                    yield return new WaitForSeconds(cooldown);
                }
                yield return null;
            }

        }
    }

    public Save script_Save;

    IEnumerator Dead()
    {
        gameObject.tag= "Untagged";
        script_Save.Update_The_Save(2);
        Destroy(gameObject);
        exitdoor.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
}