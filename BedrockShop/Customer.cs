using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class Customer
    {
        #region Fields
        private static int lastCustomerID = 0;
        #endregion

        #region Properties
        /// <summary>
        /// CustomerId for Customer
        /// </summary>
        [Key]
        public int CustomerId { get; private set; }
        /// <summary>
        /// Customer Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// SSN for Customer
        /// </summary>
        public int SSN { get; set; }
        /// <summary>
        /// Address for Customer
        /// </summary>
        public string Address { get; set; }
        public string EmailAddress { get; set; }

        /// <summary>
        /// A customer has many orders
        /// </summary>
        public virtual ICollection<OrderHeader> Orders { get; set; }
        #endregion

        #region Constructor(s)
        public Customer()
        {
            //Default constructor
            CustomerId = ++lastCustomerID;            
        }
        #endregion

    }
}
