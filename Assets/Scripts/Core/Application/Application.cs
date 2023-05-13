using UnityEngine;

public class Application : MonoBehaviour
{
    [SerializeField] private string _applicationName;
    [SerializeField] private string _applicationVersion;
    [SerializeField] private Level _level;
    [SerializeField] private HUDContainer _hudContainer;
    [SerializeField] private WindowContainer _windowContainer;
    [SerializeField] private DebugWindowBasicCheatsPanel _debugBasicCheatsPanelPrefab;
    [SerializeField] private HUDShowingFlagsController _hudShowingFlagsController;

    private Managers _managers = new();
    private Context _globalContext = new();
    private ActionsQueue _actionsQueue = new();
    private Location _location = new();
    private ApplicationDebugWindowDelegate _debugWindowDelegate = new();
    private ISDK _sdk;
    private IArchive _archive;

    public static Application Instance;
    public string ApplicationName => _applicationName;
    public string ApplicationVersion => _applicationVersion;
    public Level Level => _level;
    public Managers Managers => _managers;
    public StateGraph StateGraph => GetComponentInChildren<StateGraph>();
    public Context GlobalContext => _globalContext;
    public ActionsQueue ActionsQueue => _actionsQueue;
    public HUDContainer HUDContainer => _hudContainer;
    public Location Location => _location;
    public WindowContainer WindowContainer => _windowContainer;
    public DebugWindowBasicCheatsPanel DebugBasicCheatsPanelPrefab => _debugBasicCheatsPanelPrefab;
    public HUDShowingFlagsController HUDShowingFlagsController => _hudShowingFlagsController;
    public ISDK SDK => _sdk;
    public IArchive Archive => _archive;

    private void Awake()
    {
        Instance = this;
        Debug.Assert(Instance != null, "[Core] application singleton has not initialized!");

        Debug.Log("[Core] started");
        Debug.Log("ApplicationName = " + _applicationName);
        Debug.Log("ApplicationVersion = " + _applicationVersion);

        _sdk = SDKBuilder.CreateSDK();
        _archive = _sdk.GetArchive();

        var managersSetup = new ManagersSetup();
        managersSetup.Setup(_managers);

        _managers.OnInit();

        var stateGraph = StateGraph;
        if (stateGraph)
        {
            stateGraph.OnInit();
        }

        _debugWindowDelegate.Init();

        _hudShowingFlagsController.Init();
    }

    private void OnDestroy()
    {
        _managers.OnDeinit();

        var stateGraph = StateGraph;
        if (stateGraph)
        {
            stateGraph.OnDeinit();
        }
    }

    private void Update()
    {
        _managers.OnUpdate();

        var stateGraph = StateGraph;
        if (stateGraph)
        {
            stateGraph.OnUpdate();
        }

        _actionsQueue.OnUpdate();
    }

    private void FixedUpdate()
    {
        _managers.OnFixedUpdate();
    }
}
