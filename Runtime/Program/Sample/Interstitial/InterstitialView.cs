using YabbiSDK.Api;
using SspnetSDK.Unfiled;

namespace KinDzaDzaGames.AdvertisementPlugin
{
    public class InterstitialView : AdvertisementView
#if YABBI_AD
        , IInterstitialAdListener
#endif
    {
        public void Construct()
        {
#if YABBI_AD
            Yabbi.SetInterstitialCallbacks(this);
#endif
        }

        public void OnInterstitialLoaded(AdPayload adPayload)
        {
            AddLog("OnInterstitialLoaded");
        }

        public void OnInterstitialLoadFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnInterstitialLoadFailed: {error.Description}");
        }

        public void OnInterstitialShown(AdPayload adPayload)
        {
            AddLog("OnInterstitialShown");
        }

        public void OnInterstitialShowFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnInterstitialShowFailed: {error.Description}");
        }

        public void OnInterstitialClosed(AdPayload adPayload)
        {
            AddLog("OnInterstitialClosed");
        }

        protected override string GetPlacementName() => AdvertisingSettings.YabbiAds.yabbiInterstitialUnitID;
        protected override int GetAdType() => Yabbi.Interstitial;
    }
}
