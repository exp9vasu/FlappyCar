using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject Coin;
    public TMP_Text Amount;
    public TMP_Text LevelX;
    public TMP_Text currentLevel;
    public TMP_Text nextLevel;

    public Image fillBarProgress;
    private float lastValue;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        LevelX.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex +1).ToString();

        currentLevel.text = (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        nextLevel.text = (SceneManager.GetActiveScene().buildIndex + 2).ToString();

        //PlayerPrefs.SetInt("coinAmount", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Amount.text = PlayerPrefs.GetInt("coinAmount").ToString();

        float traveledDistance = 55 - PlayerController3.instance.DistanceLeft;
        float value = traveledDistance / 55;

        fillBarProgress.fillAmount = Mathf.Lerp(fillBarProgress.fillAmount, value, 5 * Time.deltaTime);

        lastValue = value;
    }

    public void AnimateCoin()
    {
        Coin.GetComponent<Animator>().Play("uiCoin");
    }

    public void CoinStop()
    {
        Coin.GetComponent<Animator>().Play("uiCoinstop");
    }

}
