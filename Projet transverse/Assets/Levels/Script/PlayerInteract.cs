using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour {

    public GameObject currentInterObj = null;
    public PickUp currentInterObjScript = null;
    public Inventory inventory;


    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 2");
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "interObject")
        {
            currentInterObj = col.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<PickUp>();
        }

    }

    /*
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "interObject")
        {
            if (col.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }

        }
    }
    */
    

    void Update()
    {
        
                if (Input.GetButtonDown("Interact") && currentInterObj)
                {
                    //check to see if this object is to be stored in inventory
                    if (currentInterObjScript.inventory)
                    {
                        inventory.AddItem(currentInterObj);
                        currentInterObj = null;
                    }

                    //check to see if this object can be opened
                    if (currentInterObjScript.openable)
                    {
                        //check ot see if object is locked
                        if (currentInterObjScript.locked)
                        {
                            //check to see if we have the object needed
                            //search our inventory
                            if (inventory.FindItem(currentInterObjScript.itemNeeded))
                            {
                                //we found the item needed
                                currentInterObjScript.locked = false;
                                Debug.Log(currentInterObj.name + " is unlocked");
                                currentInterObjScript.open();
                                StartCoroutine(NextLevel());

                            }
                            else
                            {
                                Debug.Log(currentInterObj.name + " is locked");
                            }
                        }
                        else
                        {
                            //object is not locked so we can open
                            Debug.Log(currentInterObj.name + " is open");
                            currentInterObjScript.open();
                            StartCoroutine(NextLevel());
                        }
                    }

                }

            //use gun
            if (Input.GetButtonDown("Use Gun"))
            {
                //check inventory for a gun

                //use gun, apply its effect

                //remove the gun from inventory
            }
        }
    

}
