using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticlesOnOff : MonoBehaviour
{
    [SerializeField] AudioSource s_Explote;
    [SerializeField] bool valid01 = false, valid02 = false;

    // Start is called before the first frame update
    void Start()
    {
        var exploteOn = gameObject.GetComponent<ParticleSystem>().emission;
        exploteOn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (valid01)
        {
            var exploteOn = gameObject.GetComponent<ParticleSystem>().emission;
            exploteOn.enabled = true;
            gameObject.GetComponent<ParticleSystem>().Play();
         
            if (valid02)
            {
                s_Explote.Play();
                valid02 = false;
            }
            valid01 = false;
        }
    }

    public void SetParticlesOn(bool valida2)
    {
        if (valida2)
        {
            valid02 = true;
            valid01 = true;
        }
        else
        {
            valid02 = false;
            valid01 = false;
        }

    }
}
