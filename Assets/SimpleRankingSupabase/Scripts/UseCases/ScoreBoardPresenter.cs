using UniRx;
using UnityEngine;

namespace SimpleRankingSupabase.Scripts.UseCases
{
    public class ScoreBoardPresenter : MonoBehaviour
    {
        [SerializeField] private ScoreBoardView scoreBoardView;
        private ScoreViewModel _scoreViewModel;

        private void Start()
        {
            _scoreViewModel = new ScoreViewModel();
            ModelToView();
            ViewToModel();
        }

        private void ModelToView()
        {
            _scoreViewModel.CurrentScore
                .Subscribe(x => { scoreBoardView.SetCurrentScore(x); });

            _scoreViewModel.CurrentUserName
                .Subscribe(x => { scoreBoardView.SetInputField(x); });

            _scoreViewModel.CurrentScores
                .Where(x => x.Count != 0)
                .Subscribe(x => { scoreBoardView.SetScrollArea(x); });
        }

        private void ViewToModel()
        {
            scoreBoardView.OnClickButton
                .Where(_ => !string.IsNullOrEmpty(_scoreViewModel.CurrentUserName.Value))
                .Subscribe(async _ => { await _scoreViewModel.SubmitScore(); });

            scoreBoardView.OnInputField
                .Subscribe(x => { _scoreViewModel.SetUserName(x); });
        }
    }
}