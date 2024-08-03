using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] float torqueAmount = 1.0f;
  [SerializeField] float boostSpeed = 30.0f;
  [SerializeField] float baseSpeed = 20.0f;

  public bool CanMove { get; set; } = true;

  Rigidbody2D rb;
  SurfaceEffector2D surfaceEffector;

  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (CanMove)
    {
      RotatePlayer();
      RespondToBoost();
    }
  }

  private void RespondToBoost()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      surfaceEffector.speed = boostSpeed;
    }
    else
    {
      surfaceEffector.speed = baseSpeed;
    }
  }

  private void RotatePlayer()
  {
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      rb.AddTorque(torqueAmount);
    }
    else if (Input.GetKey(KeyCode.RightArrow))
    {
      rb.AddTorque(-torqueAmount);
    }
  }
}
