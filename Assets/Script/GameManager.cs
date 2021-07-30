using UnityEngine;
using Tabtale.TTPlugins;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool levelCleared;
    public bool GameOver;
    public GameObject GameOverPanel;
    public GameObject RetryMenu;
    public int missionID;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
        TTPCore.Setup();

        //TTPBanners.Show();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        //int missionID = SceneManager.GetActiveScene().buildIndex + 1;

        //GameOver = false;
        //levelCleared = false;

        //TTPGameProgression.FirebaseEvents.MissionStarted(missionID);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {            
            //TTPGameProgression.FirebaseEvents.LevelUp(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver)
        {
            RetryMenu.SetActive(true);
            //TTPGameProgression.FirebaseEvents.MissionFailed();

            //TTPInterstitials.Show("levelFailed", () => {});
        }

        if (levelCleared)
        {
            GameOverPanel.SetActive(true);

            //TTPGameProgression.FirebaseEvents.MissionCompleted();
            //TTPGameProgression.FirebaseEvents.LevelUp(missionID + 1);
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    /* public void ShowRewardAd()
    {
        if (TTPRewardedAds.IsReady())

        {

            TTPRewardedAds.Show("LevelClearScreen", OnRewardedAdsResult);

        }

        else

        {

            OnRewardedAdsResult(false);

        }
    }
    private void OnRewardedAdsResult(bool isSuccess)

    {

        if (isSuccess)

        {
            int coinCount = PlayerPrefs.GetInt("coinAmount");
            coinCount += 100 ;
            PlayerPrefs.SetInt("coinAmount", coinCount);
        }
    }*/

    public void incrementScore()
    {
        int coinCount = PlayerPrefs.GetInt("coinAmount");
        coinCount += 1;
        PlayerPrefs.SetInt("coinAmount", coinCount);
    }
}
