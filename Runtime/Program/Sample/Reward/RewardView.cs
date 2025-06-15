using UnityEngine;
using YabbiSDK.Api;
using SspnetSDK.Unfiled;
using UnityEngine.UI;

namespace KinDzaDzaGames.AdvertisementPlugin
{
    public class RewardView : AdvertisementView, IRewardedAdListener
    {
        [SerializeField] private Button _hardRewardButton;

        private bool _softRewarded = false;
        private bool _hardRewarded = false;

        public void Construct()
        {
            Yabbi.SetRewardedCallbacks(this);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _hardRewardButton.onClick.AddListener(ShowHardReward);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _hardRewardButton.onClick.RemoveListener(ShowHardReward);
        }

        public void OnRewardedLoaded(AdPayload adPayload)
        {
            AddLog("OnRewardedLoaded");
        }

        public void OnRewardedLoadFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnRewardedLoadFailed: {error.Description}");
        }

        public void OnRewardedShowFailed(AdPayload adPayload, AdException error)
        {
            AddLog($"OnRewardedShowFailed: {error.Description}");
        }

        public void OnRewardedShown(AdPayload adPayload)
        {
            AddLog("OnRewardedShown");
        }

        public void OnRewardedClosed(AdPayload adPayload)
        {
            AddLog("OnRewardedClosed");
        }

        public void OnRewardedVideoStarted(AdPayload adPayload)
        {
            AddLog("OnRewardedVideoStarted");
        }

        public void OnRewardedVideoCompleted(AdPayload adPayload)
        {
            AddLog("OnRewardedVideoCompleted");
        }

        public void OnUserRewarded(AdPayload adPayload)
        {
            if (_softRewarded)
            {
                AddLog("OnUserRewarded with soft reward");
                _softRewarded = false;
            }
            else if (_hardRewarded)
            {
                AddLog("OnUserRewarded with hard reward");
                _hardRewarded = false;
            }
        }

        protected override string GetPlacementName() => AdvertisingSettings.YabbiAds.yabbiRewardedUnitID;
        protected override int GetAdType() => Yabbi.Rewarded;

        protected override void ShowButtonClick()
        {
            _softRewarded = true;
            base.ShowButtonClick();
        }

        protected override void ShowNotLoadedADWarning()
        {
            base.ShowNotLoadedADWarning();
            _softRewarded = false;
            _hardRewarded = false;
        }

        private void ShowHardReward()
        {
            _hardRewarded = true;
            base.ShowButtonClick();
        }
    }
}
