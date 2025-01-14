using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var rootCommand = new RootCommand("Lab Management Tool");

        var versionCommand = new Command("version", "Displays version and author information");
        versionCommand.SetHandler(() => DisplayVersion());

        var runCommand = new Command("run", "Runs a specific lab")
        {
            new Argument<string>("lab", "Lab to run: lab1, lab2, or lab3"),
            new Option<string>("--input", "Input file path"),
            new Option<string>("--output", "Output file path")
        };
        runCommand.SetHandler(async (InvocationContext context) =>
        {
            var lab = context.ParseResult.GetValueForArgument<string>("lab");
            var input = context.ParseResult.GetValueForOption<string>("--input");
            var output = context.ParseResult.GetValueForOption<string>("--output");
            await RunLab(lab, input, output);
        });

        var setPathCommand = new Command("set-path", "Sets the path for input and output files")
        {
            new Option<string>("--path", "Path to input/output directory")
        };
        setPathCommand.SetHandler(async (InvocationContext context) =>
        {
            var path = context.ParseResult.GetValueForOption<string>("--path");
            await SetPath(path);
        });

        rootCommand.AddCommand(versionCommand);
        rootCommand.AddCommand(runCommand);
        rootCommand.AddCommand(setPathCommand);

        await rootCommand.InvokeAsync(args);
    }

    static Task DisplayVersion()
    {
        Console.WriteLine("Lab Tool");
        Console.WriteLine("Author: Andrew Chersky");
        Console.WriteLine("Version: 1.0.0");
        return Task.CompletedTask;
    }

    static async Task RunLab(string lab, string input, string output)
    {
        string inputPath = GetFilePath(input, "INPUT.TXT");
        string outputPath = GetFilePath(output, "OUTPUT.TXT");

        await Task.Run(() =>
        {
            switch (lab.ToLower())
            {
                case "lab1":
                    LabLibrary.Lab1.Execute();
                    break;
                case "lab2":
                    LabLibrary.Lab2.Execute();
                    break;
                case "lab3":
                    LabLibrary.Lab3.Execute();
                    break;
                default:
                    Console.WriteLine("Invalid lab specified. Use lab1, lab2, or lab3.");
                    break;
            }
        });
    }

    static async Task SetPath(string path)
    {
        await Task.Run(() =>
        {
            if (Directory.Exists(path))
            {
                Environment.SetEnvironmentVariable("LAB_PATH", path);
                Console.WriteLine($"LAB_PATH set to: {path}");
            }
            else
            {
                Console.WriteLine("Invalid path specified.");
            }
        });
    }

    static string GetFilePath(string path, string defaultFileName)
    {
        if (!string.IsNullOrEmpty(path))
        {
            return path;
        }

        string? envPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (!string.IsNullOrEmpty(envPath))
        {
            return Path.Combine(envPath, defaultFileName);
        }

        string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return Path.Combine(homePath, defaultFileName);
    }
}