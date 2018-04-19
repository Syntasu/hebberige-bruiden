public class WishlistController : BaseController
{
    public UserModel userModel = new UserModel();

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
}