namespace EndPoints.DomainModel
{
    public record Customer : BaseEntity
    {
        public Customer(string name, string region)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Region = region ?? throw new ArgumentNullException(nameof(region));
        }

        public string Name { get; private set; }
        public string Region { get; private set; }

        public void Update(string name, string region)
        {
            this.Name = name;
            this.Region = region;
        }
        public static Customer Create(string name, string region)
        {
            return new Customer(name, region);
        }
    }
}
