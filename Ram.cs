using SolrNet.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace extratorDeInformacao
{
    public class Ram
    {
        private Process process = new Process();
        public List<int> Velocidade {
            get {
                #region pegando informacao do cmd
                Process velProcess = process;

                velProcess.StartInfo.FileName = "wmic";
                velProcess.StartInfo.Arguments = " memorychip get speed ";

                velProcess.Start();
                
                var getVel = velProcess.StandardOutput.ReadToEnd();
                #endregion

                getVel = limparStrig(getVel);

                var a = getVel.Split("-").ToList<string>();

                List<int> listaDeFrequencias = new List<int>();

                for (int i = 0; i <= a.Count(); i++)
                {
                    if (a[i] != "")
                    {
                        listaDeFrequencias.Add(Convert.ToInt32(a[i]));
                    }
                }
                velProcess.Kill();

                return listaDeFrequencias;
            }
            private set { }
        }

        public Ram() { 
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardOutput = true;
        }

        private string limparStrig(string valor)
        {
            return valor.Trim()
                .Replace("\r", "-")
                .Replace("\n", "-")
                .Replace(" ", "-")
                .Replace("Speed", "-");

        }

    }
}