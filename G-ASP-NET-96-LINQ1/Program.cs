using System;
using System.Linq;
using System.Collections.Generic;
namespace G_ASP_NET_96_LINQ1
{
        internal class Program
        {
            static void Main(string[] args)
            {
                #region Sample Data

                List<Product> ProductList = new List<Product>
            {
                new Product { ProductName = "Chai", Category = "Beverages", UnitPrice = 18, UnitsInStock = 39 },
                new Product { ProductName = "Chang", Category = "Beverages", UnitPrice = 19, UnitsInStock = 17 },
                new Product { ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10, UnitsInStock = 13 },
                new Product { ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22, UnitsInStock = 53 },
                new Product { ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.35m, UnitsInStock = 0 },
                new Product { ProductName = "Ikura", Category = "Seafood", UnitPrice = 31, UnitsInStock = 31 },
                new Product { ProductName = "Konbu", Category = "Seafood", UnitPrice = 6, UnitsInStock = 24 },
                new Product { ProductName = "Carnarvon Tigers", Category = "Seafood", UnitPrice = 62.5m, UnitsInStock = 42 },
                new Product { ProductName = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18.4m, UnitsInStock = 123 },
                new Product { ProductName = "Outback Lager", Category = "Beverages", UnitPrice = 15, UnitsInStock = 15 }
            };

                List<Customer> CustomerList = new List<Customer>
            {
                new Customer
                {
                    CustomerID = "ALFKI",
                    Orders = new List<Order>
                    {
                        new Order { OrderDate = new DateTime(1996, 7, 4) },
                        new Order { OrderDate = new DateTime(1997, 8, 25) },
                        new Order { OrderDate = new DateTime(1998, 1, 15) }
                    }
                },

                new Customer
                {
                    CustomerID = "ANATR",
                    Orders = new List<Order>
                    {
                        new Order { OrderDate = new DateTime(1996, 9, 18) },
                        new Order { OrderDate = new DateTime(1997, 11, 12) }
                    }
                }
            };

                #endregion

                #region Q1 - Seafood Products

                Console.WriteLine("\n========== Q1 ==========");

                var q1 = ProductList
                    .Where(p => p.Category == "Seafood");

                foreach (var p in q1)
                {
                    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
                }

                #endregion

                #region Q2 - Product Names

                Console.WriteLine("\n========== Q2 ==========");

                var q2 = ProductList
                    .Select(p => p.ProductName);

                foreach (var name in q2)
                {
                    Console.WriteLine(name);
                }

                #endregion

                #region Q3 - Sort By Price Ascending

                Console.WriteLine("\n========== Q3 ==========");

                var q3 = ProductList
                    .OrderBy(p => p.UnitPrice);

                foreach (var p in q3)
                {
                    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
                }

                #endregion

                #region Q4 - Price Between 10 And 30

                Console.WriteLine("\n========== Q4 ==========");

                var q4 = ProductList
                    .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

                foreach (var p in q4)
                {
                    Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
                }

                #endregion

                #region Q5 - Condiments In Stock

                Console.WriteLine("\n========== Q5 ==========");

                var q5 = ProductList
                    .Where(p => p.UnitsInStock > 0 &&
                                p.Category == "Condiments");

                foreach (var p in q5)
                {
                    Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");
                }

                #endregion

                #region Q6 - Anonymous Type

                Console.WriteLine("\n========== Q6 ==========");

                var q6 = ProductList
                    .Select(p => new
                    {
                        Name = p.ProductName,
                        Price = p.UnitPrice,
                        StockStatus = p.UnitsInStock > 0
                            ? "Available"
                            : "Out of Stock"
                    });

                foreach (var p in q6)
                {
                    Console.WriteLine(
                        $"{p.Name} - {p.Price} - {p.StockStatus}");
                }

                #endregion

                #region Q7 - Product Position

                Console.WriteLine("\n========== Q7 ==========");

                var q7 = ProductList
                    .Select((p, index) => new
                    {
                        Position = index + 1,
                        Name = p.ProductName
                    });

                foreach (var p in q7)
                {
                    Console.WriteLine($"{p.Position}. {p.Name}");
                }

                #endregion

                #region Q8 - Category And Price Sorting

                Console.WriteLine("\n========== Q8 ==========");

                var q8 = ProductList
                    .OrderBy(p => p.Category)
                    .ThenByDescending(p => p.UnitPrice);

                foreach (var p in q8)
                {
                    Console.WriteLine(
                        $"{p.Category} - {p.ProductName} - {p.UnitPrice}");
                }

                #endregion

                #region Q9 - Beverages Sorted By Stock

                Console.WriteLine("\n========== Q9 ==========");

                var q9 = ProductList
                    .Where(p => p.Category == "Beverages")
                    .OrderByDescending(p => p.UnitsInStock);

                foreach (var p in q9)
                {
                    Console.WriteLine(
                        $"{p.ProductName} - Stock: {p.UnitsInStock}");
                }

                #endregion

                #region Q10 - Query Syntax Compound From

                Console.WriteLine("\n========== Q10 ==========");

                var q10 =
                    from customer in CustomerList
                    from order in customer.Orders
                    where order.OrderDate.Year >= 1997
                    select new
                    {
                        customer.CustomerID,
                        order.OrderDate
                    };

                foreach (var item in q10)
                {
                    Console.WriteLine(
                        $"{item.CustomerID} - {item.OrderDate:d}");
                }

                #endregion

                #region Q11 - Position With Product Name

                Console.WriteLine("\n========== Q11 ==========");

                var q11 = ProductList
                    .Select((p, index) => new
                    {
                        Position = index + 1,
                        ProductName = p.ProductName
                    });

                foreach (var item in q11)
                {
                    Console.WriteLine(
                        $"{item.Position} - {item.ProductName}");
                }

                #endregion

                #region Q12 - Sort Words

                Console.WriteLine("\n========== Q12 ==========");

                string[] Arr =
                {
                "aPPLE",
                "AbAcUs",
                "bRaNcH",
                "BlUeBeRrY",
                "ClOvEr",
                "cHeRry"
            };

                var q12 = Arr
                    .OrderBy(w => w.Length)
                    .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

                foreach (var word in q12)
                {
                    Console.WriteLine(word);
                }

                #endregion

                #region Q13 - Second Letter Is i And Reverse

                Console.WriteLine("\n========== Q13 ==========");

                string[] digits =
                {
                "zero", "one", "two", "three", "four",
                "five", "six", "seven", "eight", "nine"
            };

                var q13 = digits
                    .Where(d => d.Length > 1 && d[1] == 'i')
                    .Reverse();

                foreach (var digit in q13)
                {
                    Console.WriteLine(digit);
                }

                #endregion

                Console.WriteLine("\n========== END ==========");
            }
        }

        #region Product Class

        public class Product
        {
            public string ProductName { get; set; } = "";
            public string Category { get; set; } = "";
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
        }

        #endregion

        #region Customer Class

        public class Customer
        {
            public string CustomerID { get; set; } = "";
            public List<Order> Orders { get; set; } = new List<Order>();
        }

        #endregion

        #region Order Class

        public class Order
        {
            public DateTime OrderDate { get; set; }
        }

        #endregion
    }

