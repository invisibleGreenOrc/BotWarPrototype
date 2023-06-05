using CodeBase.Enemies.Behaviors;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class BotFactory : IBotFactory
    {
        private IStaticDataService _staticDataService;

        public BotFactory()
        {
            _staticDataService = Game.Instance.StaticDataService;
        }

        public GameObject CreateBot(BotData botData, PlayerType playerType, Transform parent)
        {
            GameObject botObject = Object.Instantiate(botData.Prefab, parent.position, Quaternion.identity, parent);

            Bot bot = botObject.GetComponent<Bot>();

            bot.Init(botData.BotType, playerType);

            bot.GetComponent<Health>().Init(botData.HealthPoints);
            bot.GetComponent<Mover>().SetSpeed(botData.MovementSpeed);
            bot.GetComponent<Attacker>().Init(botData.FastAttackDamage, botData.FastAttackChance, botData.SlowAttackDamage, botData.AttackRange, botData.MissChance, botData.CriticalAttackChance, botData.CriticalDamageMultiplier);

            botObject.GetComponentInChildren<MeshRenderer>().material = _staticDataService.GetPlayerMaterial(playerType);

            return botObject;
        }
    }
}