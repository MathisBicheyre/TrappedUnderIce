using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteScène : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public string scene;

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

    IEnumerator Portescene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
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
                if (_currInter.gameObject.tag == "Player" && Input.GetButtonDown("Interact"))
                {
                    anim.SetBool("Open", true);
                    StartCoroutine(Portescene());
                }
        }
    }
}