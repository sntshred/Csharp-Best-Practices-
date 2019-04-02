using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            var productObj = new Product();
            productObj.ProductName = "Apple";
            productObj.ProductId = 1;
            productObj.Description = "Welcome";
            productObj.ProductVendor.CompanyName = "Craneware";


            var expected = "Hello Apple 1 Welcome Av ";

            var actual = productObj.SayHello();


            Assert.AreEqual(expected,actual);
        }
 
        [TestMethod()]
        public void SayHelloPamaetrizeConstructior()
        {
            var productObj = new Product(1, "Apple","Welcome");
            var expected = "Hello Apple 1 Welcome";

            var actual = productObj.SayHello();


            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void check_null()
        {
            Product productObj = null;

            var companyName = productObj?.ProductVendor?.CompanyName;

            string expected = null;

            var actual = companyName;


            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Used const keyword
        /// </summary>
        [TestMethod()]
        public void check_IncehsofProduct()
        {
          
            var expected = 78.74;

            var actual = 2* Product.InchesPerMeter;


            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Used readonly keyword, for default constructor
        /// </summary>
        [TestMethod()]
        public void check_defaultMinofProduct()
        {

            var expected = 32.32;
            var productObj = new Product();
            var actual = productObj.MiniumPrice;

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Used readonly keyword, for parmererize constructor
        /// </summary>
        [TestMethod()]
        public void check_MinofProduct()
        {

            var expected = 38.22;
            var productObj = new Product(1, "Apple", "Welcome");
            var actual = productObj.MiniumPrice;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_formatting()
        {
 
            var productObj = new Product();
            productObj.ProductName = " Steel Product ";
            var expected = "Steel Product";
            var actual = productObj.ProductName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_name_tooshort()
        {

            var productObj = new Product();
            productObj.ProductName = "aw";

            string exprected = null;
            string expectedMessage = "Product name should be atleast 3 charcters";

            //Act
            var actual = productObj.ProductName;
            var actualMessage = productObj.validationMessage;

            
            Assert.AreEqual(exprected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod()]
        public void Category_defaultvalues()
        {

            var productObj = new Product();
            string exprected = "Sales";

            //Act
            var actual = productObj.Category;
            Assert.AreEqual(actual, exprected);
        }
        [TestMethod()]
        public void Category_newvalues()
        {

            var productObj = new Product();
            productObj.Category = "HR";
            string exprected = "HR";

            //Act
            var actual = productObj.Category;
            Assert.AreEqual(actual, exprected);
        }

        [TestMethod()]
        public void product_code()
        {

            var productObj = new Product();
           
            string exprected = "Sales-1";

            //Act
            var actual = productObj.ProductCode;
            Assert.AreEqual(actual, exprected);
        }



    }
}