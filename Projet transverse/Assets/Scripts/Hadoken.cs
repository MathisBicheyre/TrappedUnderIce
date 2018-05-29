using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hadoken : MonoBehaviour
{
    public float TimeToDestroy = 3f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, TimeToDestroy);
    }
}
