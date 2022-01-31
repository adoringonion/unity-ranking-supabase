using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using SimpleRankingSupabase.Scripts.Domain;
using Supabase;

namespace SimpleRankingSupabase.Scripts.Infrastructure
{
    public class SupabaseRepository: IScoreRepository
    {
        private readonly Client _supabaseClient;

        public SupabaseRepository(Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }
        
        public async UniTask InsertScore(Score score)
        {
            var aaa = new ScoreModel { Id = 1, UserName = score.UserName, Score = score.Value};
            await _supabaseClient.From<ScoreModel>().Insert(aaa);
        }

        public async UniTask<List<Score>> FetchTopThirty()
        {
            var response = await _supabaseClient.From<ScoreModel>().Get();
            return response.Models.Select(model => model.ToScore()).ToList();
        }
    }
}