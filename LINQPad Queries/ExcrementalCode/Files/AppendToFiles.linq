<Query Kind="Expression" />

        public void AddSuccessful(string recordType, IEnumerable<string> successfulRecords)
        {
            if (!successfulRecords.Any())
                return;

            var filePath = GetFilePath(recordType, "Successful");
            File.AppendAllLines(filePath, new []{$"Added {DateTime.Now.ToString("s")} --------------------------"});
            File.AppendAllLines(filePath, successfulRecords);
        }
