using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject button;

    // Use this for initialization
    void Start()
    {
        button.SetActive(false);
        StartCoroutine(Waitt());
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator Waitt()
    {
        yield return new WaitForSeconds(1.5f);
        button.SetActive(true);
    }

    public void exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
