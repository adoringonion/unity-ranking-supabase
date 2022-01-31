using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SimpleRankingSupabase.Scripts.Domain;

namespace SimpleRankingSupabase.Scripts.UseCases
{
    public class ShowScores
    {
        private readonly IScoreRepository _scoreRepository;

        public ShowScores(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async UniTask<List<Score>> Invoke()
        {
            List<Score> scores = await _scoreRepository.FetchTopThirty();
            return scores;
        }

    }
}