using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class OrderHeader
    {
        #region
        /// <summary>
        /// OrderID for Order
        /// </summary>
       [Key]
        public int OrderHeaderId { get; set; }
        /// <summary>
        /// CustomerID for Order
        /// </summary>
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Total Price for Order
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// This property associates a customer to a specific order
        /// </summary>
        public virtual Customer Customer { get; set; }
        /// <summary>
        /// An OrderHeader has many order details
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}
