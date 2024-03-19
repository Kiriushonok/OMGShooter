using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{

    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;

    private int _currentLvl = 1;
    private float _currentXP = 0;
    private float _targetXP = 100;

    public List<PlayerProgressLevel> levels;

    public void AddXP(float value)
    {
        _currentXP += value;
        
        if (_currentXP >= _targetXP)
        {
            SetLvl(_currentLvl + 1);
            _currentXP = 0;
        }
        DrawUI();
    }

    private void SetLvl(int value)
    {
        _currentLvl = value;
        _targetXP = levels[_currentLvl - 1].xpForNextLvl;
    }

    private void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_currentXP / _targetXP, 1);
        levelValueTMP.text = _currentLvl.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetLvl(_currentLvl);
        DrawUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
