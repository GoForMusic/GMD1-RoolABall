using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    private int _count;
    private float _movementX;
    private float _movementY;

    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject  winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
        _rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movementX, 0f, _movementY);
        _rb.AddForce(movement * speed);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1;
            SetCountText();
        }
    }
    
    private void SetCountText() 
    {
        countText.text =  "Count: " + _count.ToString();

        if (_count >= 8)
        {
            winTextObject.SetActive(true);
        }
        
    }
}
