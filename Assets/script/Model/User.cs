using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleJSON;

[System.Serializable]
public class User
{
    public int ID { get; private set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Telephone { get; set; }
    public DateTime Birthday { get; set; }
    public CreditCard Card { get; set; }
    public Address ShippingAddress { get; set; }

    public User(string json)
    {
        var preUser = JSON.Parse(json);

        int id = -1;
        Int32.TryParse(preUser["id_client"], out id); // id_client or id_user
        
        ID = id;
        Name = preUser["prenom"];
        LastName = preUser["nom"];
        Email = preUser["courriel"];
        Telephone = preUser["telephone"];
        Birthday = Convert.ToDateTime(preUser["anniversaire"]);
    }

    public User(int iD) : this(iD, "", "", "", "", new DateTime(), new CreditCard("", new DateTime(), "")) { }

    public User(int iD, string name, string lastName, string courriel, string telephone, DateTime date, CreditCard creditCard)
    {
        ID = ID;
        Name = name;
        LastName = lastName;
        Email = courriel;
        Telephone = telephone;
        Birthday = date;
        Card = creditCard;
    }

    public User Login()
    {
        return null;
    }
}
