using CodeBase.Enemies.Behaviors;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class BotFactory : IBotFactory
    {
        public GameObject CreateBot(BotData botData, Material material, Transform parent)
        {
            GameObject botObject = Object.Instantiate(botData.Prefab, parent.position, Quaternion.identity, parent);

            Bot bot = botObject.GetComponent<Bot>();

            bot.Type = botData.BotType;

            bot.HealthPoints = botData.HealthPoints;
            bot.GetComponent<Mover>().SetSpeed(botData.MovementSpeed);
            bot.FastAttackDamage = botData.FastAttackDamage;
            bot.FastAttackChance = botData.FastAttackChance;
            bot.SlowAttackDamage = botData.SlowAttackDamage;
            bot.GetComponent<Attacker>().SetRange(botData.AttackRange);
            bot.MissChance = botData.MissChance;
            bot.CriticalAttackChance = botData.CriticalAttackChance;
            bot.CriticalDamageMultiplier = botData.CriticalDamageMultiplier;

            botObject.GetComponentInChildren<MeshRenderer>().material = material;

            return botObject;
        }
    }
}