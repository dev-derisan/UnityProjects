using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  [SerializeField] private float timeToCompleteQuestion = 30.0f;
  [SerializeField] private float timeToShowCorrectAnswer = 10.0f;
  public float imageFillAmount;
  public bool isAnsweringQuestion;
  public bool loadNextQuestion;
  
  private float _timerValue;

  public void CancelTimer()
  {
    _timerValue = 0;
  }

  private void Start()
  {
    _timerValue = isAnsweringQuestion ? timeToCompleteQuestion : timeToShowCorrectAnswer;
  }

  void Update()
  {
    UpdateTimer();
  }

  void UpdateTimer()
  {
    _timerValue -= Time.deltaTime;

    if(isAnsweringQuestion)
    {
      if (_timerValue <= 0)
      {
        isAnsweringQuestion = false;
        _timerValue = timeToShowCorrectAnswer;
      }
      else
      {
        imageFillAmount = (_timerValue / timeToCompleteQuestion);
      }
    }
    else
    {
      if (_timerValue <= 0)
      {
        isAnsweringQuestion= true;
        _timerValue = timeToCompleteQuestion;
        loadNextQuestion = true;
      }
      else
      {
        imageFillAmount = (_timerValue / timeToShowCorrectAnswer);
      }
    }
  }
}
