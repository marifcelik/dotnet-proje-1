namespace dotnet
{
    public class KisiComparerSoyad : IComparer<Kisi>
    {
        public int Compare(Kisi x, Kisi y) => x.Soyad.CompareTo(y.Soyad);
    }
}