namespace OpremiSe.Models
{
    public class Produkti
    {
        public int Id { get; set; }

        public string Naziv { get; set; }
        public string? Opis { get; set; }

        public string? Kategorija { get; set; }

        public int Kolicina { get; set; }

        public decimal Cena { get; set; }
    }
}
