using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testAutocadnet
{
    static class CallToForm
    {
        public static void Element()
        {
            Form newform = new ElementForm();
            newform.Show();

        }
    }
}
