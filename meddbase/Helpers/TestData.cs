using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace meddbase
{
    class TestData
    {
        public class TestDataRootObject
        {
            [JsonProperty("logins")]
            public List<TestDataLoginObject> Logins { get; set; }
        }

        public class TestDataLoginObject
        {
            [JsonProperty("username")]
            public string Username { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }
        }

        public static List<Tuple<string, string>> GetCredentials()
        {
            List<Tuple<string, string>> credentials = new List<Tuple<string, string>>();

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            TestDataRootObject json = JsonConvert.DeserializeObject<TestDataRootObject>(File.ReadAllText(projectDirectory + "\\Test Data\\dataset.json"));

            foreach (TestDataLoginObject login in json.Logins)
            {
                credentials.Add(Tuple.Create(login.Username.ToString(), login.Password.ToString()));
            }

            return credentials;
        }
    }
}
