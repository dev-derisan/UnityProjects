using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
  [SerializeField] float steerSpeed;
  [SerializeField] float moveSpeed;
  [SerializeField] float slowSpeed;
  [SerializeField] float boostSpeed;

  // Start is called before the first frame update
  void Start()
  {
    steerSpeed = 180.0f;
    moveSpeed = 10.0f;
    slowSpeed = 5.0f;
    boostSpeed = 20.0f;
  }

  // Update is called once per frame
  void Update()
  {
    float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
    float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    transform.Rotate(0, 0, -steerAmount);
    transform.Translate(0, moveAmount, 0);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "SpeedUp")
    {
      moveSpeed = boostSpeed;
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Obstacle")
    {
      moveSpeed = slowSpeed;
    }
  }
}
