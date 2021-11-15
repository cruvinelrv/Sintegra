using System;

namespace Multisoft.SistemaSintegra.Code
{
    public abstract class Tipo60 : Tipo
    {
        public const string SUBTIPO_60M = "M";
        public const string SUBTIPO_60A = "A";
    }

    public class Tipo60M : Tipo60
    {

        public Tipo60M(DateTime dtEmissao, string num_serie_equipamento,
            int num_ordem_equipamento, string cod_modelo_doc_fiscal,
            int primeiro_doc_dia, int ultimo_doc_dia, int contador_reducao_z,
            int num_CRO, long valor_venda_bruta, long valor_totalizador_equipamento)
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(60)
                );
            campos.Add(//SUB-TIPO
                new Campo(1, EnumFormato.ALPHA)
                .appendValor("M")
                );
            campos.Add(//
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtEmissao)
                );
            campos.Add(//
                new Campo(20, EnumFormato.ALPHA)
                .appendValor(num_serie_equipamento)
                );
            campos.Add(//
                new Campo(3, EnumFormato.NUMEROS)
                .appendValor(num_ordem_equipamento)
                );
            campos.Add(//
                new Campo(2, EnumFormato.ALPHA)
                .appendValor(cod_modelo_doc_fiscal)
                );
            campos.Add(//
                new Campo(6, EnumFormato.NUMEROS)
                .appendValor(primeiro_doc_dia)
                );
            campos.Add(//
                new Campo(6, EnumFormato.NUMEROS)
                .appendValor(ultimo_doc_dia)
                );
            campos.Add(//
                new Campo(6, EnumFormato.NUMEROS)
                .appendValor(contador_reducao_z)
                );
            campos.Add(//
                new Campo(3, EnumFormato.NUMEROS)
                .appendValor(num_CRO)
                );
            campos.Add(//
                new Campo(16, EnumFormato.NUMEROS)
                .appendValor(valor_venda_bruta)
                );
            campos.Add(//
                new Campo(16, EnumFormato.NUMEROS)
                .appendValor(valor_totalizador_equipamento)
                );
            campos.Add(//brancos
                new Campo(37, EnumFormato.ALPHA)
                .appendValor("")
                );

        }

    }

    public class Tipo60A : Tipo60
    {

        public Tipo60A(DateTime dtEmissao, string num_serie_equipamento,
            string situacaoT_aliquota, long valor_totalizador_equipamento)
        {
            campos.Add(//TIPO
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(60)
                );
            campos.Add(//SUB-TIPO
                new Campo(1, EnumFormato.ALPHA)
                .appendValor("A")
                );
            campos.Add(//
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtEmissao)
                );
            campos.Add(//
                new Campo(20, EnumFormato.ALPHA)
                .appendValor(num_serie_equipamento)
                );
            campos.Add(//
                new Campo(4, EnumFormato.ALPHA)
                .appendValor(situacaoT_aliquota)
                );
            campos.Add(//
                new Campo(12, EnumFormato.NUMEROS)
                .appendValor(valor_totalizador_equipamento)
                );
            campos.Add(//brancos
                new Campo(79, EnumFormato.ALPHA)
                .appendValor("")
                );

        }

    }
}