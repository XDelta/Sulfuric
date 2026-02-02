using System.IO;
using System.Runtime.InteropServices;

namespace Sulfuric; 
public static class Bootstrap {
	private static bool _initialized;

	[DllImport("kernel32.dll")]
	private static extern bool AllocConsole();

	public static void Init() {
		if (!_initialized) {
			_initialized = true;
			AllocConsole();
			StreamWriter writer = new(Console.OpenStandardOutput()) { AutoFlush = true };
			Console.SetOut(writer);
			Initialization.Initialize();
			Logger.Log("Ding");
		}
	}
}
