using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFPumpService
{
    public class SettingsService : ISettingsService
    {
        public string FileName { get; set; }
    }
}