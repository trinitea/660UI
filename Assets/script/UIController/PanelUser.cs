﻿using System;
using UnityEngine;
using UnityEngine.UI;

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

    // kit
    private int KitIndex = 0;
    public Color ActivatedColor;
    public Color DisabledColor;

    public Button BtnStarterKit;
    public Button BtnAverageKit;
    public Button BtnAdvancedKit;
    
    public void  SetWorkingAddress(Address address)
    {
        WorkingAddress = address;
    }

    public void CommitUser()
    {
        User newUser = new User(Parent.CurrentUser.ID);
        // should save stuff first and receive confirm

        newUser.Name = FirstNameField.text;
        newUser.LastName = LastNameField.text;
        newUser.Email = EmailField.text;
        newUser.Telephone = PhoneField.text;
        newUser.Birthday = Convert.ToDateTime(BirthDateField.text);

        newUser.Card = new CreditCard(
            CreditNumberField.text,
            CardTypeField.text,
            Convert.ToDateTime( DateTime.ParseExact(ExpirationField.text, "MM/yy", null)),
            CVVField.text
        );

        newUser.ShippingAddress = WorkingAddress;

        // dont change old password ...
        if (Parent.CurrentUser.ID == User.NEW_USER_ID) newUser.Password = PasswordField.text;

        RestHelper.Instance.UserCommit(newUser, ConfirmUser);
    }

    public void EditAddress()
    {
        Utility.Modal.ShowAddressDialog(WorkingAddress, ConfirmAddress);
    }

    public void ConfirmAddress(Address newAddress)
    {
        WorkingAddress = newAddress;
    }

    // not used for now
    public void ConfirmUser(RestResponse response)
    {
        if (string.IsNullOrEmpty(response.Error))
        {
            Parent.LoginSuccess(new User(response.Value));
            Parent.Logger.Message("Successful User Update / SignIn");
        }
        else
        {
            Parent.Logger.Message("User was not created / updated :\n" + response.Error);
        }
    }

    override public void Reset()
    {
        WorkingAddress = Parent.CurrentUser.ShippingAddress;

        FirstNameField.text = Parent.CurrentUser.Name;
        LastNameField.text = Parent.CurrentUser.LastName;
        EmailField.text = Parent.CurrentUser.Email;   
        PhoneField.text = Parent.CurrentUser.Telephone;
        BirthDateField.text = Parent.CurrentUser.Birthday.ToString("yyyy/MM/dd");

        CreditNumberField.text = Parent.CurrentUser.Card.Number;
        CardTypeField.text = Parent.CurrentUser.Card.Type;
        ExpirationField.text = Parent.CurrentUser.Card.ExpirationDate.ToString("MM/yy");
        CVVField.text = Parent.CurrentUser.Card.CCV;

        PasswordField.text = "";

        SetKitButton(KitIndex);

        if (Parent.CurrentUser.ID == User.NEW_USER_ID)
        {
            PasswordField.enabled = true;
            EmailField.enabled = true;
            CommitNote.text = "Create";
            Parent.Logger.Message("Please, join the dark side");
        }
        else
        {
            PasswordField.enabled = false;
            EmailField.enabled = false;
            CommitNote.text = "Update";
            Parent.Logger.Message("You can edit your user here");
        }
    }

    public void SetKitButton(int index)
    {
        switch (index)
        {
            case 0:
                BtnStarterKit.GetComponent<Image>().color = ActivatedColor;
                BtnAverageKit.GetComponent<Image>().color = DisabledColor;
                BtnAdvancedKit.GetComponent<Image>().color = DisabledColor;
                break;

            case 1:
                BtnStarterKit.GetComponent<Image>().color = DisabledColor;
                BtnAverageKit.GetComponent<Image>().color = ActivatedColor;
                BtnAdvancedKit.GetComponent<Image>().color = DisabledColor;
                break;

            case 2:
                BtnStarterKit.GetComponent<Image>().color = DisabledColor;
                BtnAverageKit.GetComponent<Image>().color = DisabledColor;
                BtnAdvancedKit.GetComponent<Image>().color = ActivatedColor;
                break;

            default:
                BtnStarterKit.GetComponent<Image>().color = DisabledColor;
                BtnAverageKit.GetComponent<Image>().color = DisabledColor;
                BtnAdvancedKit.GetComponent<Image>().color = DisabledColor;
                break;

        }

    }
}
