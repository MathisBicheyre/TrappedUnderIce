using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera : MonoBehaviour {

    public Transform Target;
    public float AxeY;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y, -10);
    }
}
