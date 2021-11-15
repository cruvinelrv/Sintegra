using System;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo56 : IConstrutorTipo
    {
        #region atributos
        long cnpj_cpf;
        int modelo_nf;
        string serie_nf;
        int numero_nf;
        long cfop;
        int cst;
        int numero_ordinal_linha;
        string cod_item;
        int tipo_operacao;
        long cnpj_concessionaria;
        double aliquotaIPI;
        string chassi;
        #endregion

        public ConstrutorTipo56()
        {
            this.modelo_nf = 1;
            this.serie_nf = "2";
        }

        #region métodos
        public void set1_DadosPrincipais(string numero_nf, string cnpj, string cfop, string cst)
        {
            this.numero_nf = int.Parse(Functions.SoNumero(numero_nf));
            this.cnpj_cpf = long.Parse(Functions.SoNumero(cnpj));
            this.cfop = long.Parse(Functions.SoNumero(cfop));
            this.cst = int.Parse(Functions.SoNumero(cst));
        }

        public void set2_BasicoItem(int numero_ordinal_linha, string cod_item)
        {
            this.numero_ordinal_linha = numero_ordinal_linha;
            this.cod_item = cod_item;
        }

        public void set3_Especifico(int tipo_operacao, long cnpj_concessionaria, double aliquotaIPI, string chassi)
        {
            this.tipo_operacao = tipo_operacao;
            this.cnpj_concessionaria = long.Parse(Functions.SoNumero(cnpj_concessionaria));
            this.aliquotaIPI = aliquotaIPI;
            this.chassi = chassi;
        }
        #endregion

        private void valida()
        {
            if (!Functions.ValidaCNPJ(cnpj_cpf.ToString()))
                throw new Exception("TIPO 56 \n\n CNPJ inválido " + cnpj_cpf.ToString());
            if (!Functions.ValidaCNPJ(cnpj_concessionaria.ToString()))
                throw new Exception("TIPO 56 \n\n CNPJ da concessionária inválido " + cnpj_concessionaria.ToString());
        }

        public Tipo constroi()
        {
            //valida();
            return new Tipo56(
                cnpj_cpf, modelo_nf, serie_nf, numero_nf, cfop, cst,
                numero_ordinal_linha, cod_item,
                tipo_operacao,
                cnpj_concessionaria,
                aliquotaIPI, chassi);
        }
    }
}