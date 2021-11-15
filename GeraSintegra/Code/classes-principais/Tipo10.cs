using System;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo10 : Tipo
    {
        public const string COD_ESTRUTURA = "3";//isso foge ao manual que eu tenho, mas o validador mandou
        public const string COD_NATUREZA = "3";//estranho, conferir manual, vamos deixar o 3 pois parece mais abrangente
        public const string COD_FINALIDADE = "1";//inserção simples
        public Tipo10(
            long cgc_mf, string insc_estadual, string nome_contrib, string municipio, string uf,
            long fax, DateTime dtInicial, DateTime dtFinal,
            string codEstrutura, string codNatureza, string codFinalidade)
        {
            campos.Add(//TIPO
                //EnumCamposTipo10.Tipo,
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(10)
                );
            campos.Add(//CGC_MF,
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cgc_mf)
                );
            campos.Add(//InscEst,
                new Campo(14, EnumFormato.ALPHA)
                .appendValor(insc_estadual)
                );
            campos.Add(//Nome_Contribuinte,
                new Campo(35, EnumFormato.ALPHA)
                .appendValor(nome_contrib)
                );
            campos.Add(//Municipio,
                new Campo(30, EnumFormato.ALPHA)
                .appendValor(municipio)
                );
            campos.Add(//UF,
                new Campo(2, EnumFormato.ALPHA)
                .appendValor(uf)
                );
            campos.Add(//Fax,
                new Campo(10, EnumFormato.NUMEROS)
                .appendValor(fax)
                );
            campos.Add(//DtInicial,
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtInicial)
                );
            campos.Add(//DtFinal,
                new Campo(8, EnumFormato.DATA)
                .appendValor(dtFinal)
                );
            campos.Add(//codEstrutura,
                new Campo(1, EnumFormato.ALPHA)
                .appendValor(codEstrutura)
                );
            campos.Add(//codNatureza,
                new Campo(1, EnumFormato.ALPHA)
                .appendValor(codNatureza)
                );
            campos.Add(//codFinalidade,
                new Campo(1, EnumFormato.ALPHA)
                .appendValor(codFinalidade)
                );
        }
    }
}