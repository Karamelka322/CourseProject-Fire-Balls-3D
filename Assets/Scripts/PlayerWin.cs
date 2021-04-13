using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerWin : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Tank _tank;
    [SerializeField] private LoadingScenes _loadingScenes;

    private Animator _animator;

    private readonly float _delayLoadScene = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _tower.SizeUpdate += OnUpdateTowerSize;
    }

    private void OnDisable()
    {
        _tower.SizeUpdate -= OnUpdateTowerSize;        
    }

    private void OnUpdateTowerSize(int size)
    {
        if (size == 0)
        {
            Win();
        }
    }

    private void Win()
    {
        _tank.IsAttack = false;
        _animator.Play("PlayerDead_Start");
    }

    public void OnClickBtnClose()
    {
        StartCoroutine(LoadStartScene(_delayLoadScene));
    }

    IEnumerator LoadStartScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        _loadingScenes.LoadScene("Main");
    }
}
