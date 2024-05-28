using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Taak
    {
        public int IdNummer {  get; set; }
        public string TaakLabel { get; set; }
        public int MinTijdMinuten {  get; set; }
        public int MaxTijdMinuten { get; set;}
        public List<int>? VervolgTaken { get; set; }
        public List<int>? VoorgaandeTaken { get; set; }
        public bool IsDone {  get; set; }

        public Taak() { }

        public Taak(int idNummer, string taakLabel, int minTijdMinuten, int maxTijdMinuten, List<int>? vervolgTaken, List<int>? voorgaandeTaken)
        {
            IdNummer = idNummer;
            TaakLabel = taakLabel;
            MinTijdMinuten = minTijdMinuten;
            MaxTijdMinuten = maxTijdMinuten;
            VervolgTaken = vervolgTaken;
            VoorgaandeTaken = voorgaandeTaken;
            IsDone = false;
        }


    }
}
