using System;

namespace Multisoft.SistemaSintegra.Code
{
    public class ExcecaoLargura : Exception
    {
        private int iLargura = 0;
        public ExcecaoLargura(int iLargura)
        {
            this.iLargura = iLargura;
        }

        public override string Message
        {
            get
            {
                return this.iLargura.ToString() + " não é uma largura aceitável.";
            }
        }
    }

    public class ExcecaoFormatoDoCampo : Exception
    {
        private EnumFormato fmtCorreto, fmtUsado;

        public ExcecaoFormatoDoCampo(EnumFormato fmtCorreto, EnumFormato fmtUsado)
        {
            this.fmtCorreto = fmtCorreto;
            this.fmtUsado = fmtUsado;
        }

        public override string Message
        {
            get
            {
                return string.Format("'{0}' não se aplica a este campo, use o formato '{1}'", fmtUsado, fmtCorreto);
            }
        }
    }
    /// <summary>
    /// Valida inscrição
    /// </summary>
    public class ExceptionInscrEstadual : Exception
    {
        private string mErro = "";
        public ExceptionInscrEstadual(string erro)
        {
            mErro = erro;
        }
        public override string Message
        {
            get
            {
                return "A Inscrição Estadual informada não é válida" + Functions.EOL + "Retorno DLL: " + mErro;
            }
        }
    }
}
