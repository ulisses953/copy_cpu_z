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
            
            Memory memoriaRam = new Memory();

            List<string> getCmd = new List<string>();

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

            getCmd = LimparStrig(process.StandardOutput.ReadToEnd());


            for (int i = 0; i <= getCmd.Count - 1; i++)
            {
                ListMemoriaRam.Add(memoriaRam);
                ListMemoriaRam[i].UncoreFrequency = Convert.ToDouble(getCmd[i]);
            }

            //peagndo o manufacturer
            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get manufacturer";

            process.Start();

            getCmd = LimparStrig(process.StandardOutput.ReadToEnd());

            for (int i = 0; i <= getCmd.Count - 1; i++)
            {
                ListMemoriaRam[i].Manufacturer = getCmd[i];
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

