using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace ApplicationLayer
{
	public static class Helper
	{
		private static readonly object Lock = new object();
		private static bool _redirectInProgress;

		public static Assembly OnAssemblyResolve(AssemblyLoadContext assemblyLoadContext, AssemblyName assemblyName)
		{
			lock (Lock)
			{
				//skip if loading fails for redirected assembly
				if (_redirectInProgress)
					return null;

				//load redirected assembly
				_redirectInProgress = true;
				Assembly assembly;

				try
				{
					assembly = assemblyLoadContext.LoadFromAssemblyName(assemblyName);

					if (assembly != null)
					{
						_redirectInProgress = false;
						return assembly;
					}
				}
				catch
				{
					// ignored
				}

				var location = Assembly.GetEntryAssembly().Location;
				var directory = Path.GetDirectoryName(location);

				try
				{
					var path = Path.Combine(directory, assemblyName.Name + ".dll");
					assembly = assemblyLoadContext.LoadFromAssemblyPath(path);

					if (assembly != null)
					{
						_redirectInProgress = false;
						return assembly;
					}
				}
				catch
				{
					// ignored
				}

				_redirectInProgress = false;

				return null;
			}
		}
	}
}