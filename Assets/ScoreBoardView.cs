using System;
using System.Collections.Generic;
using SimpleRankingSupabase.Scripts.Domain;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private GameObject scrollArea;
    [SerializeField] private GameObject scoreObject;
    private readonly Subject<Unit> _onClickButton = new();

    private readonly Subject<string> _onInputField = new();
    public IObservable<string> OnInputField => _onInputField;
    public IObservable<Unit> OnClickButton => _onClickButton;


    private void Awake()
    {
        inputField.onValueChanged.AsObservable()
            .Subscribe(_onInputField.OnNext).AddTo(this);
        submitButton.OnClickAsObservable()
            .Subscribe(_onClickButton.OnNext).AddTo(this);
    }

    public void SetCurrentScore(int score)
    {
        currentScore.text = score.ToString();
    }

    public void SetInputField(string userName)
    {
        inputField.text = userName;
    }

    public void SetScrollArea(List<Score> scores)
    {
        ClearScrollArea();
        for (var i = 0; i < scores.Count; i++)
        {
            var go = Instantiate(scoreObject, scrollArea.transform);
            go.GetComponent<UserScoreUI>().SetScore(i + 1, scores[i].UserName, scores[i].Value);
        }
    }

    private void ClearScrollArea()
    {
        foreach (Transform o in scrollArea.transform) Destroy(o.gameObject);
    }
}