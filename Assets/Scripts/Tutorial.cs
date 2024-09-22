using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButton(GameObject nextObjetc)
    {
        nextObjetc.SetActive(false);
    }

    public void ActiveNextStep(GameObject nextObject)
    {
        nextObject.SetActive(true);
    }

    public void StopAndPlayNextMusic(AudioSource nextSound)
    {
        gameObject.GetComponent<AudioSource>().Stop();
        nextSound.Play();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void MenuMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
