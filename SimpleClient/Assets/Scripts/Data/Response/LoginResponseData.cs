using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LoginResponseData
{
    public const byte CODE = 1;
    public const byte MESSAGE = 2;
}

class LoginResponseCode
{
    public const byte SUCCESS = 1;
    public const byte FAILED = 100;
}

class LoginResponseMessage
{
    public const string SUCCESS = "Đăng nhập thành công";
    public const string FAILED = "Đăng nhập thất bại";
}
