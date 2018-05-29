using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour {

    public bool inventory;      //if true this object can't be stored in inventory
    public bool openable;       //if true this object can be opened
    public bool locked;         //if true object is locked
    public GameObject itemNeeded; //item needed in order to interact
    public Animator anim;

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

    public void open()
    {
        anim.SetBool("Open", true);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //use a gun
    
}
