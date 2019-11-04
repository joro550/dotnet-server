using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;

namespace GlobalServer.Tests.Mocks
{
    public class MockFileSystemAdapter : MockFileSystem
    {
        private MockFileSystemAdapter(IDictionary<string, MockFileData> dictionary)
            :base(dictionary)
        {
            
        }

        public static MockFileSystemAdapter Create(string fileName, string fileContents)
        {
            return new MockFileSystemAdapter(new Dictionary<string, MockFileData>
            {
                { fileName, new MockFileData(fileContents) },
            });
        }
    }
}