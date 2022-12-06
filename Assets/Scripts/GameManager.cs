using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singelton
    // The BlackBoard of the Pet.
    public PetBlackboard BlackBoard { get => m_blackBoard; set => m_blackBoard = value; }
    [SerializeField]
    private PetBlackboard m_blackBoard;
    // The Player Gameobject.
    public GameObject Player { get => m_player; private set => m_player = value; }
    [SerializeField]
    private GameObject m_player;
    // The Ball Gameobject.
    public GameObject Ball { get => m_ball; set => m_ball = value; }
    [SerializeField]
    private GameObject m_ball;
    // The Enemy Gameobject.
    public GameObject Enemy { get => m_enemy; private set => m_enemy = value; }
    [SerializeField]
    private GameObject m_enemy;
    // The Pillow Gameobject.
    public GameObject Pillow { get => m_pillow; private set => m_pillow = value; }
    [SerializeField]
    private GameObject m_pillow;
    // The Place the Pet runs away to.
    public GameObject FleePlace { get => m_fleePlace; private set => m_fleePlace = value; }
    [SerializeField]
    private GameObject m_fleePlace;
    // The Animator the the Pet Animations.
    public AnimationHandler Animations { get => m_animations; set => m_animations = value; }
    [SerializeField]
    private AnimationHandler m_animations;
    // The Instance.
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private static GameManager _instance;
    /// <summary>
    /// Sets up the Singleton.
    /// Sets the Saved Possibilities.
    /// </summary>
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
    /// <summary>
    /// Resets all Possibilities
    /// </summary>
    public void ResetPossibilities()
    {
        foreach (ScriptablePossibilitie possibilitie in BlackBoard.AllPossibilities)
        {
            possibilitie.SetToDefault();
        }
    }
    /// <summary>
    /// Saves the Possibilities on Quit.
    /// </summary>
    private void OnApplicationQuit()
    {
        foreach (ScriptablePossibilitie pos in BlackBoard.AllPossibilities)
        {
            PlayerPrefs.SetInt(pos.name, pos.Possibility);
        }
        PlayerPrefs.Save();
    }
    /// <summary>
    /// Resets the Saved Possibilities.
    /// </summary>
    [ContextMenu("ResetPlayerPrefs")]
    private void PlayerPrefReset()
    {
        PlayerPrefs.DeleteAll();
    }
}
