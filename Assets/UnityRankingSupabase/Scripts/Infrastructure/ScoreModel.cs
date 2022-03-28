using Postgrest.Attributes;
using Postgrest.Models;
using UnityRankingSupabase.Scripts.Model;

namespace UnityRankingSupabase.Scripts.Infrastructure
{
    [Table("scores")]
    public class ScoreModel : BaseModel
    {
        [PrimaryKey("id", false)] public int Id { get; set; }
        [Column("score")] public int Score { get; set; }
        [Column("user_name")] public string UserName { get; set; }


        public Score ToScore()
        {
            return new Score(UserName, Score);
        }

        public static ScoreModel FromScore(Score score)
        {
            return new ScoreModel {UserName = score.UserName, Score = score.Value};
        }
    }
}