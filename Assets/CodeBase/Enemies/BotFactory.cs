using CodeBase.Infrastructure;
using CodeBase.Infrastructure.StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Enemies
{
    public class BotFactory : IBotFactory
    {
        private readonly IStaticDataService _staticDataService;

        private Dictionary<BotType, BotData> _botsData;

        public BotFactory()
        {
            _staticDataService = Game.Instance.StaticDataService;
            _botsData = _staticDataService.GetBotData();
        }

        public GameObject CreateBot(BotType botType, Material material, Transform parent)
        {
            GameObject botObject = Object.Instantiate(_botsData[botType].Prefab, parent.position, Quaternion.identity, parent);

            Bot bot = botObject.GetComponent<Bot>();
            bot.Type = botType;

            botObject.GetComponentInChildren<MeshRenderer>().material = material;

            return botObject;
        }
    }
}