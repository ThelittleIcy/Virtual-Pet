using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singelton
    public PetBlackboard BlackBoard { get => m_blackBoard; set => m_blackBoard = value; }
    [SerializeField]
    private PetBlackboard m_blackBoard;
    public GameObject Player { get => m_player; set => m_player = value; }
    [SerializeField]
    private GameObject m_player;

    public GameObject Ball { get => m_ball; set => m_ball = value; }
    [SerializeField]
    private GameObject m_ball;

    public GameObject Enemy { get => m_enemy; set => m_enemy = value; }
    [SerializeField]
    private GameObject m_enemy;

    public GameObject Pillow { get => m_pillow; set => m_pillow = value; }
    [SerializeField]
    private GameObject m_pillow;

    public GameObject FleePlace { get => m_fleePlace; set => m_fleePlace = value; }
    [SerializeField]
    private GameObject m_fleePlace;

    public AnimationHandler Animations { get => m_animations; set => m_animations = value; }
    [SerializeField]
    private AnimationHandler m_animations;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        foreach (ScriptablePossibilitie pos in BlackBoard.AllPossibilities)
        {
            pos.Possibility = PlayerPrefs.GetInt(pos.name, pos.Possibility);
        }
        PlayerPrefs.DeleteAll();
    }

    public void ResetPossibilities()
    {
        foreach (ScriptablePossibilitie possibilitie in BlackBoard.AllPossibilities)
        {
            possibilitie.Possibility = 50;     
        }
    }
    private void OnApplicationQuit()
    {
        foreach (ScriptablePossibilitie pos in BlackBoard.AllPossibilities)
        {
            PlayerPrefs.SetInt(pos.name, pos.Possibility);
        }
        PlayerPrefs.Save();
    }

    [ContextMenu("ResetPlayerPrefs")]
    private void PlayerPrefReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
