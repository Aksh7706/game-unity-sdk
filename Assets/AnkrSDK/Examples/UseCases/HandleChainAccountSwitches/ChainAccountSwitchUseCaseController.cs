using AnkrSDK.WalletConnectSharp.Unity;
using TMPro;
using UnityEngine;

namespace AnkrSDK.UseCases.HandleChainAccountSwitches
{
	public class ChainAccountSwitchUseCaseController : UseCase
	{
		[SerializeField] private TMP_Text _logs;

		private void OnEnable()
		{
			WalletConnect.ActiveSession.OnAccountChanged += OnAccountChangedEvent;
			WalletConnect.ActiveSession.OnChainChanged += OnChainChangedEvent;
		}
		
		void OnApplicationFocus(bool pauseStatus) {
			if(pauseStatus){
				WalletConnect.ActiveSession.OnAccountChanged -= OnAccountChangedEvent;
				WalletConnect.ActiveSession.OnChainChanged -= OnChainChangedEvent;
			}
		}

		private void OnDestroy()
		{
			WalletConnect.ActiveSession.OnAccountChanged -= OnAccountChangedEvent;
			WalletConnect.ActiveSession.OnChainChanged -= OnChainChangedEvent;
		}

		private void OnAccountChangedEvent(object sender, string[] accounts)
		{
			_logs.text += "Account Changed, currently connected account : " + accounts[0] + "\n";
		}
		
		private void OnChainChangedEvent(object sender, int chainId)
		{
			_logs.text += "ChainID Changed, New ChainID: " + chainId + "\n";
		}
	}
}