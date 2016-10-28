using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelAddress : MonoBehaviour
{
    public PanelModal Parent { get; set; }

    public InputField CivicNumberField;
    public InputField StreetField;
    public InputField TownField;
    public InputField ProvinceField;
    public InputField PostalCodeField;

    Action<Address> Callback;

    public void SetAddress(Address currentAddress, Action<Address> callback)
    {
        Callback = callback;

        CivicNumberField.text = currentAddress.CivicNumber;
        StreetField.text = currentAddress.Street;
        TownField.text = currentAddress.Town;
        ProvinceField.text = currentAddress.Province;
        PostalCodeField.text = currentAddress.PostalCode;
    }

    public void Confirm()
    {
        Callback(new Address(
            CivicNumberField.text,
            StreetField.text,
            TownField.text,
            ProvinceField.text,
            PostalCodeField.text
        ));
        Parent.CloseAddress();
    }

    public void Reset()
    {
        Callback = null;

        CivicNumberField.text = "";
        StreetField.text = "";
        TownField.text = "";
        ProvinceField.text = "";
        PostalCodeField.text = "";
    }

    public void Close()
    {
        Reset();
        Parent.CloseAddress();
    }
}
