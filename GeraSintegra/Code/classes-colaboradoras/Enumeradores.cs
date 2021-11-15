using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public enum EnumFormato
    {
        ALPHA, NUMEROS, DATA //, HORA
    }

    public enum EnumTipo
    {
        TIPO_10
    }

    /// <summary>
    /// possíveis retorno da dll DllInscE32.dll
    /// </summary>
    public enum enumValidaIE
    {
        OK,
        UFINVALIDA,
        PARAMETROINVALIDOS,
        RETORNODESCONHECIDO

    }

    public static class UtilsEnumeradores
    {
        public static string valorEnumFormato(EnumFormato fmt)
        {
            string s = "";
            switch (fmt)
            {
                case EnumFormato.DATA:
                case EnumFormato.NUMEROS:
                    s = "N";
                    break;
                case EnumFormato.ALPHA:
                    s = "X";
                    break;
                default:
                    throw new Exception();
            }
            return s;
        }

    }

}
