namespace SapoProject.Model
{
    public static class ConnectionString
    {

        public static string GetConnectionString()
        {
            return "Server=.;Database=SapoProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }
    }
}