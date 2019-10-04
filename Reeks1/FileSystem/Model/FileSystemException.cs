using System;

namespace FileSystem.Model
{
    public class FileSystemException : Exception
    {
        public FileSystemException(string message) : base(message) {}
    }
}