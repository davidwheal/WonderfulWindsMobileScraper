using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderfulWinds.Scraper.Model.Entities;

namespace WonderfulWinds.Scraper.Repository
{
    public interface IRepository
    {
        int GetMenuItemCount();
        List<string> GetMenuItems();
        MenuItem GetMenuItem(int index);
    }
}
