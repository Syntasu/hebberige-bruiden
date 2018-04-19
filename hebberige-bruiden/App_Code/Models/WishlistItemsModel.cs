using System.Collections.Generic;
using WebMatrix.Data;

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

            string query = @"SELECT item_name, item_price, item_desc, item, is_bought, priority
                            FROM wishlist_items
                            INNER JOIN items ON wishlist_items.item = items.id
                            WHERE wishlist_items.wishlist = @0
                            ORDER BY priority DESC";

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