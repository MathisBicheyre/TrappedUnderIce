using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_Wall : MonoBehaviour
{
    private Collision2D _currInter;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _currInter = collision;
                StartCoroutine(BreakWall());
            }

        }
    }

    IEnumerator BreakWall()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(_currInter.gameObject);
    }

}
