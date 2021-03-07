using UniRx;
using UnityEngine;
using Zenject;

namespace UI
{
    public class HudPresenter
    {
        private readonly IHudView _view;
        private readonly HudModel _hudModel;

        [Inject]
        public HudPresenter(IHudView view, HudModel hudModel)
        {
            _view = view;
            _hudModel = hudModel;

            _hudModel.Score.Subscribe(value => _view.Score.text = $"Score: {value}");
            _hudModel.Level.Subscribe(value => _view.Level.text = $"Level : {value}");
            _hudModel.GameOver.Subscribe(value =>
            {
                _view.GameOver.enabled = value;
                _view.RestartButton.interactable = value;
            });
            
            _view.RestartButton.onClick.AsObservable().Subscribe(_ =>
            {
                _hudModel.Restart();
            });
        }
    }
}