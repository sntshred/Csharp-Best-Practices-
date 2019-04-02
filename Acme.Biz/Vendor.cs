using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }

        /// <summary>
        /// Place the order here
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            return PlaceOrder(product, quantity, null,null);
                
        }

        public OperationResult PlaceOrder(Product product, int quantity,DateTimeOffset? deliverBy)
        {
            return PlaceOrder(product, quantity, deliverBy, null);

        }

        public OperationResult PlaceOrder(Product product, int quantity, 
                                DateTimeOffset? deliverBy,
                                string instructions
                                )
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliverBy));
           

            var success = false;



            var orderText = $"Order from {System.Environment.NewLine} Product {product.ProductCode} ";

            if (deliverBy.HasValue)
            {
                orderText += $"{System.Environment.NewLine} Deliver By {deliverBy.Value}";
            }

            if (!string.IsNullOrWhiteSpace(instructions))
            {
                orderText += $"{System.Environment.NewLine} Deliver By {instructions}";


            }

            var emailService = new EmailService();
            var confimation = emailService.SendMessage("new order", orderText, this.Email);

            if (confimation.StartsWith("Message sent:"))
            {
                success = true;
            }
            var operationResult = new OperationResult(success, orderText);
            return operationResult;

        }
    }
}
