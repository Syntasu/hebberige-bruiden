using System;
using WebMatrix.Data;

public class ItemsModel : BaseModel
{
    public bool AddItem(Item item)
    {
        Database db = RequestDB();

        try
        {
            string query = "INSERT INTO items VALUES (@0, @1, @2)";
            int affected = db.Execute(query, item.ItemName, item.ItemPrice, item.ItemDesc);

            return affected > 0;
        }
        finally
        {
            db.Dispose();
        }
    }

    public Item GetItem(Item item)
    {
        Database db = RequestDB();

        try
        {
            string query = "SELECT * FROM items WHERE item_name=@0";
            dynamic result = db.Query(query, item.ItemName);

            if (result.Count > 0)
            {
                dynamic row = result[0];

                return new Item()
                {
                    Id = row.id,
                    ItemName = row.item_name,
                    ItemDesc = row.item_desc,
                    ItemPrice = row.item_price
                };
            }

            return null;
        }
        finally
        {
            db.Dispose();
        }
    }
}