using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Multisoft.SistemaSintegra.Code
{

    public static class Functions
    {
        #region API
        /// <summary>
        /// Importação da API ConsisteInscricaoEstadual da DLL DllInscE32.dll para validação da Inscrição Estadual
        /// </summary>
        /// <param name="ie">Inscrição Estadual</param>
        /// <param name="uf">Estado</param>
        /// <returns>veja enumValidaIE</returns>
        [System.Runtime.InteropServices.DllImport("DllInscE32.dll")]
        private static extern int ConsisteInscricaoEstadual(string ie, string uf);
        #endregion

        #region Métodos

        /// <summary>
        /// Fim de linha
        /// </summary>
        public const string EOL = "\r\n";

        public static string LimiteLength(string s, int x)
        {
            return (s.Length > x) ? s.Remove(0, x) : s;
        }


        /// <summary>
        /// Trata os valores passadas retirando os caracteres não numéricos
        /// </summary>
        /// <param name="valor">Valor a ser tratado</param>
        /// <returns>Só Números</returns>
        public static string SoNumero(object valor)
        {
            if (valor == null)
                return "0";
            string ret = "";
            foreach (char c in valor.ToString().ToCharArray())
                if (char.IsNumber(c))
                    ret += c;
            if (ret == "")
                ret = "0";
            return ret;
        }

        public static string FiltraDigitosValidos(string origem)
        {
            if (origem == null)
                return "";
            string s = "";
            foreach (char c in origem)
            {
                if (char.IsLetterOrDigit(c) || c==' ')
                    s += c;
            }
            return s;
        }

        public static double modulo(double d)
        {
            return (d >= 0) ? d : -d;
        }

        /// <summary>
        /// Valida a inscrição estadual
        /// </summary>
        /// <param name="ie">Número de inscrição estadual</param>
        /// <param name="uf">Estado da inscrição estadual</param>
        /// <returns></returns>
        public static enumValidaIE ValidaIE(string ie, string uf)
        {
            int ret = ConsisteInscricaoEstadual(ie, uf);
            return (enumValidaIE)ret;
        }

        /// <summary>
        /// Faz a validação do dígito verificado do CNPJ
        /// </summary>
        /// <param name="cnpj">número do cnpj</param>
        /// <returns>True se OK. False</returns>
        public static bool ValidaCNPJ(string cnpj)
        {
            if (cnpj.Length == 0)
                return false;

            cnpj = Functions.SoNumero(cnpj).PadLeft(14, '0');

            try
            {
                #region Valida
                cnpj = SoNumero(cnpj);
                string Cnpj_1 = cnpj.Substring(0, 12);
                string Cnpj_2 = cnpj.Substring(cnpj.Length - 2);
                string Mult = "543298765432";
                string Controle = String.Empty;
                int Soma = 0;
                int Digito = 0;

                for (int j = 1; j < 3; j++)
                {

                    Soma = 0;

                    for (int i = 0; i < 12; i++)
                        Soma += Convert.ToInt32(Cnpj_1.Substring(i, 1)) * Convert.ToInt32(Mult.Substring(i, 1));

                    if (j == 2) Soma += (2 * Digito);
                    Digito = ((Soma * 10) % 11);
                    if (Digito == 10) Digito = 0;
                    Controle = Controle + Digito.ToString();
                    Mult = "654329876543";

                }

                if (Controle != Cnpj_2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                #endregion
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Faz a validação do dígito verificador do CPF
        /// </summary>
        /// <param name="cpf">número do CPF</param>
        /// <returns>True se OK. False</returns>
        public static bool ValidaCPF(string cpf)
        {
            if (cpf.Length == 0) return false;

            cpf = Functions.SoNumero(cpf).PadLeft(11,'0');

            try
            {
                #region valida
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                long soma;
                long resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    return false;

                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf.ToString()) * multiplicador1[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += long.Parse(tempCpf.ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
                #endregion
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Através do tamanho do parametro verifica se deve validar o CPF ou CNPJ
        /// </summary>
        /// <param name="cpf_cnpj">CPF ou CNPJ</param>
        /// <returns>True se OK. False</returns>
        public static bool ValidaCPFouCNPJ(string cpf_cnpj)
        {
            cpf_cnpj = SoNumero(cpf_cnpj);
            if (cpf_cnpj.Length == 11)
                return ValidaCPF(cpf_cnpj);
            else
                return ValidaCNPJ(cpf_cnpj);
        }

        /// <summary>
        /// retorna o diretório da aplicação
        /// </summary>
        /// <returns></returns>
        public static string DirApp()
        {
            //            string ret = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string ret = System.IO.Directory.GetCurrentDirectory();
            return ret;
        }

        /// <summary>
        /// retorna o último dia do mes
        /// </summary>
        /// <param name="mes">mes que se deseja recuperar o último dia</param>
        /// <returns>retorna um datetime com o último dia</returns>
        public static DateTime UltimoDia(DateTime mes)
        {
            return Convert.ToDateTime("01/" + mes.ToString("MM/yyyy")).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// retorna o primeiro dia do mês
        /// </summary>
        /// <param name="mes">Mês que se deseja obeter o primeiro dia</param>
        /// <returns>data do primeiro dia</returns>
        public static DateTime PrimeiroDia(DateTime mes)
        {
            return Convert.ToDateTime("01/" + mes.ToString("MM/yyyy"));
        }

        #endregion
    }
}
