using System.Collections.Generic;

public class WishlistController : BaseController
{
    public UserModel userModel = new UserModel();
    public WishlistItemsModel wishlistModel = new WishlistItemsModel();
    public ItemsModel itemModel = new ItemsModel();

    public string GetLoggedInUserWishList(string name)
    {
        User user = new User
        {
            Name = name
        };

        return userModel.GetUserWishList(user);
    }

    public bool CreateWhiteList(string name)
    {
        User user = new User()
        {
            Name = name
        };

        userModel.UpdateUserWishlist(user, CodeGenerator.GenerateCode(8));

        return true;
    }

    public bool AddToWishList(string code, string itemName, string desc, double price)
    {
        Item item = new Item
        {
            ItemName = itemName,
            ItemDesc = desc,
            ItemPrice = price
        };

        bool result = itemModel.AddItem(item);

        if(result)
        {
            Item fetchedItem = itemModel.GetItem(item);
            return wishlistModel.AddItemToWishlist(code, fetchedItem);
        }

        return false;
    }

    public bool RemoveFromWishlist(string code, string id, string itemName)
    {
        Item item = new Item()
        {
            Id = int.Parse(id),
            ItemName = itemName
        };

        bool result = itemModel.RemoveItem(item);

        if(result)
        {
            return wishlistModel.RemoveItemFromWishlist(code, item);
        }

        return false;
    }

    public List<Item> GetWishlistItems(string code)
    {
        return wishlistModel.GetWishlistItems(code);
    }
}