using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace copy_cpu_Z
{
    class FactoryMemory
    {
        public List<Memory> memoria;
        
        public FactoryMemory()
        {
           
            memoria = new List<Memory>();

            var getCmd = new List<string>();
            var process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            #region speed
            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get speed";

            process.Start();

            getCmd = LimparStrig(process.StandardOutput.ReadToEnd());

            for (int i = 0; i <= getCmd.Count - 1; i++)
            {
                memoria.Add(new Memory());
                memoria[i].Speed = Convert.ToDouble(getCmd[i]);
            }

            #endregion 

            #region manufacture

            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get manufacturer";

            process.Start();

            getCmd = LimparStrig(process.StandardOutput.ReadToEnd());

            for (int i = 0; i <= getCmd.Count - 1; i++)
            {
                memoria[i].Manufacturer = getCmd[i];
            }

            #endregion

            #region caption
            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get caption";

            process.Start();

            getCmd = LimparStrig(process.StandardOutput.ReadToEnd());

            for (int i = 0; i <= getCmd.Count - 1; i++)
            {
                memoria[i].Caption = getCmd[i];
            }
            #endregion

            #region SerialNunber

            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get SerialNumber";

            process.Start();

            getCmd = LimparStrig(process.StandardOutput.ReadToEnd());

            for (int i = 0; i <= getCmd.Count - 1; i++)
            {
                memoria[i].SerialNunber = getCmd[i];
            }
            #endregion


            process.Kill();
        }
        
        private List<string> LimparStrig(string value)
        {

            List<string> result = new List<string>();

            var valueVetor = value.Trim()
           .Replace("\r", "")
           .Replace("\n", "-")
           .Replace("Speed", "")
           .Replace(" ", "")
           .Replace("Manufacturer", "")
           .Replace("Caption", "")
           .Replace("SerialNumber", "")
           .Split("-");


            for (int i = 0; i <= valueVetor.Length - 1; i++)
            {
                if (valueVetor[i] != "")
                {
                    result.Add(valueVetor[i]);
                }
            }

            return result;
        }
    }
}
