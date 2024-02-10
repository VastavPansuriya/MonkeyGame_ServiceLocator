using ServiceLocator.Player;
using ServiceLocator.Utilities;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] public PlayerScriptableObject playerScriptableObject;



    public PlayerService PlayerService { get; private set; }

    private void Start()
    {
        PlayerService = new PlayerService(playerScriptableObject);
    }

    private void Update()
    {
        PlayerService.Update();
    }
}
