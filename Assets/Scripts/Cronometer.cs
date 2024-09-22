using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cronometer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_MirrorUGUI;
    [SerializeField] bool valid01 = false;
    int min = 0, sec = 0, dSec = 0;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Crono();
    }

    public void Crono()
    {
        if (!valid01)
        {
            time += Time.deltaTime; //aumente el tiempo de forma ordenada
        }

        min = Mathf.FloorToInt(time / 60); //formula matematica para sacar los minutos
        sec = Mathf.FloorToInt(time % 60); //formula matematica para sacar los segundos (sacar tiempo en modulo de 60)
        dSec = Mathf.FloorToInt((time % 1) * 100); //sacar las decimas de segundos

        gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, dSec);
        m_MirrorUGUI.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, dSec);
        //se acomoda el texto del texto crono, la posici?n en el texto y como debe aparecer (el orden)
    }

    public void StopTime()
    {
        valid01 = false;
    }

    public bool StartTime
    {
        get { return valid01; }
        set { valid01 = value; }
    }
}
