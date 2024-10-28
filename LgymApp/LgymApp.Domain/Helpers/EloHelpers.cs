using LgymApp.Domain.Enums;

namespace LgymApp.Domain.Helpers;

public static class EloHelpers
{
    public static Dictionary<RanksEnum, (int min, int max)> EloRanks = new()
    {
        { RanksEnum.Junior_1, (0, 1000) },
        { RanksEnum.Junior_2, (1001, 2500) },
        { RanksEnum.Junior_3, (2501, 4000) },
        { RanksEnum.Middle_1, (4001, 5000) },
        { RanksEnum.Middle_2, (5001, 6000) },
        { RanksEnum.Middle_3, (6001, 7000) },
        { RanksEnum.Professional_1, (7001, 10000) },
        { RanksEnum.Professional_2, (10001, 13000) },
        { RanksEnum.Professional_3, (13001, 17000) },
        { RanksEnum.Master, (17001, int.MaxValue) }
    };

    public static RanksEnum GetRank(int elo)
    {
        foreach (var rank in EloRanks)
        {
            if (elo >= rank.Value.min && elo <= rank.Value.max)
                return rank.Key;
        }

        return RanksEnum.Junior_1;
    }
}
