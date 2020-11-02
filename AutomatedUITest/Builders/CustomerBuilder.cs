using Bogus;

namespace AutomatedUITest
{
    public class CustomerBuilder
    {
        private Customer _customer;

        private CustomerBuilder()
        {
            _customer = new Customer();
            Faker faker = new Faker();
            _customer.Address = faker.Address.StreetAddress();
            _customer.Name = $"{faker.Name.FirstName()} {faker.Name.LastName()}";
            _customer.Phone = faker.Phone.PhoneNumber("+###-##-###-####");
            _customer.Email = faker.Person.Email;
            _customer.PostalCode = faker.Address.ZipCode("#####-###");
        }

        public static CustomerBuilder New()
        {
            return new CustomerBuilder();
        }

        public CustomerBuilder WithAddress(string address)
        {
            _customer.Address = address;
            return this;
        }

        public CustomerBuilder WithName(string name)
        {
            _customer.Name = name;
            return this;
        }

        public CustomerBuilder WithPhone(string phone)
        {
            _customer.Phone = phone;
            return this;
        }

        public CustomerBuilder WithPostalCode(string postalCode)
        {
            _customer.PostalCode = postalCode;
            return this;
        }
        public CustomerBuilder WithEmail(string email)
        {
            _customer.Email = email;
            return this;
        }
        public Customer Build()
        {
            return _customer;
        }
    }
}