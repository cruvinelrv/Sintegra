using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo53 : IConstrutorTipo
    {
        #region atributos
        long cnpj_cpf;
        InscrEstadual ie;//
        DateTime dtEmissaoRecebimento;
        int modelo_nf;//
        string serie_nf;//
        int numero_nf;//
        long cfop;
        string emitente;
        double bcICMSsubst;//
        double valorICMSretido;//
        double despesasAcessorias;
        string situacao;

        bool isFisico = true;
        #endregion

        public ConstrutorTipo53()
        {
            this.modelo_nf = 1;
            this.serie_nf = "2";
        }
        
        #region métodos

        public void set1_NotaFiscal(int numero_nf, string cfop, DateTime dtEmissaoRecebimento, bool isVenda)
        {
            this.numero_nf = numero_nf;
            this.cfop = long.Parse(Functions.SoNumero(cfop));
            this.dtEmissaoRecebimento = dtEmissaoRecebimento;
            this.emitente = (isVenda) ? Tipo50.EMITENTE_TERCEIROS : Tipo50.EMITENTE_PROPRIO;
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
            try
            {
                this.ie = new InscrEstadual(ie, uf, true);
            }
            catch (Exception e)
            {
                throw new Exception("TIPO 53 \n\nInsc. Est. INVÁLIDA (" + ie + ") para nota numero: " + numero_nf.ToString());
            }

            this.cnpj_cpf = long.Parse(Functions.SoNumero(cnpj));
        }

        public void set3_Valores(double bcICMSsubst, double valorICMSretido,
            double despesasAcessorias)
        {
            this.bcICMSsubst = Functions.modulo(bcICMSsubst);
            this.valorICMSretido = Functions.modulo(valorICMSretido);
            this.despesasAcessorias = Functions.modulo(despesasAcessorias);
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
                throw new Exception("TIPO 53 \n\n CPF/CNPJ inválido: " + cnpj_cpf.ToString());
            */
            if (cfop <= 0)
                throw new Exception("TIPO 53 \n\n CFOP da nota inválido");
            if (emitente == null)
                throw new Exception("TIPO 53 \n\n Você deve expecificar se venda ou compra.");
            if (dtEmissaoRecebimento.Year < 2000)
                throw new Exception("TIPO 53 \n\n Data anterior ao ano 2000");
            if (situacao.Length != 1)
                throw new Exception("TIPO 53 \n\n SITUAÇÃO inválida");
            
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo53(cnpj_cpf, ie.IE, ie.UF, dtEmissaoRecebimento,
                modelo_nf, serie_nf, numero_nf, cfop, emitente,
                bcICMSsubst, valorICMSretido, despesasAcessorias,
                situacao);
        }

    }
}