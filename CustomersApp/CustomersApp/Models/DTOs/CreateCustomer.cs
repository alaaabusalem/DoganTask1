namespace CustomersApp.Models.DTOs
{
    public class CreateCustomer
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }


        public static explicit operator CreateCustomer(Customer customer)
        {
            return new CreateCustomer
            {

                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email
            };
        }

    }

   

}
