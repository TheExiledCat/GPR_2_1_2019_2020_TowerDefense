using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public static GameManager GM;
    public int HP;
    public int wave;
    public int enemiesPTurn;
    public int enemiesLeft = 0;
    public float SpawnRate;
    public float expo;
    public float cash = 0;
    public Sprite lockSprite;
    public GameObject portrait;
    public GameObject path1;
    public GameObject path2;
    public GameObject bar;
    public GameObject t;
    public List<GameObject> enemies;
    private void Start()
    {
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
       enemies.Add( Instantiate(enemy, transform.position, Quaternion.identity));
    }
    private void Update()
    {
        
       
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
            Debug.Log(hit.collider.gameObject);
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
        Debug.Log("Opening UI");
        Debug.Log(tower.name);
        bar.SetActive(true);
        portrait.GetComponent<Image>().sprite = tower.GetComponent<Tower>().uisprite;
        path1.GetComponent<Image>().sprite = tower.GetComponent<Tower>().path1.currentSprite;
        path2.GetComponent<Image>().sprite = tower.GetComponent<Tower>().path2.currentSprite;
    }
    void CloseUI()
    {

        Debug.Log("Closing UI");
        bar.SetActive(false);
    }
    public void UpgradePath1()
    {
        if (t.GetComponent<Tower>().path1.sprites.Length == 1)
        {
            if (t.GetComponent<Tower>().path1.objectName == "Bullet") { Instantiate(t.GetComponent<Tower>().towerOptions[0], t.transform.position, Quaternion.identity); }
            if (t.GetComponent<Tower>().path1.objectName == "Rocket") { Instantiate(t.GetComponent<Tower>().towerOptions[1], t.transform.position, Quaternion.identity); }
            Destroy(t.gameObject);
        }
        if (t.GetComponent<Tower>().path1.level < 4)
            t.GetComponent<Tower>().path1.level++;
        CloseUI();
    }
    public void UpgradePath2()
    {
        if (t.GetComponent<Tower>().path2.sprites.Length == 1)
        {
            if (t.GetComponent<Tower>().path2.objectName == "Bullet") { Instantiate(t.GetComponent<Tower>().towerOptions[0], t.transform.position, Quaternion.identity); }
            if (t.GetComponent<Tower>().path2.objectName == "Rocket") { Instantiate(t.GetComponent<Tower>().towerOptions[1], t.transform.position, Quaternion.identity); }
            Destroy(t.gameObject);
        }
        if (t.GetComponent<Tower>().path1.level < 4)
            t.GetComponent<Tower>().path1.level++;
        CloseUI();
    }

}
