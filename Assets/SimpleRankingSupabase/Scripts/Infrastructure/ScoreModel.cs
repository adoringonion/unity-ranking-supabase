using Postgrest.Attributes;
using Postgrest.Models;
using SimpleRankingSupabase.Scripts.Domain;

namespace SimpleRankingSupabase.Scripts
{
    [Table("scores")]
    public class ScoreModel : BaseModel
    {
        [PrimaryKey("id")] public int Id { get; set; }

        [Column("userName")] public string UserName { get; set; }

        [Column("score")] public int Score { get; set; }

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