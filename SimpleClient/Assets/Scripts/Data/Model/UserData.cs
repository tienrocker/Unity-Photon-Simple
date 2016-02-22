public class UserData
{
    private int id;
    private string name;
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

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
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

    public UserData(int id, string name, string password, string email, string banned)
    {
        Id = id;
        Password = password;
        Email = email;
        Banned = banned;
    }
}
