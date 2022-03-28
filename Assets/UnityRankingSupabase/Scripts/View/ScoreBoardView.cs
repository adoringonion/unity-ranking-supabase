using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using UnityRankingSupabase.Scripts.Model;
using UnityRankingSupabase.Scripts.ViewModel;

public class ScoreBoardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private GameObject scrollArea;
    [SerializeField] private GameObject scoreObject;

    private ScoreViewModel _scoreViewModel;


    private void Start()
    {
        _scoreViewModel = new ScoreViewModel();
        _scoreViewModel.Init();
        ModelToView();
        ViewToModel();
    }


    private void SetCurrentScore(int score)
    {
        currentScore.text = score.ToString();
    }

    private void SetInputField(string userName)
    {
        inputField.text = userName;
    }

    private void SetScrollArea(List<Score> scores)
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

    private void ModelToView()
    {
        _scoreViewModel.CurrentScore
            .Subscribe(SetCurrentScore);

        _scoreViewModel.CurrentUserName
            .Subscribe(SetInputField);

        _scoreViewModel.CurrentScores
            .Where(x => x.Count != 0)
            .Subscribe(SetScrollArea);
    }

    private void ViewToModel()
    {
        submitButton.OnClickAsObservable()
            .Where(_ => !string.IsNullOrEmpty(_scoreViewModel.CurrentUserName.Value))
            .Subscribe(async _ => { await _scoreViewModel.SubmitScore(); });

        inputField.onValueChanged
            .AsObservable()
            .Subscribe(x => { _scoreViewModel.SetUserName(x); });
    }
}