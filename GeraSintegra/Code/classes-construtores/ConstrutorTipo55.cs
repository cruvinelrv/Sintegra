using System;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo55 : IConstrutorTipo
    {
        #region atributos
        long cnpj_cpf;
        InscrEstadual ie_substituto;
        string uf_favorecida;
        DateTime dtGNRE;
        int bancoGNRE;
        int agenciaGNRE;
        string numeroAutenticacaoGNRE;
        double valorGNRE;
        DateTime dtVencimento;
        int mes_referencia;
        int ano_referencia;
        string protocoloGNRE;

        bool isFisico = true;
        #endregion

        public ConstrutorTipo55()
        {

        }
        
        #region métodos

        public void set1_DadosPrincipais(long cnpj_cpf, string inscrEstadual_substituto, string uf_substituto, string uf_favorecida)
        {
            this.isFisico = false;
            this.cnpj_cpf = cnpj_cpf;
            try
            {
                this.ie_substituto = new InscrEstadual(inscrEstadual_substituto, uf_substituto, false);
            }
            catch (Exception e)
            {
                throw new Exception("TIPO 55 \n\n " + e.Message);
            }
            this.uf_favorecida = uf_favorecida;
        }

        public void set2_GNRE(DateTime dtGNRE, int bancoGNRE, int agenciaGNRE, string numeroAutenticacaoGNRE, double valorGNRE, string protocoloGNRE)
        {
            this.dtGNRE = dtGNRE;
            this.bancoGNRE = bancoGNRE;
            this.agenciaGNRE = agenciaGNRE;
            this.numeroAutenticacaoGNRE = numeroAutenticacaoGNRE;
            this.valorGNRE = valorGNRE;
            this.protocoloGNRE = protocoloGNRE;
        }

        public void set3_Datas(DateTime dtVencimento, int mes_referencia, int ano_referencia)
        {
            this.dtVencimento = dtVencimento;
            this.mes_referencia = mes_referencia;
            this.ano_referencia = ano_referencia;
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
                throw new Exception("TIPO 55 \n\n CPF/CNPJ inválido: " + cnpj_cpf);
            */
            if (dtGNRE.Year < 2000)
                throw new Exception("TIPO 55 \n\n DATA DO GNRE anterior ao ano 2000");
            if (mes_referencia <= 0 || mes_referencia > 12)
                throw new Exception("TIPO 55 \n\n MES DE REFERENCIA não é válido");
            if (ano_referencia < 2008)
                throw new Exception("TIPO 55 \n\n ANO DE REFERENCIA não é válido");
            if (protocoloGNRE.Length < 2)
                throw new Exception("TIPO 55 \n\n PROTOCOLO GNRE deve ser preenchido");
        }

        public Tipo constroi()
        {
            valida();
            return new Tipo55(
                cnpj_cpf, ie_substituto.IE, ie_substituto.UF, uf_favorecida,
                dtGNRE, bancoGNRE, agenciaGNRE, numeroAutenticacaoGNRE, valorGNRE,
                dtVencimento, mes_referencia, ano_referencia,
                protocoloGNRE);
        }

    }
}