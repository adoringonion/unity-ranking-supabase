using System;
using WebSocketSharp;

namespace UnityRankingSupabase.Scripts.Model
{

    public class Score
    {
        public Score(string userName, int score)
        {
            if (userName.IsNullOrEmpty()) throw new ArgumentException("UserName can't be null or empty");
            if (score < 0) throw new ArgumentException("Score can't be negative");
            UserName = userName;
            Value = score;
        }

        public string UserName { get; }
        public int Value { get; }
    }
}