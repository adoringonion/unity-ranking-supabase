using Cysharp.Threading.Tasks;
using SimpleRankingSupabase.Scripts.Domain;

namespace SimpleRankingSupabase.Scripts.UseCases
{
    public class RegisterNewScore
    {
        private IScoreRepository _scoreRepository;

        public RegisterNewScore(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }
        
        public async UniTask Invoke(string userName, int scoreValue)
        {
            Score newScore = new Score(userName, scoreValue);
            await _scoreRepository.InsertScore(newScore);
        }
    }
}