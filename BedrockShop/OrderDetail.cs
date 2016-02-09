using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class OrderDetail
    {
        #region Properties
        [Key]
        public int OrdetailId { get; set; }

        public int OrderHeadId { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// An orderHeader has many order details
        /// </summary>
        public virtual OrderHeader OrderHeader { get; set; }

        public virtual Product product { get; set; }

        #endregion
    }
}
