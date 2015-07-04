using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Core.Persistence;
using Core.Model;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Customer> GetData(string value)
        {
            Context context = new Context();
            List<Customer> customersList = new List<Customer>();
            foreach (Customer c in context.Customers)
            {
                customersList.Add(c);
            }
            return customersList;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public void Create(Customer c)
        {
            Context context = new Context();
            context.Customers.Add(c);
            context.SaveChanges();
        }


        public void Add()
        {
            Context context = new Context();
            for (int i = 0; i < 5; i++)
            {
                Customer c = new Customer();
                c.Id = i;
                c.Name = "Rehan # " + i;
                context.Customers.Add(c);
            }
            context.SaveChanges();
        }
    }
}
