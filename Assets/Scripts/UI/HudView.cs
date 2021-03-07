using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public interface IHudView
    {
        TMP_Text Score { get; }
        TMP_Text Level { get; }
        Canvas GameOver { get; }
        Button RestartButton { get; }
    }

    public class HudView : MonoBehaviour, IHudView
    {
        [SerializeField] private TMP_Text _score;

        [SerializeField] private TMP_Text _level;

        [SerializeField] private Canvas _gameOver;

        [SerializeField] private Button _restartButton;

        public TMP_Text Score => _score;
        public TMP_Text Level => _level;
        public Canvas GameOver => _gameOver;
        
        public Button RestartButton => _restartButton;
    }
}