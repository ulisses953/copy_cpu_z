using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace extratorDeInformacao
{
    class Computador
    {
        public List<Memory> ListMemoriaRam = new List<Memory>();


        public Computador()
        {

            #region variaveis
            string getCmd;
            Memory memoriaRam = new Memory();
            
            List<string> generic = new List<string>();
            
            #endregion

            Process process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardOutput = true;

            #region pegando informacao da memoria ram e colocando na classe listMemoriaRam
            
            //pegando a velocidade da memoria ram
            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get speed";

            process.Start();

            getCmd = process.StandardOutput.ReadToEnd();

            
            for (int i = 0; i <= generic.Count -1; i++)
            {
                ListMemoriaRam.Add(memoriaRam);
                ListMemoriaRam[i].UncoreFrequency = Convert.ToDouble(generic[i]);
            }

            //peagndo o manufacturer
            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get manufacturer";

            process.Start();

            getCmd = process.StandardOutput.ReadToEnd();

            generic = LimparStrig(getCmd);
            for (int i = 0; i <= generic.Count - 1; i++)
            {
                ListMemoriaRam[i].Manufacturer = generic[i];
            }

            getCmd = process.StandardOutput.ReadToEnd();


            
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
           .Split("-");


            for (int i = 0; i <= valueVetor.Length -1; i++)
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

