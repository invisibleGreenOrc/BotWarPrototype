using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class BotFactory : IBotFactory
    {
        private readonly IStaticDataService _staticDataService;

        public BotFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public GameObject CreateBot(BotType botType, Transform parent)
        {
            BotStaticData botData = _staticDataService.GetBotData(botType);
            GameObject botObject = Object.Instantiate(botData.Prefab, parent.position, Quaternion.identity, parent);
            
            Bot bot = botObject.GetComponent<Bot>();
            bot.Type = botType;

            return botObject;
        }
    }
}