﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleJSON;

[System.Serializable]
public class User
{
    public const int NEW_USER_ID = -1;

    public int ID { get; private set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Telephone { get; set; }
    public DateTime Birthday { get; set; }
    public CreditCard Card { get; set; }
    public Address ShippingAddress { get; set; }

    public User(string json)
    {
        var preUser = JSON.Parse(json);

        int id = NEW_USER_ID;
        Int32.TryParse(preUser["id_client"], out id); // id_client or id_user
        
        ID = id;
        Name = preUser["prenom"];
        LastName = preUser["nom"];
        Email = preUser["courriel"];
        Telephone = preUser["telephone"];
        Birthday = Convert.ToDateTime(preUser["anniversaire"]);

        // credit card
        Card = new CreditCard
        (
            preUser["carteDeCredit"]["numero"],
            preUser["carteDeCredit"]["type"],
            Convert.ToDateTime(preUser["carteDeCredit"]["expiration"]),
            preUser["carteDeCredit"]["ccv"]
        );

        // address
        ShippingAddress = new Address
        (
            preUser["adresse"]["numeroCivique"],
            preUser["adresse"]["rue"],
            preUser["adresse"]["ville"],
            preUser["adresse"]["province"],
            preUser["adresse"]["codePostal"]
        );
    }

    public User(int id) : this(id, "", "", "", "", new DateTime(), 
        new CreditCard("", "", new DateTime(), ""),
        new Address("", "", "", "", "")
        ) { }

    public User(int id, string name, string lastName, string courriel, string telephone, DateTime date, CreditCard creditCard, Address shippingAddress)
    {
        ID = id;
        Name = name;
        LastName = lastName;
        Email = courriel;
        Telephone = telephone;
        Birthday = date;

        Card = creditCard;
        ShippingAddress = shippingAddress;
    }

    public User Login()
    {
        return null;
    }
}
