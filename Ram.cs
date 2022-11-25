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
                #region pegando informacao
                Process velProcess = process;

                velProcess.StartInfo.FileName = "wmic";
                velProcess.StartInfo.Arguments = " memorychip get speed ";

                velProcess.Start();
                
                var velNaoFormatado = velProcess.StandardOutput.ReadToEnd();
                #endregion



                velNaoFormatado = velNaoFormatado.Replace("Speed", "");
                velNaoFormatado = limparStrig(velNaoFormatado);

                var listaDeFrequencias = velNaoFormatado.Split(" ").Where(valor => valor != "");// aqi deu pau

                //matando o processo
                velProcess.Kill();

                //return velNaoFormatado;
                //return listaDeFrequencias.Select(frequencia => Convert.ToInt32(frequencia)).ToList(); 
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
                .Replace("\r", "")
                .Replace("\n", "");
        }

    }
}