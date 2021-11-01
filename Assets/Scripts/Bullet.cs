using Lean.Pool;
using UnityEngine;
[RequireComponent (typeof (TrailRenderer))]
public class Bullet : MonoBehaviour, IPoolable {
    //public GameObject audiEffect;
    //public Transform Bullet;
    public float speed;
    public int numberBullet;
    public UPGRADE_controller upg_c;
    bool Spawned; //Уничтожена ли пуля
    int TimeSpawned; //
    //? Ща потестируем оба варинта =)j
    [SerializeField] private bool _isLocalMove = false;
    private TrailRenderer _trail;
    // public int Damage; //Урон пули
    Vector3 SpawnPos;
    private int Damage_and_upgrade; //Урон пули и бонус (установка через get и set)

    public int Damage {
        get => Damage_and_upgrade; //? => однострочная операция
        set => Damage_and_upgrade = (value + upg_c.Upgrade ("Damage"));
    }

    public float destroyTime;

    private void Awake () {
        _trail = GetComponent<TrailRenderer> ();
    }

    private void Destroybullet () {

        Debug.Log ("Destroybullet()");
        transform.rotation = Quaternion.identity;
        LeanPool.Despawn (gameObject);

    }

    void Destroy_by_time_and_distance () {
        if (Vector3.Distance (SpawnPos, transform.position) > 12f && Spawned == true) {
            Debug.Log ("Destroy_by_time_and_distance()");
            transform.rotation = Quaternion.identity;
            LeanPool.Despawn (gameObject);
            Spawned = false;
        } else if (Spawned == true) {
            Invoke ("Destroy_by_time_and_distance", destroyTime);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //? 1) Vector3.rigth - всегда летит вправо параллельно земле
        //? 2) transform.right - летит всегда права от себя, в звисимости от поворота
        //? 2 -ое более реалистичнее
        var moveDirection = _isLocalMove ? transform.right : Vector3.right;
        transform.Translate (moveDirection * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.TryGetComponent (out IDamagable damageble))
            if (!(damageble is PovokZKA)) {
                damageble.GetDamage (Damage);
                Debug.Log ("other.gameObject.name=" + other.gameObject.name + " TAG=" + other.gameObject.tag);
                Destroybullet ();
            } //? стрелять по всему кроме повозки 

    }

    public void OnSpawn () {
        Spawned = true;
        SpawnPos = transform.position;
        Debug.Log ("destroyTime=" + destroyTime);
        Invoke ("Destroy_by_time_and_distance", destroyTime);
    }

    public void OnDespawn () {
        _trail.Clear ();
    }
    /*
    public void AudioEffectOn(){
    audiEffect.SetActive(true);
    Invoke ("AudioEffectOff", 0.1f);
        }
    public void AudioEffectOff(){
    audiEffect.SetActive(false);
        }

    */

}