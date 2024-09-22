using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameOverFollowed : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int posObject = 0;

    [SerializeField] bool valid01 = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (valid01)
        {
            target.gameObject.SetActive(true);
            Vector3 v3 = gameObject.transform.position - target.transform.position;
            v3.y = 0.0f;
            target.transform.rotation = Quaternion.LookRotation(-v3);
            target.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + posObject, gameObject.transform.position.z + posObject);
            valid01 = false;
        }
    }
}
