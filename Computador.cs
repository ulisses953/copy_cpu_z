using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace extratorDeInformacao
{
    class Computador
    {
        public List<Memory> listMemoriaRam = new List<Memory>();


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

            #region pegando informacao da memoria ram e colocando na classe ram

            process.StartInfo.FileName = "wmic";
            process.StartInfo.Arguments = "memorychip get speed";

            process.Start();

            getCmd = process.StandardOutput.ReadToEnd();

            generic = LimparStrig(getCmd);
            for (int i = 0; i <= generic.Count -1; i++)
            {
                listMemoriaRam.Add(memoriaRam);
                listMemoriaRam[i].UncoreFrequency = Convert.ToDouble(generic[i]);
            }
            
            
            
            

            
            #endregion


        }

        private List<string> LimparStrig(string value)
        {
            List<string> result = new List<string>();

            var valueVetor = value.Trim()
           .Replace("\r", "")
           .Replace("\n", "-")
           .Replace("Speed", "")
           .Replace(" ", "")
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

/* 
  process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardOutput = true;

            #region variaveis
           
            string getVel;
            #endregion

            #region pegando informacao do cmd
            Process velProcess = process;

           

            velProcess.Start();

            getVel = velProcess.StandardOutput.ReadToEnd();
            #endregion

            ListaDeFrequencias = LimparStrig(getVel);

            velProcess.Kill();

            Velocidade = ListaDeFrequencias[0];
        }

        
 */
