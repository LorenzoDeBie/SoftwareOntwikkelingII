using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bestandsbeheer
{
	public class FileProtectionProxy : IFile
	{
		private User _user;
		private string _filename;
		private IFile _file;

		public FileProtectionProxy(string filename, User user)
		{
			_filename = filename;
			_user = user;
		}

		public string FileName => _filename;

		public string WriteContent()
		{
			if(_filename.StartsWith("."))
			{
				if (!_user.isAdmin)
				{
					throw new InvalidOperationException(_user.Username + " has no access to this file");
				}
			}

			if(_file == null)
			{
				_file = new FileCacheProxy(_filename);
			}

			return _file.WriteContent();
			
		}
	}
}
