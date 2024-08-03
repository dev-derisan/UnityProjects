using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float reloadDelay = 0.5f;
  [SerializeField] ParticleSystem crashEffect;
  [SerializeField] AudioClip crashSFX;
  bool hasCrashed = false;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Ground" && !hasCrashed)
    {
      hasCrashed = true;
      crashEffect.Play();
      GetComponent<AudioSource>().PlayOneShot(crashSFX);
      GetComponent<PlayerController>().CanMove = false;
      Invoke("ReloadScene", reloadDelay);
    }
  }

  void ReloadScene()
  {
    //GetComponent<PlayerController>().CanMove = true;
    SceneManager.LoadScene(0);
  }
}
