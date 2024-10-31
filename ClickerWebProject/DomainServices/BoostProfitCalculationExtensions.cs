﻿using ClickerWebProject.Domain;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClickerWebProject.DomainServices;

public static class BoostProfitCalculationExtensions
{
    public static long GetProfit(this IEnumerable<UserBoost> userBoosts, bool shouldCalculateAutoBoosts = false)
    {
        if (shouldCalculateAutoBoosts)
        { 
        return userBoosts
            .Where(ub => !ub.Boost.IsAuto)
            .Sum(ub => ub.Quantity * ub.Boost.Profit);
        }
        return 1 + userBoosts
            .Where(ub => !ub.Boost.IsAuto)
            .Sum(ub => ub.Quantity * ub.Boost.Profit);
    }
}
