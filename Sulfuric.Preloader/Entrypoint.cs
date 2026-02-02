using System;
using System.IO;
using System.Reflection;

namespace Doorstop;

public static class Entrypoint {
	public static void Start() {
		AppDomain.CurrentDomain.AssemblyLoad += (_, args) => {
			if (args.LoadedAssembly.GetName().Name == "Assembly-CSharp") {
				try {
					var asm = Assembly.LoadFrom("Sulfuric.dll");
					var type = asm.GetType("Sulfuric.Bootstrap");
					type.GetMethod("Init")!.Invoke(null, null);
				} catch (Exception e) {
					File.WriteAllText(
						Path.Combine(AppContext.BaseDirectory, "Sulfuric.Preloader.Exception.txt"),
						e.ToString()
					);
				}
				
			}
		};
	}
}
