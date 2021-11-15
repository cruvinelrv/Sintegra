using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo50 : IConstrutorTipo
    {
        #region atributos
        long cnpj_cpf;
        InscrEstadual ie;//
        DateTime dtEmissaoRecebimento;
        int modelo_nf;//
        string serie_nf;//
        int numero_nf;//
        int cfop;
        string emitente;
        double valorTotal;//
        double bcICMS;//
        double valorICMS;//
        double isentaOuNaoTributada;//
        double outras;//
        double aliquota;//
        string situacao;

        bool isFisico = true;
        #endregion

        public ConstrutorTipo50()
        {
            this.modelo_nf = 1;
            this.serie_nf = "2";
        }

        #region métodos

        public void set1_NotaFiscal(string numero_nf, string cfop, DateTime dtEmissaoRecebimento, bool isVenda)
        {
            this.numero_nf = int.Parse(Functions.SoNumero(numero_nf));
            this.cfop = int.Parse(Functions.SoNumero(cfop));
            this.dtEmissaoRecebimento = dtEmissaoRecebimento;

            //
            if (this.cfop == 0)
                this.cfop = (isVenda) ? 5102 : 1102;
            //isVenda = (cfop.StartsWith("5") || cfop.StartsWith("6"));
            this.emitente = (isVenda) ? Tipo50.EMITENTE_PROPRIO : Tipo50.EMITENTE_TERCEIROS;
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
                throw new Exception("TIPO 50 \n\nInsc. Est. INVÁLIDA ("+ie+") para nota numero: " + numero_nf.ToString());
            }

        }

        public void set3_Valores(double valorTotal, double bcICMS, double valorICMS,
            double isentaOuNaoTributada, double outras, double aliquota)
        {
            this.valorTotal = Functions.modulo(valorTotal);
            this.bcICMS = Functions.modulo(bcICMS);
            this.valorICMS = Functions.modulo(valorICMS);
            this.isentaOuNaoTributada = Functions.modulo(isentaOuNaoTributada);
            this.outras = Functions.modulo(outras);
            this.aliquota = Functions.modulo(aliquota);
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
                throw new Exception("TIPO 50 \n\n CPF/CNPJ inválido: " + cnpj_cpf.ToString());
            */
            if (cfop <= 0)
                throw new Exception("TIPO 50 \n\n CFOP da nota inválido");
            if (emitente == null)
                throw new Exception("TIPO 50 \n\n Você deve expecificar se venda ou compra.");
            if (dtEmissaoRecebimento.Year < 2000)
                throw new Exception("TIPO 50 \n\n Data anterior ao ano 2000");
            if (situacao.Length != 1)
                throw new Exception("TIPO 50 \n\n SITUAÇÃO inválida");
            
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo50(cnpj_cpf, ie.IE, ie.UF, dtEmissaoRecebimento,
                modelo_nf, serie_nf, numero_nf, cfop, emitente,
                valorTotal, bcICMS, valorICMS, isentaOuNaoTributada,
                outras, aliquota,
                situacao);
        }

    }
}