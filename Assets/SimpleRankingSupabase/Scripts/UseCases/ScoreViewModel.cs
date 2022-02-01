using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SimpleRankingSupabase.Scripts.Domain;
using SimpleRankingSupabase.Scripts.Infrastructure;
using Supabase;
using UniRx;
using UnityEngine;

namespace SimpleRankingSupabase.Scripts.UseCases
{
    public class ScoreViewModel
    {
        private readonly ReactiveProperty<int> _currentScore;
        private readonly ReactiveProperty<List<Score>> _currentScores;

        private readonly IScoreRepository _scoreRepository;
        private readonly ReactiveProperty<string> _userName;

        public ScoreViewModel()
        {
            _currentScores = new ReactiveProperty<List<Score>>();
            _currentScores.Value = new List<Score>();
            _currentScore = new ReactiveProperty<int>((int) Random.Range(1.0f, 100.0f));
            _userName = new ReactiveProperty<string>("");

            _scoreRepository = new SupabaseRepository(Client.Instance);
            SetScores();
        }

        public IReadOnlyReactiveProperty<int> CurrentScore => _currentScore;
        public IReadOnlyReactiveProperty<List<Score>> CurrentScores => _currentScores;
        public IReadOnlyReactiveProperty<string> CurrentUserName => _userName;

        public void SetUserName(string newUserName)
        {
            _userName.Value = newUserName;
            Debug.Log(_userName.Value);
        }

        public async UniTask SubmitScore()
        {
            var newScore = new Score(_userName.Value, _currentScore.Value);
            await _scoreRepository.InsertScore(newScore);
            _userName.Value = string.Empty;
            _currentScore.Value = (int) Random.Range(1.0f, 100.0f);
            await SetScores();
        }

        private async UniTask SetScores()
        {
            var scores = await _scoreRepository.FetchTopThirty();
            _currentScores.Value = scores;
        }
    }
}