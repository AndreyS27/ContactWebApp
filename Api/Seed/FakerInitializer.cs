namespace Api.Seed
{
    public class FakerInitializer : IInitializer
    {
        private string connectionString;

        public FakerInitializer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Initialize()
        {
            
        }
    }
}
