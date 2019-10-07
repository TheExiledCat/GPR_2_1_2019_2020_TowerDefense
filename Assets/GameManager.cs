using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public static GameManager GM;
    public int HP;
    public int MaxHP;
    public int wave;
    public int enemiesPTurn;
    public int enemiesLeft = 400;
    public float SpawnRate;
    public float expo;
    public int cash = 0;
    public Sprite lockSprite;
    public GameObject portrait;
    public GameObject path1;
    public GameObject path2;
    public GameObject bar;
    public GameObject t;
    public GameObject hpbar;
    public List<GameObject> enemies;
    public GameObject enemyHpBar;
    private void Start()
    {
        HP = MaxHP;
        StartNextWave();
    }
    public void StartNextWave() {
        wave++;
        enemiesPTurn = (int)((Mathf.Pow(2, (wave * 0.2f)) + 3));
        enemiesLeft = enemiesPTurn;
        StartCoroutine(SpawnTimer());
    }
    public void LessEnemies()
    {
        enemiesLeft--;
    }
    public void Spawn()
    {
        GameObject en = Instantiate(enemy, transform.position, Quaternion.identity);
       enemies.Add(en);
        

    }
    public void TakeDmg(int damage)
    {
        HP -= damage;
        StartCoroutine(GetComponent<Shake>().shake(hpbar,1));
    }
    public void GetCash(int money)
    {
        cash += money;
    }

    private void Update()
    {
        if (cash < 0) cash = 0;
        if (HP > MaxHP) HP = MaxHP;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hit))
        {
            if (hit.collider.gameObject.GetComponent<Tower>()!=null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    OpenUI(hit.collider.gameObject);
                }
            }

        }
        if (Input.GetMouseButtonDown(1)) CloseUI();
        //enemies per turn exponentially grows
        enemiesPTurn = (int)((Mathf.Pow(2,  (wave * expo))+3));
        if (enemiesLeft == 0) StartNextWave();
        SpawnRate = 20 / enemiesPTurn;

    }
    private void Awake()
    {
        //set GM
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator SpawnTimer()
    {
        for(int i = 0; i < 20 * 60+1; i++)
        {
            if (i % (60 * SpawnRate) == 0)
            {
                Debug.Log("Spawning");
                Spawn();
            }
           yield return new WaitForEndOfFrame();
        }
       
    }
    void OpenUI(GameObject tower)
    {
        t = tower;
        
        bar.SetActive(true);
        portrait.GetComponent<Image>().sprite = tower.GetComponent<Tower>().uisprite;
        path1.GetComponent<Image>().sprite = tower.GetComponent<Tower>().path1sprite;
        path2.GetComponent<Image>().sprite = tower.GetComponent<Tower>().path2sprite;
    }
    void CloseUI()
    {

        Debug.Log("Closing UI");
        bar.SetActive(false);
    }
    public void UpgradePath1()
    {
        if (cash >= t.GetComponent<Tower>().cost)
        {


            if (t.GetComponent<Tower>().path1.sprites.Length == 1)
            {
                if (t.GetComponent<Tower>().path1.objectName == "Bullet") { Instantiate(t.GetComponent<Tower>().towerOptions[0], t.transform.position, Quaternion.identity); }
                if (t.GetComponent<Tower>().path1.objectName == "Rocket") { Instantiate(t.GetComponent<Tower>().towerOptions[1], t.transform.position, Quaternion.identity); }
                Destroy(t.gameObject);
            }
            if (t.GetComponent<Tower>().pathlvl1 < 4)
                t.GetComponent<Tower>().pathlvl1++;
            print(t.GetComponent<Tower>().pathlvl1);
            CloseUI();
            cash -= t.GetComponent<Tower>().cost;
        }
    }
    public void UpgradePath2()
    {
        if (cash >= t.GetComponent<Tower>().cost)
        {


            if (t.GetComponent<Tower>().path2.sprites.Length == 1)
            {
                if (t.GetComponent<Tower>().path2.objectName == "Bullet") { Instantiate(t.GetComponent<Tower>().towerOptions[0], t.transform.position, Quaternion.identity); }
                if (t.GetComponent<Tower>().path2.objectName == "Rocket") { Instantiate(t.GetComponent<Tower>().towerOptions[1], t.transform.position, Quaternion.identity); }
                Destroy(t.gameObject);
            }
            if (t.GetComponent<Tower>().pathlvl2 < 4)
                t.GetComponent<Tower>().pathlvl2++;
            print(t.GetComponent<Tower>().pathlvl2);
            CloseUI();
            cash -= t.GetComponent<Tower>().cost;
        }
    }

}
