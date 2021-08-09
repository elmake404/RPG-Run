﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private PlayerMove _target;
    private Vector3 _velocity, _offset;
    [SerializeField]
    private float _smoothTime;


    private void Start()
    {
        _target = FindObjectOfType<PlayerMove>();
        _offset = transform.position - _target.transform.position;
    }

    private void FixedUpdate()
    {
        if (GameStage.IsGameFlowe)
        {
            Vector3 NextPosCamera = (_target.transform.position + _offset);
            NextPosCamera.x = transform.position.x;
            transform.position = Vector3.SmoothDamp(transform.position, NextPosCamera, ref _velocity, _smoothTime);
        }
    }
}
