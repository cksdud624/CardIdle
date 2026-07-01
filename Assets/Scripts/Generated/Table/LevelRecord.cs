using System.IO;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Generated.Table
{
	public partial class LevelRecord
	{
		private const string Key = "Assets/Generated/Table/Level.bytes";
		private List<LevelData> datas = new();
		private Dictionary<long, LevelData> datasById = new();
		partial void InitCustomRecord();
		public async UniTask Init()
		{
			var asset = await Addressables.LoadAssetAsync<TextAsset>(Key).ToUniTask();
			if(asset == null)
				throw new System.OperationCanceledException($"Load failed: {Key}");
			using (MemoryStream ms = new MemoryStream(asset.bytes))
			using (BinaryReader reader = new BinaryReader(ms))
			{
				while (reader.BaseStream.Position < reader.BaseStream.Length)
				{
					LevelData data = new (reader);
					datas.Add(data);
					datasById.Add(data.Id, data);
				}
			}
			InitCustomRecord();
		}
		public LevelData GetRecord(long id)
		{
			datasById.TryGetValue(id, out var record);
			return record;
		}
		public List<LevelData> GetAllRecord()
		{
			return datas;
		}
	}

	public class LevelData
	{
		public long Id {get; private set;}
		public long Level {get; private set;}
		public long HeatPoint_Man {get; private set;}
		public int HeatPoint_Exp {get; private set;}
		public long AttackDamage_Man {get; private set;}
		public int AttackDamage_Exp {get; private set;}
		public long Defense_Man {get; private set;}
		public int Defense_Exp {get; private set;}

		public LevelData(BinaryReader reader)
		{
			string[] tableDatas = reader.ReadString().Split('	');
			Id = long.TryParse(tableDatas[0], out long vLong0) ? vLong0 : 0L;
			Level = long.TryParse(tableDatas[1], out long vLong1) ? vLong1 : 0L;
			HeatPoint_Man = long.TryParse(tableDatas[2], out long vLong2) ? vLong2 : 0L;
			HeatPoint_Exp = int.TryParse(tableDatas[3], out int vInt3) ? vInt3 : 0;
			AttackDamage_Man = long.TryParse(tableDatas[4], out long vLong4) ? vLong4 : 0L;
			AttackDamage_Exp = int.TryParse(tableDatas[5], out int vInt5) ? vInt5 : 0;
			Defense_Man = long.TryParse(tableDatas[6], out long vLong6) ? vLong6 : 0L;
			Defense_Exp = int.TryParse(tableDatas[7], out int vInt7) ? vInt7 : 0;
		}
	}
}
