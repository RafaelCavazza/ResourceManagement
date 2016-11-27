using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Entities
{
    public enum ItemStatus
    {
        Avaliable = 1,
        AvaliableForDonation = 2,
        InUse = 3,
        Unusable = 4,
        Donated = 5
    }
}
