using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Options : MonoBehaviour {

    public AudioMixer audioMixer;

	public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");

    }

    //public void Resume()
    //{
      //  SceneManager.LoadScene(sc)
    //}

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
