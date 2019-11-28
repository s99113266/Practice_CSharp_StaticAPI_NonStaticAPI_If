

using UnityEngine;

public class Zombie : MonoBehaviour
{

    [Header("殭屍HP")]
    public float ZombieHP = 100f;

    [Header("殭屍攻擊力")]
    public float ZombieATK;

    [Header("玩家")]
    public GameObject goPlayer;

    [Header("音源")]
    public AudioSource ZombieAudioSource;

    [Header("音效")]
    public AudioClip ZombieAudioClip;


    public void ZombieAttacked(float ZAAttacked)
    {

        if (goPlayer.GetComponent<Player>().PlayerHP > 0)
        {
            goPlayer.GetComponent<Player>().PlayerHP -= ZAAttacked;
            ZombieAudioSource = GetComponent<AudioSource>();
            ZombieAudioSource.clip = ZombieAudioClip;
            ZombieAudioSource.Play();

            print("殭屍受到傷害:" + ZAAttacked);
            print("殭屍剩餘血量:" + goPlayer.GetComponent<Player>().PlayerHP);
        }
        if(goPlayer.GetComponent<Player>().PlayerHP <= 0)
        {
            print("小屁還已經屁死了");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (ZombieHP <= 0) return;
            ZombieATK = Random.Range(0.1f, 50f);
            ZombieAttacked(ZombieATK);
        }
    }
}
