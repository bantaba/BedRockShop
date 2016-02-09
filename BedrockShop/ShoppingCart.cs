using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    public class ShoppingCart
    {
        #region Properties
        [Key]
        public int ShoppingCartId { get; set; }
        /// <summary>
        /// Lists of products in shopping cart
        /// </summary>
        //public List<int> ProductIds { get; set; }

        public decimal SubTotal { get; set; }

        public int CustomerId { get; set; }

        public virtual ICollection<Product> Products { get; set;}
        public virtual Customer Customer {get; set;}

        #endregion
    }
}
