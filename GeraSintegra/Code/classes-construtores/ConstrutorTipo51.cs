using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo51 : IConstrutorTipo
    {
        #region atributos
        long cnpj_cpf;
        InscrEstadual ie;//
        DateTime dtEmissaoRecebimento;
        string serie_nf;//
        int numero_nf;//
        long cfop;
        double valorTotal;
        double montanteIPI;
        double isentaOuNaoTributadaIPI;
        double outrasIPI;
        string situacao;

        bool isFisico = true;
        #endregion

        public ConstrutorTipo51()
        {
            this.serie_nf = "2";
        }
        
        #region métodos

        public void set1_NotaFiscal(string numero_nf, string cfop, DateTime dtEmissaoRecebimento)
        {
            this.numero_nf = int.Parse(Functions.SoNumero(numero_nf));
            this.cfop = long.Parse(Functions.SoNumero(cfop));
            this.dtEmissaoRecebimento = dtEmissaoRecebimento;
        }

        public void set2_DadosClienteConsumidor()
        {
            this.ie = new InscrEstadual("ISENTO", "GO", true);
            this.cnpj_cpf = 0;
        }

        public void set2_DadosClienteFisico(string uf, string cpf)
        {
            this.ie = new InscrEstadual("ISENTO", uf, true);
            this.cnpj_cpf = long.Parse(Functions.SoNumero(cpf));
        }

        public void set2_DadosClienteJuridico(string ie, string uf, string cnpj)
        {
            this.isFisico = false;
            this.cnpj_cpf = long.Parse(Functions.SoNumero(cnpj));

            string ie2 = Functions.SoNumero(ie);
            if (ie2 == "" || ie2 == "0")
            {
                this.ie = new InscrEstadual(InscrEstadual.ISENTO, uf, true);
                return;
            }

            try
            {
                this.ie = new InscrEstadual(ie, uf, false);
            }
            catch (Exception e)
            {
                throw new Exception("TIPO 51 \n\nInsc. Est. INVÁLIDA (" + ie + ") para nota numero: " + numero_nf.ToString());
            }
        }

        public void set3_Valores(double valorTotal, double montanteIPI,
            double isentaOuNaoTributadaIPI, double outrasIPI)
        {
            this.valorTotal = Functions.modulo(valorTotal);
            this.montanteIPI = Functions.modulo(montanteIPI);
            this.isentaOuNaoTributadaIPI = Functions.modulo(isentaOuNaoTributadaIPI);
            this.outrasIPI = Functions.modulo(outrasIPI);
        }

        public void set4_Situacao(string s)
        {
            this.situacao = s;
        }

        #endregion

        private void valida()
        {
            /*
            bool isValido
                = (isFisico)
                ? Functions.ValidaCPF(cnpj_cpf.ToString())
                : Functions.ValidaCNPJ(cnpj_cpf.ToString());
            if (!isValido)
                throw new Exception("TIPO 51 \n\n CPF/CNPJ inválido: " + cnpj_cpf.ToString());
            */
            if (cfop <= 0)
                throw new Exception("TIPO 51 \n\n CFOP da nota inválido");
            if (dtEmissaoRecebimento.Year < 2000)
                throw new Exception("TIPO 51 \n\n Data anterior ao ano 2000");
            if (situacao.Length != 1)
                throw new Exception("TIPO 51 \n\n SITUAÇÃO inválida");
            
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo51(cnpj_cpf, ie.IE, ie.UF, dtEmissaoRecebimento,
                serie_nf, numero_nf, cfop,
                valorTotal, montanteIPI, isentaOuNaoTributadaIPI, outrasIPI,
                situacao);
        }

    }
}