using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Settings
{
    public sealed class PerformanceSettings
    {
        public int WarningThresholdMilliseconds { get; init; } = 200;
    }

}
