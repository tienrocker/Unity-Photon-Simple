public class UserData
{
    private int id;
    private string username;
    private string email;
    private string password;
    private string banned;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            username = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public string Banned
    {
        get
        {
            return banned;
        }

        set
        {
            banned = value;
        }
    }

    public UserData(int id, string username, string password, string email, string banned)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        Banned = banned;
    }
}
