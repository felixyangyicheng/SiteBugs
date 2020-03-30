using System;
namespace SiteBugs.BD.Models
{
    public class Bug
    {
        public int identifiant  { get; set; }

        public string Titre { get; set; }

        public DateTime date { get; set; }

        public bool bloquant{ get; set; }

        public int  identifiantSeverite { get; set; }

        public Severite Severite{ get; set; }
    }
}
