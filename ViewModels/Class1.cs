using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassicalMusicApp.ViewModels
{
    public class RagaThaatViewModel
    {
        public Thaat Thaat { get; set; }
        public List<Raga> Ragas { get; set; }
    }

    public class RagaDetailsViewModel
    {
        public Thaat Thaat { get; set; }
        public Raga Raga { get; set; }
        public List<GetCompositionsByRaagId_Result> Compositions { get; set; }
    }
}