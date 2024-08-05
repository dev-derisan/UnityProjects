using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
  [Header("Question")]
  [SerializeField] private TextMeshProUGUI questionText;
  [SerializeField] private List<QuestionSO> questions = new List<QuestionSO>();

  private QuestionSO currentQuestion;

  [Header("Answers")]
  [SerializeField] private GameObject[] answerButtons;
  int correctAnswerIndex;
  bool hasAnsweredEarly;

  [Header("Button Colors")]
  [SerializeField] private Sprite defaultAnswerSprite;
  [SerializeField] private Sprite correctAnswerSprite;

  [Header("Timer")]
  [SerializeField] private Image timerImage;
  Timer timer;

  void Start()
  {
    timer = FindObjectOfType<Timer>();
    GetNextQuestion();
  }

  private void Update()
  {
    timerImage.fillAmount = timer.imageFillAmount;

    if(timer.loadNextQuestion)
    {
      hasAnsweredEarly = false;
      GetNextQuestion();
      timer.loadNextQuestion = false;
    }
    else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
    {
      DisplayAnswer(-1);
      ChangeButtonImage(currentQuestion.CorrectAnswerIndex, correctAnswerSprite);
      SetButtonsState(false);
    }
  }

  public void OnAnswerSelected(int index)
  {
    hasAnsweredEarly = true;
    DisplayAnswer(index);
    ChangeButtonImage(currentQuestion.CorrectAnswerIndex, correctAnswerSprite);

    SetButtonsState(false);
    timer.CancelTimer();
  }

  void DisplayAnswer(int index)
  {
    if (index == currentQuestion.CorrectAnswerIndex)
    {
      questionText.text = "Correct!";
    }
    else
    {
      questionText.text = $"That's close! The answer was - {currentQuestion.Answer(currentQuestion.CorrectAnswerIndex)}";
    }
  }

  private void DisplayQuestion()
  {
    questionText.text = currentQuestion.Question;

    for (int i = 0; i < answerButtons.Length; ++i)
    {
      TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
      buttonText.text = currentQuestion.Answer(i);
    }
  }

  private void ChangeButtonImage(int index, Sprite buttonImage)
  {
    Image image = answerButtons[index].GetComponent<Image>();
    image.sprite = buttonImage;
  }

  private void SetButtonsState(bool state)
  {
    foreach(GameObject button in answerButtons)
    {
      Button b = button.GetComponent<Button>();
      b.interactable = state;
    }
  }

  private void SetDefaultButtonSprites()
  {
    foreach(GameObject button in answerButtons)
    {
      Image image = button.GetComponent<Image>();
      image.sprite = defaultAnswerSprite;
    }
  }

  private void GetNextQuestion()
  {
    SetButtonsState(true);
    SetDefaultButtonSprites();
    GetRandomQuestion();
    DisplayQuestion();
  }

  private void GetRandomQuestion()
  {
    int index = Random.Range(0, questions.Count - 1);
    currentQuestion = questions[index];

    if(questions.Contains(currentQuestion))
    {
      questions.Remove(currentQuestion);
    }
  }
}
