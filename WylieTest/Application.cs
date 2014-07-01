using System;
using System.IO;

namespace WylieTest
{
	class Application
	{
		static void ProcessFile(string inputPath, string outputPath)
		{
			string wylieInput = File.ReadAllText(inputPath);
			string xsampaOutput = LinguisticsLibrary.Wylie.ToXsampa(wylieInput);
			string ipaOutput = LinguisticsLibrary.Xsampa.ToIpa(xsampaOutput);
			File.WriteAllText(outputPath, ipaOutput);
		}

		static void Main(string[] arguments)
		{
			if (arguments.Length != 2)
			{
				Console.WriteLine("Usage: <path to Wylie text input> <path to IPA output>");
				return;
			}
			string inputPath = arguments[0];
			string outputPath = arguments[1];
			ProcessFile(inputPath, outputPath);
		}
	}
}
