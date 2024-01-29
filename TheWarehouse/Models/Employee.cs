using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Employee
{
    public int IdEmployees { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
