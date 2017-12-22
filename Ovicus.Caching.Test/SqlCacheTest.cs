using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ovicus.Caching.Test
{
	[TestClass]
	public class SqlCacheTest
	{
		private const string connectionString = "Data Source=.;Initial Catalog=CacheDatabase;Integrated Security=True";

		private ISerializer serializer;

		[TestInitialize]
		public void Setup()
		{
			serializer = new Serializer();
		}

		[TestCleanup]
		public void TearDown()
		{
			serializer = null;
		}

		[TestMethod]
		public void AddItem()
		{
			var key = "AddItem";
			var data = "data";
			var cache = new SqlCache(connectionString, serializer);
			cache.Add(key, data, DateTime.Now.AddMinutes(30));
			var result = cache.Contains(key);

			Assert.AreEqual(result, true);

			cache.Remove(key); // Clean DB for further testing
		}

		[TestMethod]
		public void RemoveItem()
		{
			var key = "RemoveItem";
			var data = "data";
			var cache = new SqlCache(connectionString, serializer);

			cache.Add(key, data, DateTime.Now.AddMinutes(30));

			cache.Remove(key);
			var result = cache.Contains(key);

			Assert.AreEqual(result, false);
		}

		[TestMethod]
		public void GetItem()
		{
			var key = "GetItem";
			var data = "data";
			var cache = new SqlCache(connectionString, serializer);
			cache.Add(key, data, DateTime.Now.AddMinutes(30));
			var getData = cache.Get(key);

			Assert.AreEqual(data, getData);

			cache.Remove(key); // Clean DB for further testing
		}

		[TestMethod]
		public void AddOrGetExisting()
		{
			var key = "AddOrGetExisting";
			var data = "data";
			var cache = new SqlCache(connectionString, serializer);

			// Try to get data
			var getData = cache.Get(key);
			Assert.IsNull(getData);

			// Add new entry
			getData = cache.AddOrGetExisting(key, data, DateTime.Now.AddMinutes(30));
			Assert.IsNull(getData);

			// Retrieve added entry
			getData = cache.AddOrGetExisting(key, data, DateTime.Now.AddMinutes(30));
			Assert.IsNotNull(getData);

			cache.Remove(key); // Clean DB for further testing
		}
	}
}