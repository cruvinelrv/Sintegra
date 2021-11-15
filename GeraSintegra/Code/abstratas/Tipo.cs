using System;
using System.Collections.Generic;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public abstract class Tipo
    {
        protected List<Campo> campos = new List<Campo>();

        public const string EMITENTE_PROPRIO = "P";
        public const string EMITENTE_TERCEIROS = "T";
        public const string EMITENTE_BRANCO = " ";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < campos.Count; i++)
                sb.Append(campos[i].ToString());//+" - "
            string s = sb.ToString();
            if (s.Length != 126)
                throw new Exception("Tipo incoeso length: "+s.Length.ToString());

            return s;
        }
    }
}
