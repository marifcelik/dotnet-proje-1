namespace dotnet
{
    public class Kisi
    {
        private const string format = "{{ ad : {0}, soyad : {1}, numara : {2} }}";
        private string ad;
        private string soyad;
        private long numara;

        public string Ad { get => ad; set => ad = value; }
        public string Soyad { get => soyad; set => soyad = value; }
        public long Numara { get => numara; set => numara = value; }

        public Kisi(string ad, string soyad, long numara)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.numara = numara;
        }

        public Kisi() { }

        public override string ToString() => string.Format(format, Ad, Soyad, Numara);
    }
}