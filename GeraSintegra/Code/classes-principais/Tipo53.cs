using System;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo53 : Tipo
    {
        public const string SITUACAO_DOC_FSCL_NOR = "N";
        public const string SITUACAO_DOC_FSCL_CAN = "S";
        public const string SITUACAO_LAN_EXT_DOC_FSCL_NRM = "E";
        public const string SITUACAO_LAN_EXT_DOC_FSCL_CAN = "X";

        public Tipo53(
            long cnpj_cpf, string inscrEstadual, string uf,
            DateTime dtEmissaoRecebimento,
            int modelo_nf, string serie_nf, int numero_nf,
            long cfop, string emitente,
            double bcICMSsubst, double valorICMSretido,
            double despesasAcessorias,
            string situacao)//casas decimais
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(53)
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
            campos.Add(//MODELO NF
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(modelo_nf)
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
            campos.Add(//NOME DO EMITENTE
                new Campo(1, EnumFormato.ALPHA)
                .appendValor(emitente)
                );
            campos.Add(//BASE DE CALCULO DO ICMS
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(bcICMSsubst)
                );
            campos.Add(//VALOR DO ICMS
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(valorICMSretido)
                );
            campos.Add(//VALOR ISENTA OU NÃO TRIBUTADA
                new Campo(13, EnumFormato.NUMEROS)
                .appendValor(despesasAcessorias)
                );
            campos.Add(//SITUAÇÃO
                new Campo(1, EnumFormato.ALPHA)
                .appendValor(situacao)
                );
            campos.Add(//BRANCOS
                new Campo(30, EnumFormato.ALPHA)
                .appendValor("")
                );
        }
    }
}