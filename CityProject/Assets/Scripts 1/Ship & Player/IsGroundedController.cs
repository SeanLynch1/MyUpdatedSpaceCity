﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedController : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator == null) return;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        Move(x, y);
        ActivateBlendStates();
    }
    public void Move(float x, float y)
    {
        _animator.SetFloat("VelX", x);
       _animator.SetFloat("VelY", y);

    }

    public void ActivateBlendStates()
    {
        //ACTIVATE BLEND STATE
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            _animator.SetInteger("Condition", 1);
        }
        else
        {
            _animator.SetInteger("Condition", 0);
        }
        //SPRINT
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Sprint");
            _animator.SetInteger("Condition", 2);
        }

    }
}
