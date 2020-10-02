namespace CatalogOfEmployees.BusinessLogic.Domain.Contracts
{
    public class CreateEmployee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public string State { get; set; }

        //public string Photo { get; set; }
    }

    public class UpdateEmployee : CreateEmployee
    {
        public long Id { get; set; }
    }
}