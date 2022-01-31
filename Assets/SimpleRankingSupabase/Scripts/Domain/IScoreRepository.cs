using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace SimpleRankingSupabase.Scripts.Domain
{
    public interface IScoreRepository
    {
        public UniTask InsertScore(Score score);

        public UniTask<List<Score>> FetchTopThirty();
    }
}