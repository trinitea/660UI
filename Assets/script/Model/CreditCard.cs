using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public struct CreditCard
{
    public string Number;
    public DateTime ExpirationDate;
    public string CCV;

    public CreditCard(string number, DateTime expirationDate, string ccv)
    {
        Number = number;
        ExpirationDate = expirationDate;
        CCV = ccv;
    }
}
