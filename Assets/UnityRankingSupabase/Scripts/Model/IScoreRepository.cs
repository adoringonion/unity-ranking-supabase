using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace UnityRankingSupabase.Scripts.Model
{
    public interface IScoreRepository
    {
        public UniTask InsertScore(Score score);

        public UniTask<List<Score>> FetchTopThirty();
    }
}