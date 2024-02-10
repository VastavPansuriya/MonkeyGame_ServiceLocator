using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    [Header("PlayerService")]
    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    public PlayerService PlayerService { get; private set; } 

   
    [Space(),Header("SoundService")]
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    public SoundService SoundService { get; private set; }

    [Space(), Header("UIService")]
    [SerializeField] private UIService uIService;
    public UIService UIService => uIService;


    public EventService EventService { get; private set; }

    [Space(), Header("MapService")]
    [SerializeField] private MapScriptableObject mapScriptableObject;
    public MapService MapService { get; private set; }

    [Space(), Header("WaveService")]
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    public WaveService WaveService { get; private set; }
    private void Start()
    {
        PlayerService = new PlayerService(playerScriptableObject);
        SoundService = new SoundService(soundScriptableObject,audioEffects,backgroundMusic);
        EventService = new EventService();
        MapService = new MapService(mapScriptableObject);
        WaveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        PlayerService.Update();
    }
}
