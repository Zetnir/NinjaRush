using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerScript : MonoBehaviour {

    const int PLAYER_MAX_HP = 3;
    private LayerMask enemyLayer;

    private int score_ = 0;
    private bool isDead_ = false;
    public int playerHP = 3;

    private Vector3 standardPosition = new Vector3(0.12f, -3.881f, 42.86f);

    private Quaternion menuRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion inGameRotation = Quaternion.Euler(0, 180, 0);

    private float timeNow;
    private float timeDelay;
    private bool isSmoking = false;
    private float speedMovement = 5f;
    private float speedRotation = 2f;

    public GameObject fXSmoke;

    public enum PlayerStates
    {
        IDLE,
        TURN_TO_MENU,
        TURN_TO_GAME,
        ATTACK,
        RUN,
        GET_HIT
    }
    public PlayerStates playerStates = PlayerStates.IDLE;

    public Animator anim;

    [System.Serializable]
    public class SavingData
    {
        int maxScore=0;
        int pieces=0;
        int resurection=0;

        public SavingData(SavingData newData)
        {
            maxScore = newData.maxScore;
            pieces = newData.pieces;
            resurection = newData.resurection;
        }

        public int GetMaxScore()
        {
            return maxScore;
        }

        /// <summary>
        /// Change le score max si le score passé en parametre est plus élevé
        /// </summary>
        /// <param name="score"></param>
        public void DefineMaxScore(int score)
        {
            if (score > maxScore)
                maxScore = score;
        }
    }
    public SavingData data;
    // Use this for initialization

    void Start() {
        enemyLayer = LayerMask.GetMask("Enemy");
        fXSmoke.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        timeNow = Time.time;
        switch (playerStates)
        {
            case PlayerStates.IDLE:
                break;
            case PlayerStates.ATTACK:
                //anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);
                if(timeDelay - timeNow < 0)
                {
                    playerStates = PlayerStates.RUN;
                    fXSmoke.SetActive(false);
                    //isSmoking = false;
                }
                break;
            case PlayerStates.RUN:
                anim.SetBool("isRunning", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isGettingHit", false);
                SetInGamePosition();
                break;
            case PlayerStates.GET_HIT:
                //anim.SetBool("isRunning", true);
                anim.SetBool("isGettingHit", false);
                break;

            case PlayerStates.TURN_TO_GAME:
                if(transform.rotation!= inGameRotation)
                {
                    SetInGamePosition();
                }
                else
                {
                    playerStates = PlayerStates.RUN;
                }
                break;
            case PlayerStates.TURN_TO_MENU:
                if (transform.rotation != inGameRotation)
                {
                    SetMenuPosition();
                }
                else
                {
                    playerStates = PlayerStates.IDLE;
                }
                break;

        }
    }

    public void ClickOnScreen()
    {
        RaycastHit hit;
        Ray ray = /*Camera.main.ScreenPointToRay(Input.GetTouch(0).position)*/Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f, enemyLayer.value))
        {
            if (hit.transform)
            {
                int points = hit.transform.gameObject.GetComponent<EnemyScript>().OnFight();
                ScoreAugmentation(points);
                if (hit.transform.GetComponent<ArmorEnemyScript>())
                {
                    Vector3 hitPosition = hit.transform.GetChild(0).position;
                    transform.position =new Vector3(hitPosition.x, hitPosition.y, hitPosition.z+0.75f);
                    timeDelay = Time.time;
                    //if(!isSmoking)
                    //{
                    //    fXSmoke.SetActive(true);
                    //    isSmoking = true;
                    //}
                }
                else
                {
                    Vector3 hitPosition = hit.transform.position;
                    transform.position = new Vector3(hitPosition.x, hitPosition.y, hitPosition.z + 0.75f);
                    fXSmoke.SetActive(true);
                    //isSmoking = true;
                    timeDelay = timeNow + 0.25f;
                }
                playerStates = PlayerStates.ATTACK;
                
            }
        }

    }
    public void ScoreAugmentation(int points)
    {
        SetScore(score_ + points);
    }

    public int GetScore()
    {
        return score_;
    }

    public void SetScore(int score)
    {
        this.score_ = score;
    }

    public void ResetScore()
    {
        SetScore(0);
    }

    public bool GetIsDead()
    {
        return isDead_;
    }

    public void SetIsDead(bool val)
    {
        isDead_ = val;
    }

    public void LoseHP()
    {
        playerHP--;
        if (playerHP < 1)
            SetIsDead(true);
    }

    public void ResetHP()
    {
        playerHP = PLAYER_MAX_HP;
        SetIsDead(false);
    }

    public void SetMenuPosition()
    {
        transform.position = Vector3.Lerp(transform.position, standardPosition, speedMovement * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, menuRotation, speedRotation * Time.deltaTime);
    }

    public void SetInGamePosition()
    {
        //transform.position = Vector3.Lerp(transform.position, standardPosition, speedMovement * Time.deltaTime);
        transform.position =standardPosition;
        transform.rotation = Quaternion.Lerp(transform.rotation, inGameRotation, speedRotation * Time.deltaTime);
    }

    public void WriteData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/data.sav", FileMode.Create);
        SavingData newData = new SavingData(data);
        bf.Serialize(stream, newData);
        stream.Close();
    }

    public void ReadData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/data.sav", FileMode.Open);
        SavingData oldData = bf.Deserialize(stream) as SavingData;
        data = oldData;
        stream.Close();
    }

}
