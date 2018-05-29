using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public enum Modes
    { Melee, Straight, Follow, Throw}
    public Sprite sprite;
    public GameObject projectile;
    public float projectilespeed;
    public float cooldown;
    public Modes ProjectileMode;

	// Use this for initialization
	void Start () {
		
	}
	
	
}
