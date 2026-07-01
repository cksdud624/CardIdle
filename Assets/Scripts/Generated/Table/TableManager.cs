using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Generated.Table
{
	public class TableManager : MonoBehaviour
	{
		public LevelRecord LevelRecord {get; private set;}

		public async UniTask Init()
		{
			LevelRecord = new ();
			await LevelRecord.Init();
		}
	}
}
