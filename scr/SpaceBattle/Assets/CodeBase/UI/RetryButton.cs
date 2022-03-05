using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI
{
    public class RetryButton : MonoBehaviour
    {
        private IProgressService _progressService;
        private IGameStateMachine _stateMachine;

        [Inject]
        public void Construct(IProgressService progressService, IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
        }

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClickButton);
        }

        private void OnClickButton()
        {
            _progressService.Progress.CurrentGameData.Reset();
            _stateMachine.Enter<StartGameState>();
        }
    }
}
