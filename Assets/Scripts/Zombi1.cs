using DG.Tweening;
using GameCore.DoTween;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;

using Lean.Pool;

[RequireComponent (typeof (Rigidbody2D))] // Обязывает иметь компонент RigidBody2D
public class Zombi1 : MonoBehaviour, IPoolable, IDamagable {
    QuestController QuestController_script;
    public UPGRADE_controller upg_c;
    [Header ("Характеристика Зомби")]
    // --- HP ---
    [SerializeField] public float _hp;
    // public float HP => _hp;
    private float _startHP;
    // --- Speed ---
    [SerializeField] public float _speed;
    private float _startSpeed;
    // --- Damage ---
    [SerializeField] public int _damage;

    [Header ("Все остальное")]
    public bool second = false;
    private PovokZKA _povozka;
    private LevelStats _levelStats;
    public int Damage_weapon; //Урон оружия

    //   public float hp_old;
    public float way;
    public float size_zombie;

    public GameObject Blood;

    [SerializeField] private Ui_Hp_Zombi healtBar_Zombi;

    public int Point; //Индекс случайной точки за которой следовать
    private State currentState; //текущее состояние (стреляет, перезаряжается или ничего не делает?)

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    [Header ("Сила отталкивания при смерти")]
    [SerializeField] private float _thrust = 100.0f; // Сила отталкивания при смерти
    [Header ("Сила отталкивания при выстреле")]
    [SerializeField] private float thrust_shoot = 10f; //Сила отталкивания при выстреле 

    private Camera cam; //Камера 

    private ResourcesManager _resorceManager;

    [Header ("Префабы текста")]
    [SerializeField] private GameObject TextDamage_red_prefab, TextDamage_yellow_prefab;

    [Header ("Смещение от полодения зомби")]
    [SerializeField] private Vector3 _damageTextOffset = Vector3.up * 1.5f;

    //Cылка на трансформ Canvas
    private Transform _canvasTransform; // =  GameObject.FindGameObjectWithTag("Canvas").transform;

    private SpriteRenderer _spriteRenderer;
    /// <summary>
    /// Частота атаки  если равно:
    ///      2 - 1 удар за 2 секунды 
    ///      1 - 1 раз в секунду  +
    ///    0.5 - 2 раза в секунду+
    ///   0.25 - 4 раза в секунду+
    /// </summary>
    [SerializeField] private float _attackRate = 1f;
    private float _lastAttackTime;
    private Camera _camera;

    public Vector3 PositionInUI => _camera.WorldToScreenPoint (transform.position);

    [SerializeField] public int reward_bread;
    [SerializeField] public int reward_exp;

    private void Awake () // Вызовиться один раз при первом появлении на сцене
    {
        _rigidbody2D = GetComponent<Rigidbody2D> ();
        _animator = GetComponent<Animator> ();
        _startHP = _hp;
        _startSpeed = _speed;

        _camera = Camera.main;
    }
    /// <summary>
    /// Вызывается в LeanPool когда Спавниться 
    /// </summary>
    public void OnSpawn () {
        SetState (State.Run);
    }
    /// <summary>
    /// Вызывается в LeanPool когда ДеСпавниться
    /// </summary>
    public void OnDespawn () {
        SetState (State.Del);
    }
    private void OnEnable () // вызовиться каждый раз когда делаешь gameObject.SetActive(true);
    {
        // Сброс значений на первоначальные 
        _hp = _startHP;
        _speed = _startSpeed;
        LivesUIZombi ();
    }
    private void Start () {
        QuestController_script = GameObject.FindGameObjectWithTag ("Povozka").GetComponent<QuestController> ();
        Debug.Log("QuestController_script SET="+QuestController_script);
        SetState (State.Run);

        _levelStats = GameObject.FindGameObjectWithTag ("ControllerBonus").GetComponent<LevelStats> ();
        _resorceManager = GameObject.FindGameObjectWithTag ("UIManager").GetComponent<ResourcesManager> ();

        _canvasTransform = GameObject.FindGameObjectWithTag ("Canvas").transform;

        cam = Camera.main;

        Point = Random.Range (0, 3);

        InvokeRepeating ("OneSecond", 1, 1.0F); //
        _povozka = GameObject.FindGameObjectWithTag ("Povozka").GetComponent<PovokZKA> ();
        _spriteRenderer = GetComponent<SpriteRenderer> ();

    }
    private void Run () {
        if (_povozka != null) // Если повозка уничтожена, то никуда не идти.
        {
            Vector3 some_position = _povozka.Points[Point].transform.position;
           transform.position = Vector3.MoveTowards (transform.position, some_position, (_speed+1) * Time.deltaTime); //Идем прямо к повозке
        }
    }
    private void Attack () {
        if (_povozka) {
            if (_lastAttackTime + _attackRate <= Time.time) {
                _lastAttackTime = Time.time;
                _povozka.GetDamage (_damage);
            }
        }
    }
    void FixedUpdate () {
        switch (currentState) {
            case State.Run:
                Run ();
                break;
            case State.Attack:
                Attack ();
                break;
            case State.Del:
                _rigidbody2D.AddForce (transform.right * _thrust);
                break;
        }
    }

    void DisplayDamage (float dmg_display) {
        Vector3 damageTextPoint = transform.position + _damageTextOffset;
        Vector3 position = Camera.main.WorldToScreenPoint (damageTextPoint);

        GameObject textPrefab;

        bool isCritDamage = dmg_display > (_startHP * 0.30f);

        if (isCritDamage)
            textPrefab = TextDamage_red_prefab;
        else
            textPrefab = TextDamage_yellow_prefab;

        GameObject textGO = LeanPool.Spawn (textPrefab, position, Quaternion.identity, _canvasTransform);

        textGO.GetComponent<Text> ().text = $"-{dmg_display}";

        textGO.transform
            .DOLocalMoveY (textGO.transform.localPosition.y + 100f, 1f)
            .OnComplete (() => LeanPool.Despawn (textGO));

        ImageAlphaTween imageAlphaTween = textGO.GetComponent<ImageAlphaTween> ();
        // Debug.Log($"imageAlphaTween : {imageAlphaTween}");
        imageAlphaTween.DoTween ();
    }

    public void PushOff () { //Выключает отталкивание (вызывает отталкивание с отрицательным значением и скорость толкания становиться равной 0,но только если было сделано толкание)
        _rigidbody2D.AddForce (transform.right * -thrust_shoot, ForceMode2D.Impulse);

    }

    public void LivesUIZombi () //Отрисовать хп у зомби
    {
        healtBar_Zombi.SetSize (_hp / _startHP);
    }

    public void Change_size (float new_size) { //Изменить размер зомби
        transform.localScale = Vector3.one * new_size;
    }

    public void OneSecond () {
        second = true;
    }
    public void OffBlood () {
        Blood.SetActive (false);
    }

    public void SpawnCoin_delay () {
        _resorceManager.SpawnCoin (PositionInUI);
    }
    public void SpawnCube_delay () {
        _resorceManager.SpawnCube (PositionInUI);
    }

    public void GetDamage (int damage) {
        _hp -= damage;
        jizn ();
        DisplayDamage (damage);

    }

    /// <summary>
    /// вызывается при попадание пули в зомби
    /// </summary>
    public void jizn () {

        Blood.SetActive (true);

        Invoke ("OffBlood", 0.2f);
        LivesUIZombi ();
        if (_hp <= 0) {
            //Manager_On.SpawnCoin (this.gameObject);
            Invoke ("SpawnCoin_delay", Random.Range (0.0f, 0.3f));
            Invoke ("SpawnCube_delay", Random.Range (0.0f, 0.3f));

            _levelStats.RewardInt ("Bread", (reward_bread + 2 + upg_c.Upgrade ("Bread")));
            _levelStats.RewardInt ("Tooth", (reward_exp + 1 + upg_c.Upgrade ("Exp")));
            _levelStats.RewardInt ("Kill_mobs",PlayerPrefs.GetInt ("Current_opened_level"));


            SetState (State.Del);
            _speed = 0;

            QuestController_script.AddValueToQuest ("Q_KillZombies", 1);
            Invoke ("ZombiStop", 1f);

        }
        //Отталкивание зомби при попадание пули
        _rigidbody2D.AddForce (transform.right * thrust_shoot, ForceMode2D.Impulse);
        Invoke ("PushOff", 0.05f); //Время ооталкивания при выстреле
    }

    public void ZombiStop () {
        LeanPool.Despawn (gameObject);
    }
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.TryGetComponent (out IDamagable target)) {
            if (target is PovokZKA)
                SetState (State.Attack);
        }
    }
    private void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.TryGetComponent (out IDamagable target))
            if (target is PovokZKA)
                SetState (State.Run);

    }
    //* Опимизация
    //? Кэшируем параметры аниматоры в Int  
    private static int _runAnimtorParameter = Animator.StringToHash ("Run");
    private static int _attackAnimtorParameter = Animator.StringToHash ("Attack");
    private static int _deathAnimtorParameter = Animator.StringToHash ("Death");

    private void SetState (State state) {
        currentState = state;
        _animator.SetBool (_runAnimtorParameter, state == State.Run);
        _animator.SetBool (_attackAnimtorParameter, state == State.Attack);
        _animator.SetBool (_deathAnimtorParameter, state == State.Del);
    }

    private enum State {
        Run,
        Del,
        Attack
    }
}