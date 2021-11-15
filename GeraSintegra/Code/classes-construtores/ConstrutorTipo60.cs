using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ConstrutorTipo60 : IConstrutorTipo
    {
        #region atributos

        string subtipo;
        Tipo60M tipo60M;
        Tipo60A tipo60A;

        #endregion


        public ConstrutorTipo60(string subtipo)
        {
            this.subtipo = subtipo;
        }

        #region métodos

        public void setM_Mestre(DateTime dtEmissao, string num_serie_equipamento,
            int num_ordem_equipamento, string cod_modelo_doc_fiscal,
            int primeiro_doc_dia, int ultimo_doc_dia, int num_CRZ,
            int num_CRO, long valor_venda_bruta, long valor_totalizador_equipamento)
        {
            this.tipo60M = new Tipo60M(dtEmissao, num_serie_equipamento,
                num_ordem_equipamento, cod_modelo_doc_fiscal,
                primeiro_doc_dia, ultimo_doc_dia, num_CRZ,
                num_CRO, valor_venda_bruta, valor_totalizador_equipamento);
        }

        public void setA_Analitico(DateTime dtEmissao, string num_serie_equipamento,
            string situacaoT_aliquota, long valor_totalizador_equipamento)
        {
            this.tipo60A = new Tipo60A(dtEmissao, num_serie_equipamento,
                situacaoT_aliquota, valor_totalizador_equipamento);
        }

        #endregion

        private void valida()
        {
            /*
            if (!Functions.ValidaCNPJ(cgc_mf.ToString()))
                throw new Exception("TIPO 10 \n\n CGC inválido " +cgc_mf.ToString());
            if (municipio.Length < 3)
                throw new Exception("TIPO 10 \n\n Municipio menor que 3 caracteres");
            if (nome_contrib.Length < 3)
                throw new Exception("TIPO 10 \n\n Nome do Contribuinte menor que 3 caracteres");

            if (fax.ToString().Length != 10 && fax.ToString().Length != 0 )
                throw new Exception("TIPO 10 \n\n Fax precisa ter 10 caracteres, você pode optar por não preenchê-lo");

            if (dtFinal.Year < 2000)
                throw new Exception("TIPO 10 \n\n Data Final anterior ao ano 2000");
            if (dtInicial.Year < 2000)
                throw new Exception("TIPO 10 \n\n Data Inicial anterior ao ano 2000");
            */
        }

        public Tipo constroi()
        {
            valida();

            switch (subtipo)
            {
                case Tipo60.SUBTIPO_60M:
                    return tipo60M;
                case Tipo60.SUBTIPO_60A:
                    return tipo60A;
                default:
                    throw new Exception("TIPO 60 - SUBTIPO INCORRETO: "+subtipo);
            }
        }
    }
}
