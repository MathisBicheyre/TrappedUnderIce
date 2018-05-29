using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IA_Araignée : MonoBehaviour {

    public GameObject player;

    public float detection;
    public float distance;
    public float speed;

    private Vector2 _ptDepart;
    private Vector2 _velocity;

    private float _totalDistance;
    private bool _isGoingDown = true;


    //private float _range;
    IEnumerator WaitForNewDetecting()
    {
        yield return new WaitForSeconds(1f);
        transform.eulerAngles = new Vector2(360, 0);
        _isGoingDown = true;
    }

    // Use this for initialization
    void Start () {
        _velocity = new Vector2(0, -speed);
        _ptDepart = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

		if(Mathf.Abs(player.transform.position.x - _ptDepart.x) < detection && Mathf.Abs(player.transform.position.y - _ptDepart.y) < detection)
        {
            _totalDistance = _ptDepart.y - transform.position.y;

            if(_isGoingDown)
            {
                transform.Translate(0, _velocity.y * Time.deltaTime * (transform.position.y/_ptDepart.y), 0);

                if (_totalDistance > distance)
                {
                    transform.eulerAngles = new Vector2(180, 0);
                    _isGoingDown = false;
                }
            }
            else
            {
                if (_totalDistance < 0)
                {
                    StartCoroutine(WaitForNewDetecting());
                }
                else
                    transform.Translate(0, _velocity.y * Time.deltaTime, 0);
            }
        }
        else if(_totalDistance > 0)
        {
            _totalDistance = _ptDepart.y - transform.position.y;
            transform.eulerAngles = new Vector2(180, 0);
            _isGoingDown = false;
            transform.Translate(0, _velocity.y * Time.deltaTime, 0);
        }
	}

}
