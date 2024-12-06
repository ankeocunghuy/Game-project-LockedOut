using UnityEngine;
using UnityEngine.UI;

public class CreditCardPopupController : MonoBehaviour
{
    public GameObject creditCardPopup; 
    public Button submitButton;
    public InputField creditCardNumberInput;
    public InputField expirationDateInput;
    public InputField securityCodeInput; 

    private void Start()
    {
        // Initialize popup state
        creditCardPopup.SetActive(false);
    }

    // Call this function when the player interacts with the object
    public void ShowPopup()
    {
        creditCardPopup.SetActive(true);
    }

    // Call this function when the submit button is clicked
    public void SubmitCreditCardInfo()
    {
        Debug.Log("Credit card info submitted");
    }
}