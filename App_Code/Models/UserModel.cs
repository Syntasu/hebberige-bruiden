using System;
using WebMatrix.Data;

public enum RegisterState
{
    OK,
    UserExists,
    Unknown
}

public enum LoginState
{
    OK,
    Unknown,
    PasswordIncorrect,
    UserDoesNotExist
}

public class UserModel : BaseModel
{
    public RegisterState AddUser(User user)
    {
        Database db = RequestDB();

        Encryptor.GeneratePassword(user.Password, out string encryptedPassword, out string salt);

        try
        {
            if (HasUser(user))
            {
                return RegisterState.UserExists;
            }

            string query = "INSERT INTO users VALUES (@0,@1, @2, @3, @4)";
            int affected = db.Execute(query, user.Name, encryptedPassword, salt, DateTime.Now, "");

            if (affected < 1)
            {
                return RegisterState.Unknown;
            }
        }
        catch(Exception e)
        {
            LastError = e;
           return RegisterState.Unknown;
        }
        finally
        {
            db.Dispose();
        }

        return RegisterState.OK;
    }



    public bool HasUser(User user)
    {
        Database db = RequestDB();

        try
        {
            string query = "SELECT id FROM users WHERE name=@0";
            dynamic result = db.Query(query, user.Name);

            return result.Count >= 1;
        }
        finally
        {
            db.Dispose();
        }

    }
}
