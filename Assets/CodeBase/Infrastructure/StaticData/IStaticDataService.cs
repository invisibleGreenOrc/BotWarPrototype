using CodeBase.Enemies;

namespace CodeBase.Infrastructure.StaticData
{
    public interface IStaticDataService
    {
        BotStaticData GetBotData(BotType botType);
        void LoadBotData();
    }
}