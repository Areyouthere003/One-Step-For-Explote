using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MirrorScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_MirrorScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = m_MirrorScore.text;
    }
}
