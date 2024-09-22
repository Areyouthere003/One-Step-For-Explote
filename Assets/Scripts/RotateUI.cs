using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUI : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            Vector3 v3 = _player.position - transform.position;
            v3.y = 0.0f;
            transform.rotation = Quaternion.LookRotation(-v3);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
    }
}
