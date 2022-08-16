namespace dotnet
{
    public class KisiComparerAd : IComparer<Kisi>
    {
        public int Compare(Kisi x, Kisi y) => x.Ad.CompareTo(y.Ad);
    }
}