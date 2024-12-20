﻿using System.Drawing.Printing;
using ClickerWebProject.Domain;

namespace ClickerWebProject.UseCases.GetCurrentUser;

public class UserDto 
{
    public string UserName { get; init; }

    public long CurruntScore { get; init; }

    public long RecordScore { get; init; }
    
    public IReadOnlyCollection<UserBoostDto> UserBoosts { get; init; }

    public long ProfitPerClick { get; set; }

    public long ProfitPerSecond { get; set; }
}
