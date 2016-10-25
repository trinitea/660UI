public struct Address
{
    public string CivicNumber;
    public string Street;
    public string Town;
    public string Province;
    public string PostalCode;

    public Address(string civicNumber, string street, string town, string province, string postalCode)
    {
        CivicNumber = civicNumber;
        Street = street;
        Town = town;
        Province = province;
        PostalCode = postalCode;
    }
}
