using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Vector3 _from;
    private Vector3 _to;
    [SerializeField] private float speed;
    public bool yellow = true;

    private void Start()
    {
        _to = transform.GetChild(0).transform.position;
        _from = transform.GetChild(1).transform.position;
    }

    private void FixedUpdate()
    {
        if (yellow)
        {
            transform.position = Vector3.MoveTowards(transform.position, _to, Time.deltaTime * speed);
            if (transform.position == _to)
                yellow = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _from, Time.deltaTime * speed);
            if (transform.position == _from)
                yellow = true;
        }
    }
}
