using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallpaperHourly
{
    internal class InputFile
    {
        public string Folder { get; set; }
        public List<Setting> Settings { get; set; }
        public Setting DefaultSetting { get; set; }
        public string GetPathForHour(int hour)
        {
            return Folder + "\\" + Settings.FirstOrDefault(s => s.HourToBeSet == hour, DefaultSetting).Path;
        }
    }
}
