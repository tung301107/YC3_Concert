namespace YC3.Interfaces
{
    public interface IPriceCalculator
    {
        decimal CalculateTotal(IEnumerable<decimal> seatPrices);
    }
}
