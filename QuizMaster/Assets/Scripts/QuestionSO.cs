using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question")]
public class QuestionSO : ScriptableObject
{
  public const int kNumAnswers = 4;

  [TextArea(2, 6)]
  [SerializeField] private string question = "Enter new question text here";

  [TextArea(2, 3)]
  [SerializeField] private string[] answers = new string[kNumAnswers];

  [Range(0, kNumAnswers - 1)]
  [SerializeField] private int correctAnswerIndex;

  public string Question { get => question; }
  public int CorrectAnswerIndex { get => correctAnswerIndex; }

  public string Answer(int index)
  {
    if (index < 0 || index >= answers.Length)
    {
      return "";
    }
    return answers[index];
  }
}
