using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
  [SerializeField] Color32 noPackageColor = new Color32(1, 0, 0, 1);
  bool hasPackage = false;

  SpriteRenderer spriteRenderer;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>(); 
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    Debug.Log("Oops, sorry!");
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Package" && !hasPackage)
    {
      spriteRenderer.color = hasPackageColor;
      Destroy(collision.gameObject);
      hasPackage = true;
      Debug.Log("Package picked up!");
    }
    else if(collision.tag == "Customer" && hasPackage)
    {
      spriteRenderer.color = noPackageColor;
      hasPackage = false;
      Debug.Log("Delivered package");
    }
  }
}
