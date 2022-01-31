using System.Collections.Generic;
using SimpleRankingSupabase.Scripts.Domain;
using UniRx;

namespace SimpleRankingSupabase.Scripts.UseCases
{
    public class ScoreViewModel
    {
        private ReactiveProperty<List<Score>> scores;
    }
}