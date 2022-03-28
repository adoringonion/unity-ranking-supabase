using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Postgrest;
using UnityRankingSupabase.Scripts.Model;
using Client = Supabase.Client;

namespace UnityRankingSupabase.Scripts.Infrastructure
{
    public class SupabaseRepository : IScoreRepository
    {
        private readonly Client _supabaseClient;

        public SupabaseRepository(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async UniTask InsertScore(Score score)
        {
            var scoreModel = ScoreModel.FromScore(score);
            await _supabaseClient.From<ScoreModel>().Insert(scoreModel);
        }

        public async UniTask<List<Score>> FetchTopThirty()
        {
            var response = await _supabaseClient.From<ScoreModel>().Order("score", Constants.Ordering.Descending)
                .Limit(30).Get();
            return response.Models.Select(model => model.ToScore()).ToList();
        }
    }
}