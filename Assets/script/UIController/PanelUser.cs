using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelUser : BasePanel
{
    private Address WorkingAddress;

    public Text CommitNote;

    public InputField FirstNameField;
    public InputField LastNameField;
    public InputField EmailField;
    public InputField PasswordField;
    public InputField PhoneField;
    public InputField BirthDateField;

    public InputField CreditNumberField;
    public InputField CardTypeField;
    public InputField ExpirationField;
    public InputField CVVField;

    public void Init()
    {
        if(Parent.CurrentUser == null)
        {
            CommitNote.text = "Create";
            WorkingAddress = Parent.CurrentUser.ShippingAddress;
        }
        else
        {
            CommitNote.text = "Commit";
            WorkingAddress = new Address("", "", "", "", "");
        }

    }
    
    public void  SetWorkingAddress(Address address)
    {
        WorkingAddress = address;
    }

    public void CommitUser()
    {

        // should save stuff first and receive confirm

        Parent.CurrentUser.Name = FirstNameField.text;
        Parent.CurrentUser.LastName = LastNameField.text;
        Parent.CurrentUser.Email = EmailField.text;
        Parent.CurrentUser.Telephone = PhoneField.text;
        Parent.CurrentUser.Birthday = Convert.ToDateTime(BirthDateField.text);

        Parent.CurrentUser.Card = new CreditCard(
            CreditNumberField.text,
            CardTypeField.text,
            Convert.ToDateTime( DateTime.ParseExact(ExpirationField.text, "mm/yy", null)),
            CVVField.text
        );
        
        Parent.CurrentUser.ShippingAddress = WorkingAddress;

        // dont change old password ...
        Parent.CurrentUser.Password = PasswordField.text;
    }

    public void EditAddress()
    {

    }

    // not used for now
    public void ConfirmUser()
    {

    }

    override public void Reset()
    {
        FirstNameField.text = "";
        LastNameField.text = "";
        EmailField.text = "";
        PasswordField.text = "";
        PhoneField.text = "";
        BirthDateField.text = "";

        CreditNumberField.text = "";
        CardTypeField.text = "";
        ExpirationField.text = "";
        CVVField.text = "";
    }
}
