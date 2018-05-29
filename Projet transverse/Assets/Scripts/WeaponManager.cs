using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public GameObject activeWeapon;
    public bool canShoot;
    Weapon wpn;
    private float timer = 0;
	// Use this for initialization
	void Start () {
        if (!canShoot)
            gameObject.SetActive(false);
        wpn = activeWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = wpn.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Use Gun") && timer==0 && canShoot)
        {

            Vector3 rotation = transform.parent.localScale.x == 1 ? Vector3.zero : Vector3.forward * 180;
            GameObject projectile = (GameObject)Instantiate(wpn.projectile, transform.position, Quaternion.Euler(rotation));
            if (wpn.ProjectileMode == Weapon.Modes.Straight)
            {
                projectile.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x * Vector2.right * wpn.projectilespeed;
            }
            while (timer < wpn.cooldown)
                timer += Time.deltaTime;
            if (timer > wpn.cooldown)
                timer = 0;

            StartCoroutine(Waitt());

        }
	}

    IEnumerator Waitt()
    {
        yield return new WaitForSeconds(0.8f);
    }
}
