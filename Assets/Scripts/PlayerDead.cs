using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerDead : MonoBehaviour
{
    [SerializeField] private Tank _tank;
    [SerializeField] private LoadingScenes _loadingScenes;

    private Animator _animator;
    private readonly float _delayLoadScene = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Dead()
    {
        _tank.IsAttack = false;
        _animator.Play("PlayerDead_Start");
    }

    public void OnClickBtnRestart()
    {
        StartCoroutine(LoadStartScene(_delayLoadScene));
    }

    IEnumerator LoadStartScene(float delay)
    {
        yield return new WaitForSeconds(delay);

        _loadingScenes.LoadScene("Main");
    }
}
