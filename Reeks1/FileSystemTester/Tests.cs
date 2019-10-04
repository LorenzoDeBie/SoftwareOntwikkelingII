using System;
using FileSystem.Model;
using NUnit.Framework;

namespace FileSystemTester
{
    [TestFixture]
    public class Tests
    {
        private FileSystem.Model.FileSystem fs;
        private TextFile testTextFile1, testTextFile2;
        private Folder testFolder1, testFolder2;

        private const string testText1 = "testText1", testText2 = "testText2";
        private const string testFolderName1 = "folder1", testFolderName2 = "folder2";

        [SetUp]
        public void Init()
        {
            fs = new FileSystem.Model.FileSystem();
            fs.mkdir("dir1");
            fs.mkdir("dir2");
            fs.mkdir("dir3");
            fs.cd("dir1");
            fs.mkdir("dir1.1");
            fs.mkdir("dir1.2");
            fs.mkdir("dir1.3");
            fs.mktext("txt1.1");
            fs.mktext("txt1.2");
            fs.mktext("txt1.3");
            fs.cd("/");
            fs.cd("dir2");
            fs.mkdir("dir2.1");
            fs.mkdir("dir2.2");
            fs.mkdir("dir2.3");
            fs.mktext("txt2.1");
            fs.mktext("txt2.2");
            fs.mktext("txt2.3");
            fs.cd("/");
            fs.cd("dir3");
            fs.mkdir("dir3.1");
            fs.mkdir("dir3.2");
            fs.mkdir("dir3.3");
            fs.mktext("txt3.1");
            fs.mktext("txt3.2");
            fs.mktext("txt3.3");
            
            testTextFile1 = new TextFile(testText1, "testContent1");
            testTextFile2 = new TextFile(testText2, "testContent2");
            
            testFolder1 = new Folder(testFolderName1);
            testFolder2 = new Folder(testFolderName2);
        }
        
        [Test]
        public void TestFileSystem()
        {
            
        }

        [Test]
        public void testTextFileConstructor()
        {
            Assert.AreEqual(testText1, testTextFile1.Name);
            Assert.AreEqual(testText1, testTextFile1.Content);
        }

        public void testTextFileListName()
        {
            Assert.AreEqual(testText1, testTextFile1.ListName);
        }

        public void testFolderConstructor()
        {
            Assert.AreEqual(testFolderName1, testFolder1.Name);
            Assert.AreEqual(testFolderName2, testFolder2.Name);
        }

        public void testCreateText()
        {
            TextFile txt = testFolder1.CreateTextFile("sampleName");
            Assert.AreEqual("sampleName", txt.Name);
        }

        public void testCreateFolder()
        {
            Folder f = testFolder1.CreateFolder("sampleName");
            Assert.AreEqual("sampleName", f.Name);
        }
    }
}