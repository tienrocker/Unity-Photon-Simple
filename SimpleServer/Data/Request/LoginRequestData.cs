﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LoginRequestData
{
    public enum LoginType { NORMAL }
    public const byte LOGIN_DATA_TYPE = 1;
    public const byte LOGIN_DATA_USERNAME = 10;
    public const byte LOGIN_DATA_PASSWORD = 11;
}