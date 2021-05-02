using NewKinoHub.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewKinoHub.Manager.Casts
{
    public interface ICastManager
    {
        Task<Cast> GetCastforId(int castId);
    }
}
