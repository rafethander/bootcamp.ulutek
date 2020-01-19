using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_bootcamp_b1_Hander.Helpers
{
    /// <summary>
    /// 5 Karakter Olucak
    /// Ilk 2 karakter ekranı belirticek
    /// 3. karakter mesaj türünü belirticek(I:Info,W:Warning,E:Error)
    /// Son 2 Karakter Hatayı Belirticek
    /// </summary>
    public class ApiResultMessages
    {
        /// <summary>
        /// All Proceses Succesfull
        /// </summary>
        public const string Ok = "Ok";
        #region Product
        /// <summary>
        /// No Product Found 
        /// PRE01=>PRoductError01 
        /// </summary>
        public const string PRE01 = "PRE01";

        #endregion

    }
}
