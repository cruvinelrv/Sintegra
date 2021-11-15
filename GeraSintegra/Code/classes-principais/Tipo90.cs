using System;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class Tipo90 : Tipo
    {
        public Tipo90(
            long cgc_mf, string insc_estadual,
            int tipo_totalizado, long qtd_tipo_totalizado, int qtd_tipo_90)
        {
            campos.Add(//TIPO
                //EnumCamposTipo10.Tipo,
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(90)
                );
            campos.Add(//CGC_MF,
                new Campo(14, EnumFormato.NUMEROS)
                .appendValor(cgc_mf)
                );
            campos.Add(//InscEst,
                new Campo(14, EnumFormato.ALPHA)
                .appendValor(insc_estadual)
                );
            campos.Add(//Tipo X
                new Campo(2, EnumFormato.NUMEROS)
                .appendValor(tipo_totalizado)
                );
            campos.Add(//Qtd Tipo X
                new Campo(8, EnumFormato.NUMEROS)
                .appendValor(qtd_tipo_totalizado)
                );
            campos.Add(//Brancos,
                new Campo(85, EnumFormato.ALPHA)
                .appendValor(string.Empty)
                );
            campos.Add(//Quantidade de Tipos 90
                new Campo(1, EnumFormato.NUMEROS)
                .appendValor(qtd_tipo_90)
                );

        }
    }
}