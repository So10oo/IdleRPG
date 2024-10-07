using System;
using UnityEngine;
using Zenject;

public abstract class Character : MonoBehaviour
{
    [Header("Characteristics")]
    [SerializeField] CharacteristicsData _characteristicsData;
    public CharacteristicsData characteristicsData => _characteristicsData;

    [Header("Animations")]
    [SerializeField] Animator characterAnimator;
    public Animator animator => characterAnimator;

    [Header("TimerBar")]
    [SerializeField] ProgressBarView characterTimerBar;
    public ProgressBarView timerBar => characterTimerBar;

    [Header("HealthBar")]
    [SerializeField] ProgressNumericalBarView _healthBar;
    public ProgressNumericalBarView healthBar => _healthBar;

    public Characteristics characteristics { get; protected set; }

    public Action<Character> OnAttack;

    #region Stats
    public AttackingState attackingState { get; protected set; }
    public DeadCharacterState deadState { get; protected set; }
    public PreparatoryState preparatoryState { get; protected set; }
    public IdleState idleState { get; protected set; }
    #endregion

    #region MonoBehaviour 

    [Inject]
    void Construct()
    {
        characteristics = new Characteristics(characteristicsData);
    }
    private void Awake()
    {
        AwakeMonoBehaviour();
    }
    private void Start()
    {
        StartMonoBehaviour();
    }
    protected virtual void AwakeMonoBehaviour()
    {
        characteristics.Health.OnCurrentValueChange += OnHealthUpdate;
        characteristics.Health.OnValueChange += OnHealthUpdate;
    }
    protected virtual void StartMonoBehaviour()
    {
        characteristics.Health.Recover();
        animator.Play("Idle");
    }
    private void OnDestroy()
    {
        characteristics.Health.OnCurrentValueChange -= OnHealthUpdate;
        characteristics.Health.OnValueChange -= OnHealthUpdate;
    }
    #endregion

    void OnHealthUpdate(int empty)
    {
        var hp = characteristics.Health;
        healthBar.SetProgress(hp.CurrentValue, hp.Value);
    }

}

