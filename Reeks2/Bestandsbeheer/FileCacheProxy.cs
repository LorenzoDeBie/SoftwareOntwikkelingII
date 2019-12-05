using System;
using System.Collections.Generic;

namespace Bestandsbeheer
{
	public class FileCacheProxy : IFile
	{
		private static Dictionary<string, IFile> files = new Dictionary<string, IFile>();

		private readonly string _fileName;

		public string FileName => _fileName;

		internal FileCacheProxy(string fileName)
		{
			_fileName = fileName;
		}

		public string WriteContent()
		{
			//virtual proxy
			if (!files.ContainsKey(_fileName))
			{
				files.Add(_fileName, new File(_fileName));
			}
			return files[_fileName].WriteContent();
		}
	}
}