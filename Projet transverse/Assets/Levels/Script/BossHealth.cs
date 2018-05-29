using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    
    static Image Barree;

    public float max { get; set; }

    private float Valeur;

    public float valeur
    {
        get { return Valeur; }

        set
        {
            Valeur = Mathf.Clamp(value, 0, max);
            Barree.fillAmount = (1 / max) * Valeur;
        }
    }

    // Use this for initialization
    void Start()
    {

        Barree = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}