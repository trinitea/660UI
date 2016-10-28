using System;

public struct PartTaker
{
    public string Name;
    public string LastName;
    public DateTime Birthday;
    public string CountryOfOrigin;
    public string Resume;

    public PartTaker(string name, string lastName, DateTime birthday, string countryOfOrigin, string resume)
    {
        Name = name;
        LastName = lastName;
        Birthday = birthday;
        CountryOfOrigin = countryOfOrigin;
        Resume = resume;
    }

    public static PartTaker CreateEmpty()
    {
        return new PartTaker("", "", new DateTime(), "", "");
    }
}
