using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BatchVideoEncoder.Helpers
{
   public static  class ProcessHelper
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public static void run_CLI_tool(string path, string cli_params, bool runHidden = false)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = cli_params;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // not working
            p.StartInfo.Verb = "runas";
            if (true == runHidden)
            {
                p.StartInfo.CreateNoWindow = true; // WORKING !!! 
            }
            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            p.Start();

            //string console_output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            //return console_output;
        }
        public static string runCliAppWithOutput(string path, string cli_params, string workingDir, bool runHidden = false)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo(path, cli_params);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.WorkingDirectory = workingDir;
            Process p = new Process();
            p.StartInfo = procStartInfo;
            // Redirect the output stream of the child process.
            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            if (true == runHidden)
            {
                p.StartInfo.CreateNoWindow = true; // WORKING !!! 
            }

            p.Start();

            string console_output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return console_output;
        }
        public static void run_CLI_tool2(string tocmd, string workingDir, bool runHidden = false)
        {

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + tocmd);
            procStartInfo.RedirectStandardOutput = false;
            procStartInfo.UseShellExecute = false;
            procStartInfo.WorkingDirectory = workingDir;
            Process proc = new Process();
            proc.StartInfo = procStartInfo;

            //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            if (true == runHidden)
            {
                proc.StartInfo.CreateNoWindow = true; // WORKING !!! 
            }
            proc.Start();

            proc.WaitForExit();
            Thread.Sleep(5000);
        }

        public static bool RunProcessWithCallback(string path, string cmd, Action<string, bool> Calback, string workDir, bool runHidden = false)
        {
            logger.Info("### RunProcessCallback() launched,");
            //if (!System.IO.File.Exists(path))
            //    return false;
            Calback(string.Format("command: {0}", cmd), true);
            Calback(string.Format("App path: {0}", path), true);
            var p = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = workDir,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = path,
                    CreateNoWindow = runHidden,
                    Arguments = cmd
                }
            };

            p.OutputDataReceived += (sender, args) => Calback(args.Data, true);
            p.ErrorDataReceived += (sender, args) => Calback(args.Data, false);
            var rs = p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
            var ExitCode = p.ExitCode;
            Calback(String.Format("Exit code: {0}", ExitCode), true);
            Calback(String.Format("App file:  {0}", p.StartInfo.FileName), true);
            Calback(String.Format("Parameters:  {0}", cmd), true);

            return (ExitCode == 0);
        }


    }
}
