using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        public int OrderTotal { get; set; }
        public int Discount = 15;
        public string GreetMessage { get; set; }
        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty First name");
            }

            Discount = 20;
            GreetMessage = $"Hello, {firstName} {lastName}";
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
    
        
    

}
