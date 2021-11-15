using System;
using System.Collections;
using System.Text;

namespace Multisoft.SistemaSintegra.Code
{
    public class ArquivoMagnetico : IArquivoMagnetico
    {

        Tipo tipo10;
        Tipo tipo11;
        IList lsTipo50;
        IList lsTipo51;
        IList lsTipo53;
        IList lsTipo54;
        IList lsTipo55;
        IList lsTipo56;
        IList lsTipo60;
        IList lsTipo75;
        IList lsTipo90;
        //List<Tipo5> lsTipo5;
        //List<Tipo90> lsTipo90;
        

        public ArquivoMagnetico()
        {
            lsTipo50 = new ArrayList();
            lsTipo51 = new ArrayList();
            lsTipo53 = new ArrayList();
            lsTipo54 = new ArrayList();
            lsTipo55 = new ArrayList();
            lsTipo56 = new ArrayList();
            lsTipo60 = new ArrayList();
            lsTipo75 = new ArrayList();
            lsTipo90 = new ArrayList();
        }

        public void insere(Tipo t)
        {
            /*
            if (t is Tipo50 && lsTipo50.Count > 2)
                return;
            else if (t is Tipo51 && lsTipo51.Count > 2)
                return;
            else if (t is Tipo53 && lsTipo53.Count > 2)
                return;
            else if (t is Tipo54 && lsTipo54.Count > 2)
                return;
            else if (t is Tipo55 && lsTipo55.Count > 2)
                return;
            else if (t is Tipo60 && lsTipo60.Count > 2)
                return;
            /**/


            if (t is Tipo10)
                tipo10 = t;
            else if (t is Tipo11)
                tipo11 = t;
            else if (t is Tipo50)
                lsTipo50.Add(t);
            else if (t is Tipo51)
                lsTipo51.Add(t);
            else if (t is Tipo53)
                lsTipo53.Add(t);
            else if (t is Tipo54)
                lsTipo54.Add(t);
            else if (t is Tipo55)
                lsTipo55.Add(t);
            else if (t is Tipo56)
                lsTipo56.Add(t);
            else if (t is Tipo60)
                lsTipo60.Add(t);
            else if (t is Tipo75)
                lsTipo75.Add(t);
            else if (t is Tipo90)
                lsTipo90.Add(t);

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(tipo10.ToString());
            sb.AppendLine(tipo11.ToString());
            
            for (int i = 0; i < lsTipo50.Count; i++)
                sb.AppendLine(lsTipo50[i].ToString());
            for (int i = 0; i < lsTipo51.Count; i++)
                sb.AppendLine(lsTipo51[i].ToString());
            for (int i = 0; i < lsTipo53.Count; i++)
                sb.AppendLine(lsTipo53[i].ToString());
            for (int i = 0; i < lsTipo54.Count; i++)
                sb.AppendLine(lsTipo54[i].ToString());
            for (int i = 0; i < lsTipo55.Count; i++)
                sb.AppendLine(lsTipo55[i].ToString());
            for (int i = 0; i < lsTipo60.Count; i++)
                sb.AppendLine(lsTipo60[i].ToString());
            for (int i = 0; i < lsTipo75.Count; i++)
                sb.AppendLine(lsTipo75[i].ToString());
            for (int i = 0; i < lsTipo90.Count; i++)
                sb.AppendLine(lsTipo90[i].ToString());

            return sb.ToString();
        }

        #region IArquivoMagnetico Members

        public int countTipo50
        {
            get { return lsTipo50.Count; }
        }

        public int countTipo51
        {
            get { return lsTipo51.Count; }
        }

        public int countTipo53
        {
            get { return lsTipo53.Count; }
        }

        public int countTipo54
        {
            get { return lsTipo54.Count; }
        }

        public int countTipo55
        {
            get { return lsTipo55.Count; }
        }

        public int countTipo56
        {
            get { return lsTipo56.Count; }
        }

        public int countTipo60
        {
            get { return lsTipo60.Count; }
        }

        public int countTipo75
        {
            get { return lsTipo75.Count; }
        }
        /*
        public int countTipo90
        {
            get { return lsTipo90.Count; }
        }
        public int count
        {
            get
            {
                return
                    countTipo50+
                    countTipo51+
                    countTipo53+
                    countTipo54+
                    countTipo55+
                    countTipo56+
                    countTipo60 +
                    countTipo75 +
                    countTipo90 +
                    2;//10,11
            }
        }
        */
        #endregion
    }
}
