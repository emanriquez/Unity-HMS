# Huawei Mobile Services Plugin

REFERENCE : https://github.com/EvilMindDevs/hms-unity-plugin

HMS pluging para Mobile Service en Unity

* Huawei Account Kit
* In App purchases: Consumable and non consumables.
* Ads: Interstitial and rewarded videos
* Push notifications
* Game leaderboards and achievements

## Requeriminentos necesarios para proyecto
Android SDK min 21
Net 4.x

## Importante
soportado para 
Unity version 2019

## conecta hms en unity en 5 pasos

1. Registrate como developer en Huawei
2. Importar el proyecto ejemplo 
3. Configura el manifiesto
4. Conecta tu juego a HMS
5. Utiliza los prefab para integrar HMS

### 1 - Registrar en developer Huawei

#### 1.1-  Registrate en [Huawei Developer](https://developer.huawei.com/consumer/en/)

#### 1.2 - Crea tu app en AppGallery Connect.
Recuerda que app tiene un nombre de APP Build ID, este es muy importante para generar llaves y APK


1. Iniciar sesión y presiona **Console**.
2. Click en HUAWEI AppGallery 
3. En **AppGallery Connect** , click **My apps**.
4. EN **My apps**, click **New**.
5. Ingresa el nmbre, selecciona categoria y el lenguaje
6. Busca tu App ID and CPID asignado en tu AppGallery




#### 1.3 agregar Package Name
Configuramos el APK NAME

1.**Develop TAB**  ingresa el nombre de tu app manualmente **manually enter the package name**.
2. Una vez ingresado guarda tu nombre de Apk
3. Activa los SDK de HMS que usaras y descarga JSON en **Assets/Huawei/**



#### Genera a keystore.
Crea tu llave en unity para publicar proyecto en **Build Settings>PlayerSettings>Publishing settings**


#### Generar signing certificate fingerprint.

HMS te pide ver desde tu llave creada su registro en SH-256, para esto vamos a revisar esta llave para copiar parametros y llevar a app conect.

1. Abre el terminal de tu computadora, recuerda debes tener JDK instalado.
2. Corre el siguiente comando, (la ruta final es donde guardaste tu llave desde unity)

    ``keytool -list -v -keystore C:\app\juegodemo.keystore``
    
 Mi tienes error por lenguaje te recomiendo usar este comando :    
    ``keytool -J-Duser.language=en -list -v -keystore c:\app\juegodemo.keystore``
    
    
3. Ingresa la contraseña de tu llave creada en unity
4. Buscar el registro SHA-256 y copialo


#### Agregar fingerprint certificate to AppGallery Connect


1. En AppGallery Connect, click en  **Develop> Overview**
2. Vamos a  App information section and ingresar el SHA-256 fingerprint ya copiado anteriormente
3. Click √ en Guardar la fingerprint.

____

### 2 - Importar  plugin  Unity Project

import plugin:

1. Descarga de [.unitypackage](https://github.com/EvilMindDevs/hms-unity-plugin/releases)
2. Abre tu juego
3. Choose Assets> Import Package> Custom
![Import Package](http://evil-mind.com/huawei/images/importCustomPackage.png "Import package")
4. In the file explorer select the downloaded HMS Unity plugin. The Import Unity Package dialog box will appear, with all the items in the package pre-checked, ready to install.
![Import Dialog](http://evil-mind.com/huawei/images/unityImport.png "Import dialog")
5. Select Import and Unity will deploy the Unity plugin into your Assets Folder

*** te recomiendo actualizar DLL desde carpeta compartida de este GIT ya que tiene cambios nuevos****
____



### 3 - Configurar el Manifest

Necesitamos 
* App ID. The app's unique ID. (Buscalo en portal Developer)
* CPID. The developer's unique ID. (Buscalo en portal de Developer en IAP)
* Package Name

Get all this info from [Huawei Developer](https://developer.huawei.com/consumer/en/). Open the developers console go to My Services > HUAWEI IAP, and click on your apps name to enter the Detail page.

![Detail page](http://evil-mind.com/huawei/images/appInfo.png "Detail page")
____

#### Como debe quedar el manifest

1. Open Unity and choose **Huawei> App Gallery> Configure** The manifest configuration dialog will appear.

    ![Editor Tool](http://evil-mind.com/huawei/images/unityMenu.png "Editor tool")

2. Fill out the fields: AppID, CPID and package name.
3. La configuración permitida
    
    * Agregar los Permisos
    * Meta Datos
    * Provedores

Recueda que debes crearlo en Assent/Plugins/Android/AndroidManifest.xml

Ejemplo:

``` xml
<?xml version="1.0" encoding="utf-8"?>
    <manifest xmlns:android="http://schemas.android.com/apk/res/android" package="com.unity3d.player" xmlns:tools="http://schemas.android.com/tools" android:installLocation="preferExternal">
        <supports-screens android:smallScreens="true" android:normalScreens="true" android:largeScreens="true" android:xlargeScreens="true" android:anyDensity="true" />
        <application android:theme="@style/UnityThemeSelector" android:icon="@mipmap/app_icon" android:label="@string/app_name">
        <activity android:name="com.unity3d.player.UnityPlayerActivity" android:label="@string/app_name">
            <intent-filter>
            <action android:name="android.intent.action.MAIN" />
            <category android:name="android.intent.category.LAUNCHER" />
            </intent-filter>
            <meta-data android:name="unityplayer.UnityActivity" android:value="true" />
        </activity>
        <meta-data android:name="com.huawei.hms.client.appid" android:value="appid=9999" />
        <meta-data android:name="com.huawei.hms.client.cpid" android:value="cpid=1234567890" />
        <meta-data android:name="com.huawei.hms.version" android:value="2.6.1" />
        <provider android:name="com.huawei.hms.update.provider.UpdateProvider" android:authorities="com.yourco.huawei.hms.update.provider" android:exported="false" android:grantUriPermissions="true" />
        <provider android:name="com.huawei.updatesdk.fileprovider.UpdateSdkFileProvider" android:authorities="com.yourco.huawei.updateSdk.fileProvider" android:exported="false" android:grantUriPermissions="true" />
        </application>
        <uses-permission android:name="com.huawei.appmarket.service.commondata.permission.GET_COMMON_DATA" />
        <uses-permission android:name="android.permission.REQUEST_INSTALL_PACKAGES" />
        <uses-permission android:name="android.permission.INTERNET" />
        <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
        <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
        <uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />
        <uses-permission android:name="android.permission.READ_PHONE_STATE" />
    </manifest>
```
____
### 4 Conectar Pluging

Solo deberas arrestrar los Prefab ya creados a tu escenario de Unity, adicional podrás hacer otros script si fuera necesario.


#### Llamada de codigos

USE DEMO GIT C# UNITY


##### Account Kit (Scene login)
Ejemplo de Login por HMS con account kit
```csharp
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
    // button action
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


   
```


## Kits Specification
Otras funciones dentro de Pluging

1. Account
2. In App Purchases
3. Ads
4. Push notifications
5. Game

### Account

Official Documentation on Account Kit: [ Documentation](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/account-introduction-v4)

### In App Purchases

Official Documentation on IAP Kit: [ Documentation](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/iap-service-introduction-v4)

### Ads

Official Documentation on Ads Kit: [ Documentation](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/ads-sdk-introduction)

### Push

Official Documentation on Push Kit: [Documentation](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/push-introduction)

### Game

Official Documentation on Game Kit: [ Documentation](https://developer.huawei.com/consumer/en/doc/development/HMS-Guides/game-introduction-v4)

______

## License

This project is licensed under the MIT License




