using Common.Scene.Parameter;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InGame
{
    public class GameController : MonoBehaviour
    {
        public async UniTask Init(SceneParameterMain sceneParameterMain)
        {
            await UniTask.CompletedTask;
        }
    }
}
