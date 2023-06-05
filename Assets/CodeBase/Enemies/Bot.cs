using UnityEngine;

namespace CodeBase.Enemies
{
    public class Bot : MonoBehaviour
    {
        public BotType BotType { get; private set; }

        public PlayerType PlayerType { get; private set; }

        public void Init(BotType botType, PlayerType playerType)
        {
            BotType = botType;
            PlayerType = playerType;
        }
    }
}