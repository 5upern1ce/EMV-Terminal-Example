using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EMV.Terminal
{
    internal class EmvTerminal
    {
        // A terminal "designates the unique location of a terminal at a merchant", it is an 8 digit number that records the transactions processed at that specific point of sale (POS) system
        private string _terminalId;
        // countryCode shows the country of the terminal, represented according to ISO 3166
        private string _countryCode;
        private bool _supportsPin;
        private bool _supportsContactless;
    }
}
