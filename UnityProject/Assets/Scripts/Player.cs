using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("玩家HP")]
    public float PlayerHP = 100f;


    [Header("玩家攻擊力")]
    public float PlayerATK;

    [Header("殭屍")]
    public GameObject goZombie;

    [Header("音源")]
    public AudioSource PlayerAudioSource;

    [Header("音效")]
    public AudioClip PlayerAudioClip;
    public void PlayerAttacked(float PAValue)
    {

        if (goZombie.GetComponent<Zombie>().ZombieHP > 0)
        {
            goZombie.GetComponent<Zombie>().ZombieHP -= PAValue;
            PlayerAudioSource.clip = PlayerAudioClip;
            PlayerAudioSource.Play();
            print("殭屍受到傷害:" + PAValue);
            print("殭屍剩餘血量:" + goZombie.GetComponent<Zombie>().ZombieHP);
        }
        if(goZombie.GetComponent<Zombie>().ZombieHP <= 0)
        {
            print("殭屍已經死亡");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (PlayerHP <= 0) return;
            PlayerATK = Random.Range(0.1f, 50f);
            PlayerAttacked(PlayerATK);
        }
    }
}
