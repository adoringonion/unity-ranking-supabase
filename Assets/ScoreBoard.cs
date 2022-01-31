using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SimpleRankingSupabase.Scripts.Domain;
using SimpleRankingSupabase.Scripts.Infrastructure;
using SimpleRankingSupabase.Scripts.UseCases;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Random = UnityEngine.Random;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    [SerializeField] private Button _submitButton;
    [SerializeField] private TextMeshProUGUI currentScore;

    [SerializeField] private GameObject ScrollArea;

    [SerializeField] private GameObject ScoreObject;
    [SerializeField] private string supabaseURL;
    [SerializeField] private string apiKey;

    private RegisterNewScore _registerNewScore;
    private ShowScores _showScores;

    private async void Awake()
    {
        var client =  await Supabase.Client.InitializeAsync(supabaseURL, apiKey);
        IScoreRepository scoreRepository = new SupabaseRepository(client);
        _registerNewScore = new RegisterNewScore(scoreRepository);
        _showScores = new ShowScores(scoreRepository);
        currentScore.text = RandomScore().ToString();
        ShowScores(await _showScores.Invoke());
        _submitButton.OnClickAsObservable()
            .Where(_ => !_inputField.text.IsNullOrEmpty())
            .Subscribe(_ => SubmitText());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private async UniTask SubmitText()
    {
        await _registerNewScore.Invoke(_inputField.text, Convert.ToInt32(currentScore.text));
        _inputField.text = string.Empty;
        currentScore.text = RandomScore().ToString();
        DeleteAll();
        ShowScores(await _showScores.Invoke());
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeleteAll()
    {
        foreach (Transform t in ScrollArea.transform)
        {
            GameObject.Destroy(t);
        }
    }

    private int RandomScore()
    {
        return (int) Random.Range(1.0f, 100.0f);
    }

    private void ShowScores(List<Score> scores)
    {
        foreach (var score in scores)
        {
            var scoreObject = Instantiate(ScoreObject, ScrollArea.transform);
            var ui = scoreObject.GetComponent<UserScoreUI>();
            ui.SetUserName(score.UserName);
            ui.SetScoreValue(score.Value.ToString());
            
        }
    }
}
