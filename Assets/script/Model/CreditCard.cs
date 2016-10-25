using System;

public struct CreditCard
{
    public string Number;
    public string Type;
    public DateTime ExpirationDate;
    public string CCV;

    public CreditCard(string number, string type, DateTime expirationDate, string ccv)
    {
        Number = number;
        Type = type;
        ExpirationDate = expirationDate;
        CCV = ccv;
    }
}
