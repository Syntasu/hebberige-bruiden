using System.Collections.Generic;
using WebMatrix.Data;
using System;

/// <summary>
/// Summary description for WishItems
/// </summary>
public class WishlistItemsModel : BaseModel
{
    public List<Item> GetWishlistItems(string code)
    {
        Database db = RequestDB();

        try
        {
            List<Item> items = new List<Item>();

            string query = @"SELECT i.item_name, i.item_price, i.item_desc, wl.item, wl.is_bought, wl.priority
                            FROM items as i, wishlist_items as wl
                            INNER JOIN items ON wl.item = items.id
                            WHERE i.id = wl.item AND wl.wishlist = @0 AND wl.is_bought =0
                            ORDER BY wl.priority DESC";

            dynamic result = db.Query(query, code);

            for (int i = 0; i < result.Count; i++)
            {
                dynamic row = result[i];

                Item item = new Item()
                {
                    Id = row.item,
                    ItemName = row.item_name,
                    ItemPrice = row.item_price,
                    ItemDesc = row.item_desc
                };

                items.Add(item);
            }

            return items;
        }
        finally
        {
            db.Dispose();
        }
    }

    public bool AddItemToWishlist(string code, Item item)
    {
        Database db = RequestDB();

        try
        {
            string query = "INSERT INTO wishlist_items VALUES (@0, @1, @2, @3)";
            int affected = db.Execute(query, item.Id, code, false, 0);

            return affected > 0;
        }
        finally
        {
            db.Dispose();
        }
    }

    public bool RemoveItemFromWishlist(string code, Item item)
    {
        Database db = RequestDB();
    
        try
        {
            string query = "DELETE FROM wishlist_items WHERE item=@0 AND wishlist=@1";
            int affected = db.Execute(query, item.Id, code);

            return affected > 0;
        }
        finally
        {
            db.Dispose();
        }
    }

    public bool AddPriority(string code, Item item)
    {
        Database db = RequestDB();

        try
        {
            string query = "UPDATE wishlist_items SET priority = priority + 1 WHERE item=@0 AND wishlist=@1";
            int affected = db.Execute(query, item.Id, code);

            return affected > 0;
        }
        finally
        {
            db.Dispose();
        }
    }

    public bool RemovePriority(string code, Item item)
    {
        Database db = RequestDB();

        try
        {
            string query = "UPDATE wishlist_items SET priority = priority - 1 WHERE item=@0 AND wishlist=@1";
            int affected = db.Execute(query, item.Id, code);

            return affected > 0;
        }
        finally
        {
            db.Dispose();
        }
    }

    public bool BuyFromWishlist(string code, Item item)
    {
        Database db = RequestDB();

        try
        {
            string query = "UPDATE wishlist_items SET is_bought = 1 WHERE item=@0 AND wishlist=@1";
            int affected = db.Execute(query, item.Id, code);

            return affected > 0;
        }
        finally
        {
            db.Dispose();
        }
    }

    public List<Item> GetBoughtItems(string code)
    {
        Database db = RequestDB();

        try
        {
            List<Item> items = new List<Item>();

            string query = @"SELECT i.item_name, i.item_price, i.item_desc, wl.item, wl.is_bought, wl.priority
                            FROM items as i, wishlist_items as wl
                            INNER JOIN items ON wl.item = items.id
                            WHERE i.id = wl.item AND wl.wishlist = @0 AND NOT wl.is_bought=0
                            ORDER BY wl.priority DESC";

            dynamic result = db.Query(query, code);

            for (int i = 0; i < result.Count; i++)
            {
                dynamic row = result[i];

                Item item = new Item()
                {
                    Id = row.item,
                    ItemName = row.item_name,
                    ItemPrice = row.item_price,
                    ItemDesc = row.item_desc
                };

                items.Add(item);
            }

            return items;
        }
        finally
        {
            db.Dispose();
        }
    }

}