using HuaweiMobileServices.Id;
using HuaweiMobileServices.Utils;
using UnityEngine;
using UnityEngine.UI;
using HmsPlugin;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class HomeHMS : MonoBehaviour
{

    public Text usuario;
    public Text monedas;
    private AccountManager accountManager;

      
    // Start is called before the first frame update
   
    void Start()
    {

        accountManager = AccountManager.GetInstance();
        accountManager.OnSignInSuccess = OnLoginSuccess;
        accountManager.OnSignInFailed = OnLoginFailure;

        usuario.text = "USUARIO: " + (PlayerPrefs.GetString("username")).ToUpper();

      
    }

    // Update is called once per frame
    void Update()
    {
        monedas.text = PlayerPrefs.GetInt("Monedas").ToString();
    }

    public void jugar() {
        SceneManager.LoadScene("Nivel1");
    }

    public void comprar() {    
        SceneManager.LoadScene("Shop");

    }


    public void LogIn()
    {
        accountManager.SignIn();
    }

    public void LogOut()
    {
        accountManager.SignOut();
        SceneManager.LoadScene("Login");

    }

    public void OnLoginSuccess(AuthHuaweiId authHuaweiId)
    {
        Debug.Log(authHuaweiId);
    }

    public void OnLoginFailure(HMSException error)
    {

    }
}
