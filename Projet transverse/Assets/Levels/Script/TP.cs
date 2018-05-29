using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public GameObject itemNeeded;

    public bool openable;
    public bool locked;

    public Animator anim;

    private Collider2D _currInter;
    private bool _canOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
        {
            _canOpen = true;
            _currInter = collision;
        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _canOpen = false;
        _currInter = null;
    }
 
    IEnumerator WaitForTP()
        {
            yield return new WaitForSeconds(0.5f);
            player.transform.position = target.transform.position;
            anim.SetBool("Open", false);
        }
    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (_canOpen)
        {
            if (openable)
            {
                if (_currInter.gameObject == player && Input.GetButtonDown("Interact"))
                {
                    anim.SetBool("Open", true);
                    StartCoroutine(WaitForTP());
                }
            }
        }
        else
        {
            WaitForTP();
        }
    }
}
  