using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassicalMusicApp.Models;

namespace ClassicalMusicApp
{
    public class CommonFunctions
    {
        private IndianClassicalMusicEntities db = new IndianClassicalMusicEntities();

        public string GetThaatNameByID(int? id)
        {
            var thaatName = string.Empty;
            var thaat = db.Thaats.Where(t=>t.ID == id).FirstOrDefault();
            if (thaat != null)
            {
                thaatName = thaat.ThaatName;
            }
            return thaatName;
        }
    }
}