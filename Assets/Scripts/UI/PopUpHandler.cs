using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PopUpHandler : MonoBehaviour
{
    // Event for the Activation.
    public UnityEvent OnActivatedEvent;
    // Event for the Deactivation.
    public UnityEvent OnDeactivatedEvent;
    // The Text.
    [SerializeField]
    private TMP_Text m_text;
    // the Name of the Pet.
    [SerializeField]
    private ScriptableString m_name;
    // The Content.
    [SerializeField]
    private string m_message;
    // The Start Time.
    [SerializeField]
    private float m_startTimer = 10;
    // The currently time left.
    [SerializeField]
    private float m_timeRemaining = 10;
    /// <summary>
    /// Sets the time left to the start time.
    /// </summary>
    private void Awake()
    {
        m_timeRemaining = m_startTimer;
    }
    /// <summary>
    /// Activates and showes the Message.
    /// </summary>
    public void Activate()
    {
        if (m_name == null)
        {
            m_text.text = m_message;
        }
        else
        {
            m_text.text = m_name.Content + m_message;
        }
        m_timeRemaining = m_startTimer;
        StartCoroutine(Timer());
    }
    /// <summary>
    /// Deactivates the Message.
    /// </summary>
    public void Deactivate()
    {
        m_text.text = "";
    }
    /// <summary>
    /// Timer, when the Pop Up should disappear.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            m_timeRemaining -= 1;
            if (m_timeRemaining <= 0)
            {
                OnDeactivatedEvent.Invoke();
                yield break;
            }
        }
    }
}
