using Newtonsoft.Json;

namespace Ovicus.Caching
{
	public interface ISerializer
	{
		string Serialize(object value);
		object Deserialize(string binaryObj);
	}

	public class Serializer : ISerializer
	{
		public string Serialize(object value)
		{
			return JsonConvert.SerializeObject(value);
		}

		public object Deserialize(string binaryObj)
		{
			return JsonConvert.DeserializeObject(binaryObj);
		}
	}
}