using System;
using CodeBase.Enemies;
using CodeBase.Infrastructure.StaticData;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class SpawnerView : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _botTypeInput;
        
        [SerializeField]
        private TMP_InputField _healthPointsInput;

        [SerializeField]
        private TMP_InputField _movementSpeedInput;

        [SerializeField]
        private TMP_InputField _fastAttackDamageInput;

        [SerializeField]
        private TMP_InputField _fastAttackChanceInput;

        [SerializeField]
        private TMP_InputField _slowAttackDamageInput;

        [SerializeField]
        private TMP_InputField _attackRangeInput;

        [SerializeField]
        private TMP_InputField _missChanceInput;

        [SerializeField]
        private TMP_InputField _criticalAttackChanceInput;

        [SerializeField]
        private TMP_InputField _criticalDamageMultiplierInput;

        public event Action<BotData> StatsChanged;

        public void Show(BotData stats)
        {
            _botTypeInput.onEndEdit.AddListener(OnEndEdit);
            _healthPointsInput.onEndEdit.AddListener(OnEndEdit);
            _movementSpeedInput.onEndEdit.AddListener(OnEndEdit);
            _fastAttackDamageInput.onEndEdit.AddListener(OnEndEdit);
            _fastAttackChanceInput.onEndEdit.AddListener(OnEndEdit);
            _slowAttackDamageInput.onEndEdit.AddListener(OnEndEdit);
            _attackRangeInput.onEndEdit.AddListener(OnEndEdit);
            _missChanceInput.onEndEdit.AddListener(OnEndEdit);
            _criticalAttackChanceInput.onEndEdit.AddListener(OnEndEdit);
            _criticalDamageMultiplierInput.onEndEdit.AddListener(OnEndEdit);

            _botTypeInput.text = stats.BotType.ToString();
            _healthPointsInput.text = stats.HealthPoints.ToString();
            _movementSpeedInput.text = stats.MovementSpeed.ToString();
            _fastAttackDamageInput.text = stats.FastAttackDamage.ToString();
            _fastAttackChanceInput.text = stats.FastAttackChance.ToString();
            _slowAttackDamageInput.text = stats.SlowAttackDamage.ToString();
            _attackRangeInput.text = stats.AttackRange.ToString();
            _missChanceInput.text = stats.MissChance.ToString();
            _criticalAttackChanceInput.text = stats.CriticalAttackChance.ToString();
            _criticalDamageMultiplierInput.text = stats.CriticalDamageMultiplier.ToString();

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            
            _botTypeInput.onEndEdit.RemoveListener(OnEndEdit);
            _healthPointsInput.onEndEdit.RemoveListener(OnEndEdit);
            _movementSpeedInput.onEndEdit.RemoveListener(OnEndEdit);
            _fastAttackDamageInput.onEndEdit.RemoveListener(OnEndEdit);
            _fastAttackChanceInput.onEndEdit.RemoveListener(OnEndEdit);
            _slowAttackDamageInput.onEndEdit.RemoveListener(OnEndEdit);
            _attackRangeInput.onEndEdit.RemoveListener(OnEndEdit);
            _missChanceInput.onEndEdit.RemoveListener(OnEndEdit);
            _criticalAttackChanceInput.onEndEdit.RemoveListener(OnEndEdit);
            _criticalDamageMultiplierInput.onEndEdit.RemoveListener(OnEndEdit);
        }

        private void OnEndEdit(string value)
        {
            BotData newStats = new BotData
            {
                BotType = BotType.Melee,
                HealthPoints = float.Parse(_healthPointsInput.text),
                MovementSpeed = float.Parse(_movementSpeedInput.text),
                FastAttackDamage = float.Parse(_fastAttackDamageInput.text),
                FastAttackChance = float.Parse(_fastAttackChanceInput.text),
                SlowAttackDamage = float.Parse(_slowAttackDamageInput.text),
                AttackRange = float.Parse(_attackRangeInput.text),
                MissChance = float.Parse(_missChanceInput.text),
                CriticalAttackChance = float.Parse(_criticalAttackChanceInput.text),
                CriticalDamageMultiplier = float.Parse(_criticalDamageMultiplierInput.text),
                Prefab = null
            };
            
            StatsChanged?.Invoke(newStats);
        }
    }
}