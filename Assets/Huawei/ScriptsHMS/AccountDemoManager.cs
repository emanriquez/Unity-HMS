using HuaweiMobileServices.Id;
using HuaweiMobileServices.Utils;
using UnityEngine;
using UnityEngine.UI;
using HmsPlugin;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class AccountDemoManager : MonoBehaviour
{


   
   

    private AccountManager accountManager;



    public Text usuario;


    UnityEvent loadedEvent;


    void Awake()
    {
        Debug.Log("[HMS LOGIN]: USE LOGIN manager Init");


    }

    // Start is called before the first frame update
        void Start()
    {
        Debug.Log("[HMS]: Started");


        if (PlayerPrefs.GetInt("Monedas").ToString() == "") { PlayerPrefs.SetInt("Monedas", 0); }

        accountManager = GetComponent<AccountManager>();
        Debug.Log(accountManager.ToString());
        accountManager.OnSignInFailed = (error) =>
        {
            Debug.Log($"[HMSPlugin]: SignIn failed. {error.Message}");
        };
        accountManager.OnSignInSuccess = SignedIn;

    }

    public void loginhms() {
        accountManager.SignIn();
    }
    private void SignedIn(AuthHuaweiId authHuaweiId)
    {
        string username = string.Format(authHuaweiId.DisplayName); 

        PlayerPrefs.SetString("username", username);
       


        Debug.Log("[HMS]: SignedIn");
        SceneManager.LoadScene("Home");
    }


   
}
