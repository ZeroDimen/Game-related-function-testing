SceneField.cs 활용하여

loadtrigger.cs 에서있는 7, 8 라인

```csharp
  [SerializeField] private SceneField[] _scenesToLoad;
  [SerializeField] private SceneField[] _scenesToUnload;
```

를 통해 로드할 씬과 언로드할 씬을 인스팩터창에서 설정함

18번 라인 함수를 통해 영역에 닿았을경우 미리 설정해둔 씬로드 및 언로드 실행

```csharp
private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject == _Player)
        {
            LoadScenes();
            UnloadScenes();
        }
    } 
```
