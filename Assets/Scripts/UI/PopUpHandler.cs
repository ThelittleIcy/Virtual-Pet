using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PopUpHandler : MonoBehaviour
{
    public UnityEvent OnActivatedEvent;

    public UnityEvent OnDeactivatedEvent;

    [SerializeField]
    private TMP_Text m_text;
    [SerializeField]
    private ScriptableString m_name;

    [SerializeField]
    private string m_message;

    [SerializeField]
    private float m_startTimer = 10;
    [SerializeField]
    private float m_timeRemaining = 10;

    private void Awake()
    {
        m_timeRemaining = m_startTimer;
    }

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

    public void Deactivate()
    {
        m_text.text = "";
    }

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
