using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField]
    Transform TargetA, TargetB;
    private float _speed = 2.0f;
    private bool _switching;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetB.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetA.position, _speed * Time.deltaTime);
        }
        if(transform.position == TargetA.position)
        {
            _switching = false;
        }
        else if(transform.position == TargetB.position)
        {
            _switching = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
