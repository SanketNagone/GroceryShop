using GroceryShop.DAL;
using GroceryShop.Entities;

Console.WriteLine("##################################------ Welcome To Sanket's Grocery Shop..........!!!!!! ------##################################");

Console.WriteLine("Select Products to buy from list:");

IDiscountAccessor _discountAccesor = new DiscountAccessor();
IProductAccessor _productAccesor = new ProductsAccessor(_discountAccesor);
List<IProduct> productsMasterlist = _productAccesor.GetAllProducts();

Console.WriteLine("##########---- Products ----##########");

PrintProducts(productsMasterlist,false);

List<IProduct> cartProducts = new List<IProduct>();

GroceryShop:
Console.WriteLine("Enter Product# to Add to cart. Type 'Bill' to see the Bill.");


int productId;

var inPut = Console.ReadLine();

if (Int32.TryParse(inPut, out productId))
    AddNewToCart(productId, productsMasterlist, ref cartProducts);
else if (inPut.Equals("bill", StringComparison.InvariantCultureIgnoreCase))
    GenerateBill(cartProducts);

goto GroceryShop;

static void AddProductToCart(IProduct product, ref List<IProduct> cartlist)
{
    if (cartlist.Contains(product))
    {
        var quantity = cartlist.Where(p => p.Equals(product)).FirstOrDefault().Quantity;
        product.Quantity = quantity + 1;
    }
    else
    {
        cartlist.Add(product);
    }
}

static void AddNewToCart(int productId, List<IProduct> productsMasterlist, ref List<IProduct> cartProducts)
{
    if (!productsMasterlist.Select(p => p.Id).ToList().Any(x => x == productId))
        Console.WriteLine("Invalid ProductId , please enter Correct productId");
    else
        AddProductToCart(productsMasterlist.First(p => p.Id == productId), ref cartProducts);
}

static void GenerateBill(List<IProduct> cartProducts)
{
    Bill bill = new Bill(cartProducts, new DateTime(2022, 08, 15), new SpecialDayDiscountAccessor());

    Console.WriteLine("######### Your Bill ############");

    PrintProducts(cartProducts, true);

    Console.WriteLine($"Bill Date: {bill.BillDate}");
    Console.WriteLine($"Total bill Amount : {bill.TotalBillAmount}");
    Console.WriteLine($"Final Bill Amount After Discount : {bill.GetBillAmountAfterDiscount()}");

    Console.WriteLine($"Total Discount : {bill.TotalDiscountAmount}");

    Console.WriteLine("######### Special Discounts Are as Follows. ############");

    PrintSpecialDiscounts();

}

static void PrintProducts(List<IProduct> productsMasterlist, bool forBill)
{
    if (forBill)
    {
        Console.WriteLine($"Prioduct#  {new string('\t', 5)} Product Name {new string('\t', 5)} Prise {new string('\t', 5)} Discount Offer {new string('\t', 5)} Quantity");
        foreach (var product in productsMasterlist)
        {
            Console.WriteLine($"{product.Id} {new string('\t', 5)} {product.Name} {new string('\t', 5)} {product.Prise} {new string('\t', 5)} {product.DiscountOffer.Description} {new string('\t', 5)} {product.Quantity}");
        }
    }
    else
    {
        Console.WriteLine($"Prioduct#  {new string('\t', 5)} Product Name {new string('\t', 5)} Prise {new string('\t', 5)} Discount Offer");
        foreach (var product in productsMasterlist)
        {
            Console.WriteLine($"{product.Id} {new string('\t', 5)} {product.Name} {new string('\t', 5)} {product.Prise} {new string('\t', 5)} {product.DiscountOffer.Description}");
        }
    }
}

static void PrintSpecialDiscounts()
{
    SpecialDayDiscountAccessor accessor = new SpecialDayDiscountAccessor();

    Console.WriteLine($"Day#  {new string('\t', 5)} Month {new string('\t', 5)} Discount Percentage");
    foreach (var discounts in accessor.GetSpecialDiscounts())
    {
        Console.WriteLine($"{discounts.Day} {new string('\t', 5)} {discounts.Month} {new string('\t', 5)} {discounts.DiscountPercentage}");
    }

}