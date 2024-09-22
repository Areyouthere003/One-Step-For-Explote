using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class LoadedMines : MonoBehaviour
{
    [Header("Scriptable Objec")]
    [SerializeField] ScoreValue scoreValue;

    [Header("Particles options")]
    [SerializeField] ParticleSystem p_Explosion;
    
    [Header("Set mines in Stage")]
    [SerializeField, Tooltip("Set object with the detection Function")] GameObject detectorAround;
    [SerializeField, Tooltip("show us the number of mines around of this object")] TextMeshProUGUI numberMinesText;

    [Header("Score and Time")]
    [SerializeField, Tooltip("Set the text mesh UGUI for give points")] TextMeshProUGUI scorePoints;
    [SerializeField, Tooltip("Set the Text Mesh UGUI for start and stop time")] GameObject timeControl;

    [Header("XR Ray Tracing OFF event")]
    [SerializeField, Tooltip("set XR ray tracing object for event")] GameObject playerControlR;
    [SerializeField] GameObject playerControlL;

    [Header("Game Over UI")]
    [SerializeField, Tooltip("set a UI for retry o quit game")] GameObject tryAgain;

    [Header("Other Options")]
    [SerializeField, Tooltip("set a number for activate the Mines animation")] float activationMineFloat = 1;
    [SerializeField, Tooltip("testing bool for many purposes")] bool valid01 = false, valid02 = true;
    [SerializeField] int _mine = 0, numberContact = 0, numberAround = 0;
    [SerializeField, Tooltip("This float is used for give speed to detection mines in the beginning"), 
        Range(0, 200)] float speedDet = 200f;
    
    int score = 0; bool pointSave = true;

    private const string actived = "Actived";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (valid01) //Action for the loaded mines with player
        {
            p_Explosion.GetComponent<ExplosionParticlesOnOff>().SetParticlesOn(valid01);
            valid01 = false;
            timeControl.GetComponent<Cronometer>().StopTime();
            playerControlR.GetComponent<XRRayInteractor>().enabled = false;
            playerControlR.GetComponent<XRRayInteractor>().enabled = false;

            int convertions = Convert.ToInt32(scorePoints.text);
            scoreValue.TotalTime = timeControl.GetComponent<TextMeshProUGUI>().text;
            scoreValue.Score = convertions;
            tryAgain.SetActive(true);
        }
        else
        {
            p_Explosion.GetComponent<ExplosionParticlesOnOff>().SetParticlesOn(valid01);
        }

        if (valid02)
        {
            if (detectorAround.transform.eulerAngles.y < 356)
            {
                detectorAround.transform.eulerAngles = new Vector3(detectorAround.transform.eulerAngles.x, detectorAround.transform.eulerAngles.y + speedDet * Time.deltaTime, detectorAround.transform.eulerAngles.z) /*Rotate(0, speedDet *  Time.deltaTime, 0)*/;
                Debug.Log(detectorAround.transform.localRotation.y);
            }
            else
            {
                valid02 = false;
                numberMinesText.text = numberAround.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(_mine == 1)
            {
                gameObject.GetComponent<Animator>().SetFloat(actived, activationMineFloat);
                valid01 = true;
            }
            else
            {
                gameObject.GetComponent<Animator>().SetFloat(actived, activationMineFloat);
                
                if(pointSave)
                {
                    int convertions = 0;
                    convertions = Convert.ToInt32(scorePoints.text);
                    score = convertions + 100;
                    scorePoints.text = Convert.ToString(score);
                    pointSave = false;
                }
            }
        }

        if(other.gameObject.CompareTag("Mines"))
        {
            other.GetComponent<LoadedMines>().RadarDetection(_mine);
            numberContact++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            valid01 = false;
        }

        if (other.gameObject.CompareTag("Mines"))
        {
        }
    }

    public void MineLoad(int number)
    {
        _mine = number;
    }

    public void RadarDetection(int number)
    {
        numberAround += number; 
    }
}
