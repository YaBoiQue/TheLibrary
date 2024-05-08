using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Transactionitem 
{
    public Transactionitem() { }
    public Transactionitem(int menuitemid, decimal price, int quantity)
    {
        MenuItemId = menuitemid;
        Quantity = quantity;
        Price = price;
    }

    public int TransactionItemId { get; set; }

    public int TransactionId { get; set; }

    public int MenuItemId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime? Timestamp { get; set; } = DateTime.Now;

    public virtual Menuitem MenuItem { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
