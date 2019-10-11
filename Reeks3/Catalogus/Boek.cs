namespace Catalogus
{
    public class Boek : ABibItem
    {
        public string Titel { get; set; }
        
        public string Auteur { get; set; }
        public string Uitgeverij { get; set; }
        
        public int Jaartal { get; set; }

        public Boek()
        {
            Titel = "";
            Auteur = "";
            Uitgeverij = "";
            Jaartal = 0;
        }

        public Boek(string id, string titel, string auteur, string uitgeverij, int jaartal) : base(id)
        {
            Titel = titel;
            Auteur = auteur;
            Uitgeverij = uitgeverij;
            Jaartal = jaartal;
        }

        public override string Toon(int insprong)
        {
            return base.Toon(insprong) + ": \"" + Titel + "\", " + Auteur + ", " + Uitgeverij + ", " + Jaartal;
        }

        protected override bool VoldoetAanTrefwoord(string woord)
        {
            return base.VoldoetAanTrefwoord(woord) || Uitgeverij.Contains(woord) || Jaartal.ToString().Contains(woord) || Titel.Contains(woord) || Auteur.Contains(woord);
        }
    }
}