using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MenuInteraction : MonoBehaviour
{
    [SerializeField] private GameObject loadingImage;
    [SerializeField] private Image loadBar;
    [SerializeField] TMP_Dropdown dropdownScale, dropdownDifficult;
    [SerializeField] bool valid01 = false;
    [SerializeField] InitialValues initialValues;
    int scaleLevel = 0, difficultLevel = 0;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (valid01)
        {
            valid01 = false;
        }
    }

    public void SetScaleLevel()
    {
        scaleLevel = dropdownScale.value + 1;
        initialValues.SizeValue = scaleLevel;
        Debug.Log(scaleLevel);
    }

    public void SetDifficultLevel()
    {
        difficultLevel = dropdownDifficult.value + 1;
        initialValues.DifficultValue = difficultLevel;
        Debug.Log(difficultLevel);
    }

    public void StartLevel()
    {
        StartCoroutine(StartLevel01());
        Debug.Log("funciona");
    }

    private IEnumerator StartLevel01()
    {
        yield return new WaitForSeconds(1f);

        loadingImage.SetActive(true);
        AsyncOperation myLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        //myLoad.allowSceneActivation = false;

        while (!myLoad.isDone)
        {
            loadBar.fillAmount = myLoad.progress;
            Debug.Log(loadBar.fillAmount);
            if (myLoad.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2f);
                //dondestroy.GetComponent<DontDestroyMe>().GetActivationBool(true);
                //myLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }
}
