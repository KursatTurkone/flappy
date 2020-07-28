using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class reklam : MonoBehaviour
{
    InterstitialAd interstitial;
    // Start is called before the first frame update
    static reklam reklamkontrol;
    void Start()
    {
        if (reklamkontrol == null)
        {
                DontDestroyOnLoad(gameObject);
                reklamkontrol = this;

            #if UNITY_ANDROID
                        string appId = "ca-app-pub-1944967107343324~5658554317";
            #elif UNITY_IPHONE
                             string adUnitId = "ca-app-pub-3940256099942544/4411468910";
            #else
                             string adUnitId = "unexpected_platform";
            #endif
                        MobileAds.Initialize(appId);
            #if UNITY_ANDROID
                        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
            #elif UNITY_IPHONE
                         string adUnitId = "ca-app-pub-3940256099942544/4411468910";
            #else
                         string adUnitId = "unexpected_platform";
            #endif
                interstitial = new InterstitialAd(adUnitId);
                AdRequest request = new AdRequest.Builder()
                  .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")
                  .Build();
                interstitial.LoadAd(request);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
   public void reklamiGoster()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }
}
    

