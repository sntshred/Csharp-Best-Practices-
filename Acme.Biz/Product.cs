using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manaege products
    /// </summary>
    public   class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly double MiniumPrice;

        internal string Category{ get;  set; }
        public int Sequence { get; set; } = 1;

        public string ProductCode => Category + '-' + Sequence;

        public Product()
        {
            this.MiniumPrice = 32.32;
            this.Category = "Sales";
            Console.WriteLine("Consoele is created");
            //this.productVendor = new Vendor();
        }

        public Product(int productId,string productName,string description) :this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            Console.WriteLine("Consoele is from parametrize constructor");
            this.MiniumPrice = 38.22;

        }
        private DateTime? productAvailablity;

        public DateTime? ProductAvailablity
        {
            get { return productAvailablity; }
            set { productAvailablity = value; }
        }


        private string productName;

        public string ProductName
        {
            get {

                var formattedValue = productName?.Trim();
                return formattedValue;


            }
            set {

                if(value.Length < 3)
                {
                    validationMessage = "Product name should be atleast 3 charcters";
                }
                else if (value.Length > 20)
                {
                    validationMessage = "Product name should not be greater then 20 charcters";
                }
                else
                {
                productName = value;
                }

                }

        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;
        public string validationMessage;

        public Vendor ProductVendor
        {
            get {
                if(productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string SayHello()
        {

            var emailService = new EmailService();
            var confirmaiton = emailService.SendMessage("Subject is here",this.productName, "sa@email.com");
            var result  = LogAction("saying hello");
            var return1 = "Hello " + ProductName + " " + ProductId + " " + Description + " " + "Av " + ProductAvailablity?.ToShortDateString();
            return return1;
        }

        public override string ToString() => this.productName + $"({this.productId})";

        




    }
}
