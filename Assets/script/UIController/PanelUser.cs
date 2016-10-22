using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelUser : BasePanel
{
    public Text CommitNote;
    private Address WorkingAdress;

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

    public void init()
    {
        if(parent.CurrentUser == null)
        {
            CommitNote.text = "Create";
        }
        else
        {

        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
