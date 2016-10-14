using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct RestResponse
{
    public string Value;
    public string Error;

    public RestResponse(string value, string error)
    {
        Value = value;
        Error = error;
    }
}
