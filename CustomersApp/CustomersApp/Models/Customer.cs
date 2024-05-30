using CustomersApp.Models.DTOs;

namespace CustomersApp.Models
{
    public class Customer
    {
        public int Id { get; set; } 

        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }


        public static explicit operator Customer(CreateCustomer createCustomer )
        {
            return new Customer
            {
                Id = 0,
                Name = createCustomer.Name,
                Phone = createCustomer.Phone,
                Email = createCustomer.Email
            };
        }


        }
}
