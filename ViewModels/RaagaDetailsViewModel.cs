using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassicalMusicApp.Models;

namespace ClassicalMusicApp.ViewModels
{

    public class ThaatDetailsViewModel
    {
        public int id { get; set; }
        public Thaat thaat { get; set; }

        public List<Raaga> raagas { get; set; } = new List<Raaga>();
    }
    public class RaagaDetailsViewModel
    {
        public int id { get; set; }
        public Raaga raaga { get; set; }
        public List<Composition> compositions { get; set; } = new List<Composition>();
        public List<Recording> recordings { get; set; } = new List<Recording>();

        public List<AppImage> appImages { get; set; } = new List<AppImage>();

        public List<AppDocuments> appDocuments { get; set; } = new List<AppDocuments>();
    }
}