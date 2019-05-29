using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace meddbase.Helpers
{
    partial class Global
    {
        public class TestDataRootObject
        {
            [JsonProperty("comment")]
            public string Comment { get; set; }

            [JsonProperty("logins")]
            public List<TestDataLoginObject> Logins { get; set; }

            [JsonProperty("systems")]
            public List<string> Systems { get; set; }
        }

        public class TestDataLoginObject
        {
            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public static TestDataRootObject JSON()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            TestDataRootObject JSON = JsonConvert.DeserializeObject<TestDataRootObject>(File.ReadAllText(projectDirectory + "\\Test Data\\dataset.json"));

            return JSON;
        }

        public static List<Tuple<string, string>> GetCredentials()
        {
            List<Tuple<string, string>> credentials = new List<Tuple<string, string>>();

            foreach (TestDataLoginObject login in JSON().Logins)
            {
                credentials.Add(Tuple.Create(login.Username.ToString(), login.Password.ToString()));
            }

            return credentials;
        }

        public static List<string> GetSystems()
        {
            List<string> systems = new List<string>();

            foreach (string system in JSON().Systems)
            {
                systems.Add(system);
            }

            return systems;
        }
    }
}
