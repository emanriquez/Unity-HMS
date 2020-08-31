using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using HuaweiMobileServices.Ads;
using HmsPlugin;

public class AdsDemoManager : MonoBehaviour
{

    private const string REWARD_AD_ID = "g44856g732";
    private const string INTERSTITIAL_AD_ID = "f7nujp9q9l";

    private RewardAdManager rewardAdManager;
    private InterstitalAdManager interstitialAdManager;

    // Start is called before the first frame update
    void Start()
    {
        InitRewardedAds();
        InitInterstitialAds();
    }

    private void InitRewardedAds()
    {
        rewardAdManager = RewardAdManager.GetInstance();
        rewardAdManager.AdId = REWARD_AD_ID;
        rewardAdManager.OnRewarded = OnRewarded;
       
    }

    private void InitInterstitialAds()
    {
        interstitialAdManager = InterstitalAdManager.GetInstance();
        interstitialAdManager.AdId = INTERSTITIAL_AD_ID;
        interstitialAdManager.OnAdClosed = OnInterstitialAdClosed;
    }

    public void ShowRewardedAd()
    {
        Debug.Log("[HMS] AdsDemoManager ShowRewardedAd");
        rewardAdManager.ShowRewardedAd();
    }

    public void ShowInterstitialAd()
    {
        Debug.Log("[HMS] AdsDemoManager ShowInterstitialAd");
        interstitialAdManager.ShowInterstitialAd();
    }

    public void OnRewarded(Reward reward)
    {
        Debug.Log("[HMS] ADS_rewarded!");

        int monedas = (PlayerPrefs.GetInt("Monedas")) + 10;
        PlayerPrefs.SetInt("Monedas", monedas);
        Debug.Log("MONEDAS"+monedas);


    }

    public void OnInterstitialAdClosed()
    {
        Debug.Log("[HMS] AdsDemoManager interstitial ad closed");
    }
}
