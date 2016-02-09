using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrockShop
{
    /// <summary>
    /// THis is the shopping  Class for BedrockShop that describes the Item of the class
    /// </summary>
    public class Product
    {
        #region Properties
        /// <summary>
        /// Id of the item
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Name of Item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the item
        /// </summary>
        public string Descripion { get; set; }
        /// <summary>
        /// Price of the item
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Weight of the Item
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Image of the Item
        /// </summary>
        public string Image { get; set; }
        #endregion


    }
}
