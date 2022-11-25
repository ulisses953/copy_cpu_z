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
                
                var valorEntrada = velProcess.StandardOutput.ReadToEnd();
                #endregion

                valorEntrada = limparStrig(valorEntrada);

                var listaDeFrequencias = valorEntrada.Split("-").ToList<string>();

                //so falta filtrar a lista deixando apenas os numeros;

                velProcess.Kill();

                return  listaDeFrequencias.Select(int.Parse).ToList();
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