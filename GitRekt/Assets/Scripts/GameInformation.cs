public class GameInformation:MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    public static basePlayer Player { get; set; }

    public static baseSkill Spell1 { get; set; }
    public static baseSkill Spell2 { get; set; }
    public static baseSkill Spell3 { get; set; }
    public static baseSkill Spell4 { get; set; }

    public static int playerHealth { get; set; }
    public static int playerAttack { get; set; }
    public static int playerDefense { get; set; }
    public static int playerFlowMastery { get; set; }
    public static int playerFunctionMastery { get; set; }
    public static int playerDataStructureMastery { get; set; }
    public static int playerNetworkMastery { get; set; }
}
