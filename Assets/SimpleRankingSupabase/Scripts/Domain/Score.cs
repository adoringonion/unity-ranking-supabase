using System;
using WebSocketSharp;

namespace SimpleRankingSupabase.Scripts.Domain
{
    public class Score
    {
        public string UserName { get; }
        public int Value { get; }

        public Score(string userName, int score)
        {
            if (userName.IsNullOrEmpty()) throw new ArgumentException("UserName can't be null or empty");
            if (score < 0) throw new ArgumentException("Score can't be negative");
            UserName = userName;
            Value = score;
        }
    }
}