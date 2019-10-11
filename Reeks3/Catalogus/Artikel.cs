namespace Catalogus
{
    public class Artikel : ABibItem
    {
        public string Titel { get; set; }
        
        public string Auteur { get; set; }

        public Artikel()
        {
        }

        public Artikel(string id, string titel, string auteur) : base(id)
        {
            Titel = titel;
            Auteur = auteur;
        }

        public override string Toon(int insprong)
        {
            return base.Toon(insprong) + ": \"" + Titel + "\", " + Auteur;
        }

        protected override bool VoldoetAanTrefwoord(string woord)
        {
            return base.VoldoetAanTrefwoord(woord) || Auteur.Contains(woord) || Titel.Contains(woord);
        }
    }
}