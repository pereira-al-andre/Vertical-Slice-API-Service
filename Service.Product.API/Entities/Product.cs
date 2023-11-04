namespace Service.API.Entities
{
    public sealed class GetProdutResponse : Entity
    {
        public GetProdutResponse(
            string name,
            decimal price) : base(Guid.NewGuid())
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = decimal.Zero;
    }
}
