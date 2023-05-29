using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Showrma.Model
{
    public partial class Client
    {
        public string FulName
        {
            get
            {
                return $"{SName} {FName} {LName}";
            }
        }
    }
}
