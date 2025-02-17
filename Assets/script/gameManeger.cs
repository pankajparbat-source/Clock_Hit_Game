using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class gameManeger : MonoBehaviour
{
    public static gameManeger Instance;

    [SerializeField] private List <GameObject> clockes;
    [SerializeField] private Sprite activeClockSprite;
   
    [SerializeField] private Sprite activeClockHandSprite;
   
    [SerializeField] private GameObject circlePrefab;

    private GameObject activeClockHand;
    private int[] speedArray = {150,-130,200,150,-250,110,-150,210,160,190,-200,150,-170,300,-250, -150, 210, 160, 190, -200, 150, -170, 300, -250 };
    public  List<int> listSpeed = new List<int>();
    private Vector3 spawnDirection;
    public bool swaapedalready = false;

    GameObject[] activeClock;
  //  private HashSet<GameObject> activeClocks = new HashSet<GameObject>();
    GameObject active;

    int id = 0;// for find out the Instance ID

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        
        initialized();
        for(int index=0;index<clockes.Count;index++)
        {
            listSpeed.Add(0);
            listSpeed[index] =speedArray[ Random.Range(0, speedArray.Length-1 )];
            Debug.Log(" listSpeed " + listSpeed[index]+ "[index]" + index);
           
        }

    }
    private void initialized()
    {
        int clockno = Random.Range(0, clockes.Count);
      
        clockes[clockno].GetComponent<SpriteRenderer>().sprite = activeClockSprite;
        clockes[clockno].tag = "active";
        GameObject chiled1 = clockes[clockno].transform.GetChild(0).gameObject;
        GameObject chiled2 = chiled1.transform.GetChild(0).gameObject;
        chiled2.GetComponent<SpriteRenderer>().sprite = activeClockHandSprite;
        chiled2.GetComponent<Transform>().localScale = new Vector3(0.29f, 0.31f, 1f);

       
    }
    void Update()
    {
        for (int index = 0; index < clockes.Count; index++)
        {
            if (clockes[index] != null)
            {
                clockes[index].transform.GetChild(0).gameObject.transform.Rotate(0, 0, Time.deltaTime * listSpeed[index]);
            }
        }
           if (Input.GetMouseButtonDown(0))
        {
           
            if(EventSystem.current==null)
            {
                Debug.Log("EventSystem.current is null");
            }
           
           else if (EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject())
            {
                SpawnCircle();
            }
           

        }
        mainMenuScrean();
        detection();
    }
    void mainMenuScrean()
    {
        if (clockes.Count == 1)
        {
           // Destroy(gameObject);
            DestroyImmediate(gameObject);
            UIManeger.Instance.mainMenuScreanWinCanvas();
           
           
        }
    }
    void SpawnCircle()
    {
        soundMangeger.Instance.playSound(soundName.move);
        activeClock = GameObject.FindGameObjectsWithTag("active");
      
        for (int index=0;index<activeClock.Length;index++)
        {
            if (activeClock[index].GetComponent<SpriteRenderer>().sprite.name == "active-clock")
            {
               
                if(id!= activeClock[index].GetInstanceID())
                {
                   id = activeClock[index].GetInstanceID();
                    Debug.Log("this is  not ");
                    Debug.Log("not swaapedalready");
                    activeClockHand = activeClock[index].transform.GetChild(0).gameObject;
                    spawnDirection = activeClockHand.transform.up;
                    GameObject ciecle = Instantiate(circlePrefab, activeClockHand.transform.position + spawnDirection, Quaternion.identity);
                    ciecle.AddComponent<Rigidbody2D>().velocity = spawnDirection * 15f;
                }

            }
        }
    }
    void detection()
    {
        if (collisionDetection.Instance != null)
        {
            if (collisionDetection.Instance.itsCollision)
            {
              
                DestroyImmediate(activeClock[0]);
            }
        }
    }

    public void removeFromList( GameObject DestroybaleGameObject)
    {
        for(int index=0;index<clockes.Count;index++)
        {
            if (DestroybaleGameObject == clockes[index])
            {
               clockes.RemoveAt(index);
                listSpeed.RemoveAt(index);
                
            }

        }
    }
    public void soundCanvas()
    {
        UIManeger.Instance.soundSettingScreanCanvas();
    }
    public void levelUp()
    {
        int scenlevel = SceneManager.GetActiveScene().buildIndex;
        scenlevel++;
        Debug.Log("Active Scene name is: " + SceneManager.GetActiveScene().name + "\nActive Scene index: " + SceneManager.GetActiveScene().buildIndex);
        if (scenlevel <= 10)
        {
            SceneManager.LoadScene(scenlevel);
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("ReachedIndex"))
            {
                PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
                PlayerPrefs.SetInt("UnLockedLevel", PlayerPrefs.GetInt("UnLockedLevel", 1) + 1);
                PlayerPrefs.Save();
            }
        }
        else
        {
            Debug.Log("levels completed");
        }
    }
}
