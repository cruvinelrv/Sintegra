using System;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo51 : Tipo
    {
        public const string SITUACAO_DOC_FSCL_NOR = "N";
        public const string SITUACAO_DOC_FSCL_CAN = "S";
        public const string SITUACAO_LAN_EXT_DOC_FSCL_NRM = "E";
        public const string SITUACAO_LAN_EXT_DOC_FSCL_CAN = "X";

        public Tipo51(
            long cnpj_cpf, string inscrEstadual, string uf,
            DateTime dtEmissaoRecebimento,
            string serie_nf, int numero_nf,
            long cfop,
            double valorTotal, double montanteIPI,
            double isentaOuNaoTributadaIPI, double outrasIPI,
            string situacao)//casas decimais
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(51)
                );
            campos.Add(//CNPJ
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cnpj_cpf)
                );
            campos.Add(//INSC EST
                new Campo(14, EnumFormato.ALPHA)
                .appendValor(inscrEstadual)
                );
            campos.Add(//DT EMISSÃO OU RECEBIMENTO
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtEmissaoRecebimento)
                );
            campos.Add(//UF
                new Campo(2, EnumFormato.ALPHA)
                .appendValor(uf)
                );
            campos.Add(//SERIE NF
                new Campo(3, EnumFormato.ALPHA)
                .appendValor(serie_nf)
                );
            campos.Add(//NUMERO NF
                new Campo(6, EnumFormato.NUMEROS)
                .appendValor(numero_nf)
                );
            campos.Add(//CFOP
                new Campo(4, EnumFormato.NUMEROS)
                .appendValor(cfop)
                );
            campos.Add(//VALOR TOTAL
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(valorTotal)
                );
            campos.Add(//MONTANTE DO IPI
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(montanteIPI)
                );
            campos.Add(//VALOR AMPARADO POR ISENÇÃO OU NÃO INCIDENCIA
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(isentaOuNaoTributadaIPI)
                );
            campos.Add(//VALOR OUTRAS
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(outrasIPI)
                );
            campos.Add(//BRANCOS
                new Campo(20, EnumFormato.ALPHA)
                .appendValor("")
                );
            campos.Add(//SITUAÇÃO
                new Campo(1, EnumFormato.ALPHA)
                .appendValor(situacao)
                );
        }
    }
}